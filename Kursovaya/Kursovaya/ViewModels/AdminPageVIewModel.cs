using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Text;
using System.Data.SqlClient;
using Kursovaya.Models;
using System.Data;
using Kursovaya.Pages;


namespace Kursovaya.ViewModels
{
    class AdminPageVIewModel : ViewModelBase
    {
        private string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + System.Environment.CurrentDirectory + @"\KursFlat.mdf;Integrated Security=True";

        /// <summary>
        /// Список квартир
        /// </summary>
        public ObservableCollection<Flat> Flats { get; set; } = new ObservableCollection<Flat>();
        private Flat selectedFlat;
        public Flat SelectedFlat
        {
            get => selectedFlat;
            set
            {
                selectedFlat = value;
                OnPropertyChanged("SelectedFlat");
            }
        }
        SqlConnection connection;
        PageAdmin PageAdmin;

        public AdminPageVIewModel(PageAdmin pageAdmin)
        {
            this.PageAdmin = pageAdmin;
            GetFlats();
        }

        #region Commands

        /// <summary>
        /// Удаляет квартиру
        /// </summary>
        public Command.Command RemoveFlat => new Command.Command((obj) =>
        {
            Flat flat =  obj as Flat;
            if (flat != null)
            {
                Flats.Remove(flat);
            }
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand("RemoveFlatByID",conn);
                command.CommandType = CommandType.StoredProcedure;
                try
                {
                    command.Parameters.AddWithValue("@IDFlat", flat.ID);
                    command.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Не выбран элемент удаления");
                }
                conn.Close();
            }
        });

        /// <summary>
        /// Сохраняет измененные данные
        /// </summary>
        public Command.Command SaveChangedFlats => new Command.Command((obj) => {
            string error = String.Empty;
            try {
                using (SqlConnection conn = new SqlConnection(ConnectionString)) {
                    bool flags = true;
                    conn.Open();
                    SqlCommand sqlCommand = new SqlCommand("truncate table Flats; truncate table Addresses; truncate table Demands", conn);    
                    SqlCommand command;
                    foreach (var item in Flats) {
                        command = new SqlCommand("Insert into Addresses(Sity, District, Street, NumberHouse, Floor, Metro)" +
                        "values (@Sity, @District, @Street, @NumberHouse, @Floor, @Metro)" +
                        "Insert into Demands(WaterHeater, Washer, Microwave, Refrigicator, Internet, TV)" +
                        "values (@WaterHeater, @Washer, @Microwave, @Refrigicator, @Internet, @TV)" +
                        "Insert Into Flats (IDAddress, Images, CountRooms, Area, Repair, Price, IDDemand, IDOwner, Out, TimeAdd, Description)" +
                        "values ((select max(IDAddress) from Addresses), @Images, @CountRooms, @Area, @Repair, @Price, " +
                        "(select max(IDDemand) from Demands), (select IDUser from Users where Login = @Login), @Out, @TimeAdd,@Description)", conn);
                        command.Parameters.AddWithValue("@Sity", item.Address.Sity);
                        command.Parameters.AddWithValue("@District", item.Address.District);
                        command.Parameters.AddWithValue("@Street", item.Address.Street);
                        if (item.Address.ValidationNumberHouse(item.Address.NumberHouse).Item2 == false)
                            command.Parameters.AddWithValue("@NumberHouse", item.Address.NumberHouse);
                        else
                            error += "Недопустимые символы в номере дома!";
                        if (item.Address.ValidationFloor(item.Address.Floor).Item2 == false)
                            command.Parameters.AddWithValue("@Floor", item.Address.Floor);
                        else
                            error += "Недопустимые символы в этаже!";
                        command.Parameters.AddWithValue("@Metro", item.Address.Metro);
                        if (item.ValidationCountRooms(item.CountRooms).Item2 == false)
                            command.Parameters.AddWithValue("@CountRooms", item.CountRooms);
                        else
                            error += "Недопустимые символы в CountRooms!";
                        command.Parameters.AddWithValue("@Images", item.Image);
                        if (item.ValidationArea(item.Area).Item2 == false)
                            command.Parameters.AddWithValue("@Area", Double.Parse(item.Area.Replace(".", ",")));
                        else
                            error += "Недопустимые символы в Площади\n";
                        command.Parameters.AddWithValue("@Repair", item.Repair);
                        if (item.ValidationPrice(item.Price).Item2 == false)
                            command.Parameters.AddWithValue("@Price", Double.Parse(item.Price.Replace(".", ",")));
                        else
                            error += "Недопустимые символы в Цене";
                        command.Parameters.AddWithValue("@WaterHeater", item.Demands.WaterHeater);
                        command.Parameters.AddWithValue("@Washer", item.Demands.Washer);
                        command.Parameters.AddWithValue("@Microwave", item.Demands.Microwave);
                        command.Parameters.AddWithValue("@Refrigicator", item.Demands.Refrigicator);
                        command.Parameters.AddWithValue("@Internet", item.Demands.Internet);
                        command.Parameters.AddWithValue("@TV", item.Demands.TV);
                        command.Parameters.AddWithValue("@Out", item.Output);
                        command.Parameters.AddWithValue("@TimeAdd", item.TimeAdd);
                        command.Parameters.AddWithValue("@Description", item.Description);
                        command.Parameters.AddWithValue("@Login", item.User.Mail);
                        if (error.Length == 0){
                            if (flags){
                                sqlCommand.ExecuteNonQuery();
                                flags = false; }
                            command.ExecuteNonQuery(); }
                        else {
                            MessageBox.Show(error);
                            error = String.Empty; } }
                    conn.Close(); } }
            catch { } });

        /// <summary>
        /// Получает новые квартиры, если они появились в бд
        /// </summary>
        public Command.Command GetNewFlat => new Command.Command((obj) =>
        {
            GetFlats();
        });

        #endregion

        #region Methods

        /// <summary>
        /// Получает квартиры с бд
        /// </summary>
        private async void GetFlats()
        {
            string Query = "SELECT Images, CountRooms, Area, rtrim(Repair), Price, rtrim(Sity), rtrim(District), rtrim(Street), rtrim(NumberHouse), " +
            "Floor, rtrim(Metro), WaterHeater, Washer, Microwave, Refrigicator, Internet, TV, TimeAdd, FirstName, LastName, NumberPhone, Login, isnull(Description, ' '),  Out, IDFlat  from Flats " +
            "inner join Demands on Flats.IDDemand = Demands.IDDemand " +
            "inner join Addresses on Flats.IDAddress = Addresses.IDAddress " +
            "inner join Users on Flats.IDOwner = Users.IDUser ";
            Flats.Clear();
            connection = new SqlConnection(ConnectionString);
            try
            {
                await connection.OpenAsync();

                SqlCommand command = new SqlCommand(Query, connection);
                SqlDataReader reader = await command.ExecuteReaderAsync();
                if (reader.HasRows)
                {
                    while (reader.Read())
                        Flats.Add(new Flat()
                        {
                            Image = (byte[])reader.GetValue(0),
                            CountRooms = reader.GetInt32(1),
                            Area = reader.GetDouble(2).ToString(),
                            Repair = reader.GetString(3),
                            Price = reader.GetDecimal(4).ToString(),
                            TimeAdd = reader.GetDateTime(17),
                            Description = reader.GetString(22),
                            ID = reader.GetInt32(24),
                            Address = new Address()
                            {
                                Sity = reader.GetString(5),
                                District = reader.GetString(6),
                                Street = reader.GetString(7),
                                NumberHouse = reader.GetString(8),
                                Floor = reader.GetInt32(9),
                                Metro = reader.GetString(10)
                            },
                            Demands = new Demands()
                            {
                                WaterHeater = reader.GetBoolean(11),
                                Washer = reader.GetBoolean(12),
                                Microwave = reader.GetBoolean(13),
                                Refrigicator = reader.GetBoolean(14),
                                Internet = reader.GetBoolean(15),
                                TV = reader.GetBoolean(16)
                            },
                            User = new User()
                            {
                                FirstName = reader.GetString(18),
                                LastName = reader.GetString(19),
                                NumberPhone = reader.GetString(20),
                                Mail = reader.GetString(21)
                            },
                            Output = reader.GetBoolean(23)
                        });
                    reader.NextResult();
                    reader.Close();
                }
                connection.Close();
            }
            catch (SqlException ex)
            {
                StringBuilder Errors = new StringBuilder();
                foreach (var item in ex.Errors)
                {
                    Errors.Append(item.ToString() + "\n");
                }
                MessageBox.Show(Errors.ToString() + ex.InnerException);
            }
        }

        #endregion
    }
}
