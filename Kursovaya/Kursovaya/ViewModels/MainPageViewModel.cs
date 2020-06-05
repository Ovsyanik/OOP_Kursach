using System.Text;
using System.Data.SqlClient;
using Kursovaya.Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Threading;
using Kursovaya.Pages;
using System;
using System.Linq;

namespace Kursovaya.ViewModels
{
    class MainPageViewModel : ViewModelBase
    {
        private int SortByPriceVar { get; set; } = 1;
        private int SortByTime { get; set; } = 1;
        private string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + System.Environment.CurrentDirectory + @"\KursFlat.mdf;Integrated Security=True";

        public ObservableCollection<Flat> Flats { get; set; } = new ObservableCollection<Flat>();
        private Flat flatFilter;
        public Flat FlatFilter
        { 
            get => flatFilter;
            set
            {
                flatFilter = value;
                OnPropertyChanged("FlatFilter");
            }
        }

        Main main;

        public MainPageViewModel(Main main)
        {
            FlatFilter = new Flat();
            GetFlat();
            this.main = main;
        }

        #region Commands

        public Command.Command UpdateList => new Command.Command((obj) =>
        {
            GetFlat();
        });

        public Command.Command OpenDetails => new Command.Command((obj) =>
        {
            var DCMain = main.DataContext as MainWindowViewModel;
            var DCDetails = DCMain.pageDetailsFlat.DataContext as PageFlatViewModel;
            var flat = obj as Flat;
            DCMain.CurrentPage = DCMain.pageDetailsFlat;
            DCDetails.CurrentFlat = flat;
            DCMain.Title = "Описание";
        });

        public Command.Command ApplyFilter => new Command.Command(obj =>
        {
            var ContextMain = main.DataContext as MainWindowViewModel;
            var ContextMainPage = ContextMain.mainPage.DataContext as MainPageViewModel;
            var MPage = obj as MainPage;
            GetFlatWithFilter(ContextMainPage, MPage);

        });

        /// <summary>
        ///  Сбрасывает фильтр и возвращает начальный список 
        /// </summary>
        public Command.Command ResetFilter => new Command.Command(obj =>
        {
            var ContextMain = main.DataContext as MainWindowViewModel;
            var ContextMainPage = ContextMain.mainPage.DataContext as MainPageViewModel;
            var MPage = obj as MainPage;
            
            ResetUIElemets(MPage);
            FlatFilter = new Flat();

            ContextMainPage.UpdateList.Execute(obj);

        });

        public Command.Command SortByTimeAdd => new Command.Command(obj =>
        {
            if (SortByTime == 1)
            {
                var result = new ObservableCollection<Flat>(Flats.OrderBy(u => u.TimeAdd).ThenBy(u => u.TimeAdd).ToList());
                Flats.Clear();
                foreach (var item in result)
                {
                    Flats.Add(item);
                }
                SortByTime = 2;
            }
            else
            {
                var result = new ObservableCollection<Flat>(Flats.OrderByDescending(u => u.TimeAdd).ThenByDescending(u => u.TimeAdd).ToList());
                Flats.Clear();
                foreach (var item in result)
                {
                    Flats.Add(item);
                }
                SortByTime = 1;
            }
        });

        public Command.Command SortByPrice => new Command.Command(obj =>
        {
            if (SortByPriceVar == 1)
            {
                var result = new ObservableCollection<Flat>(Flats.OrderBy(u => Double.Parse(u.Price)).ThenBy(u => Double.Parse(u.Price)).ToList());
                Flats.Clear();
                foreach (var item in result)
                {
                    Flats.Add(item);
                }
                SortByPriceVar = 2;
            }
            else
            {
                var result = new ObservableCollection<Flat>(Flats.OrderByDescending(u => Double.Parse(u.Price)).ThenByDescending(u => Double.Parse(u.Price)).ToList());
                Flats.Clear();
                foreach (var item in result)
                {
                    Flats.Add(item);
                }
                SortByPriceVar = 1;
            }
        });

        #endregion

        #region Methods

        private async void GetFlat()
        {
            Flats.Clear();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    await connection.OpenAsync();

                    SqlCommand command = new SqlCommand("GetInfoAboutFlat", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Flats.Add(new Flat()
                            {
                                Image = (byte[])reader.GetValue(0),
                                CountRooms = reader.GetInt32(1),
                                Area = reader.GetDouble(2).ToString(),
                                Repair = reader.GetString(3),
                                Price = reader.GetDecimal(4).ToString(),
                                TimeAdd = reader.GetDateTime(17),
                                Description = reader.GetString(22),
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
                                    WaterHeaterText = (reader.GetBoolean(11) == true ? "Есть" : "Нету"),
                                    WasherText = (reader.GetBoolean(12) == true ? "Есть" : "Нету"),
                                    MicrowaveText = (reader.GetBoolean(13) == true ? "Есть" : "Нету"),
                                    RefrigicatorText = (reader.GetBoolean(14) == true ? "Есть" : "Нету"),
                                    InternetText = (reader.GetBoolean(15) == true ? "Есть" : "Нету"),
                                    TVText = (reader.GetBoolean(16) == true ? "Есть" : "Нету")
                                },
                                User = new User()
                                {
                                    FirstName = reader.GetString(18),
                                    LastName = reader.GetString(19),
                                    NumberPhone = reader.GetString(20),
                                    Mail = reader.GetString(21)
                                }
                            });
                        }
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
        }

        /// <summary>
        /// Сбрасывает элементы управления на странице Filter
        /// </summary>
        private void ResetUIElemets(MainPage filter)
        {
            filter.SityBox.Clear();
            filter.DistrictBox.Clear();
            filter.StreetBox.Clear();
            filter.MetroBox.Clear();
            filter.PriceMax.Clear();
            filter.PriceMin.Clear();
            filter.FloorMax.Clear();
            filter.FloorMin.Clear();
            filter.AreaMax.Clear();
            filter.AreaMin.Clear();
            filter.CountRoomsBox.Text = null;
            filter.RepairBox.Text = null;
            filter.CheckBoxFilter.IsChecked = false;
            filter.InternetCheck.IsChecked = false;
            filter.MicrowaveCheck.IsChecked = false;
            filter.RefregicatorCheck.IsChecked = false;
            filter.TVCheck.IsChecked = false;
            filter.WasherCheck.IsChecked = false;
            filter.WaterHeaterCheck.IsChecked = false;
        }

        private async void GetFlatWithFilter(MainPageViewModel ContextMainPage, MainPage filter)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    SqlCommand command;
                    bool flags;
                    if (filter.CheckBoxFilter.IsChecked == true)
                    {
                        command = new SqlCommand("QueryWithDemands", connection);
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        flags = ParametersAddWithValueWithDemands(command);
                    }
                    else
                    {
                        command = new SqlCommand("QueryWithoutDemands", connection);
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        flags = ParametersAddWithValueWithoutDemands(command);
                    }
                    if (flags)
                    {
                        ContextMainPage.Flats.Clear();
                        SqlDataReader reader = await command.ExecuteReaderAsync();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                ContextMainPage.Flats.Add(new Flat()
                                {
                                    Image = (byte[])reader.GetValue(0),
                                    CountRooms = reader.GetInt32(1),
                                    Area = reader.GetDouble(2).ToString(),
                                    Repair = reader.GetString(3),
                                    Price = reader.GetDecimal(4).ToString(),
                                    TimeAdd = reader.GetDateTime(17),
                                    Description = reader.GetString(22),
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
                                        WaterHeaterText = (reader.GetBoolean(11) == true ? "Есть" : "Нету"),
                                        WasherText = (reader.GetBoolean(12) == true ? "Есть" : "Нету"),
                                        MicrowaveText = (reader.GetBoolean(13) == true ? "Есть" : "Нету"),
                                        RefrigicatorText = (reader.GetBoolean(14) == true ? "Есть" : "Нету"),
                                        InternetText = (reader.GetBoolean(15) == true ? "Есть" : "Нету"),
                                        TVText = (reader.GetBoolean(16) == true ? "Есть" : "Нету")
                                    },
                                    User = new User()
                                    {
                                        FirstName = reader.GetString(18),
                                        LastName = reader.GetString(19),
                                        NumberPhone = reader.GetString(20),
                                        Mail = reader.GetString(21)
                                    }
                                });
                            }
                            reader.NextResult();
                            reader.Close();
                        }
                        connection.Close();
                    }
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
        }

        private bool ParametersAddWithValueWithDemands(SqlCommand command)
        {

            string error = String.Empty;
            command.Parameters.AddWithValue("@Microwave", FlatFilter.Demands.Microwave);
            command.Parameters.AddWithValue("@WaterHeater", FlatFilter.Demands.WaterHeater);
            command.Parameters.AddWithValue("@Washer", FlatFilter.Demands.Washer);
            command.Parameters.AddWithValue("@Refrigicator", FlatFilter.Demands.Refrigicator);
            command.Parameters.AddWithValue("@Internet", FlatFilter.Demands.Internet);
            command.Parameters.AddWithValue("@TV", FlatFilter.Demands.TV);
            if (FlatFilter.CountRooms is null)
                command.Parameters.AddWithValue("@CountRooms", DBNull.Value);
            else
            {
                command.Parameters.AddWithValue("@CountRooms", FlatFilter.CountRooms);
            }

            if (FlatFilter.PriceMin is null || FlatFilter.PriceMin == String.Empty)
                command.Parameters.AddWithValue("@PriceMin", DBNull.Value);
            else
            {
                if (FlatFilter.ValidationArea(FlatFilter.PriceMin).Item2 == false)
                    command.Parameters.AddWithValue("@PriceMin", FlatFilter.PriceMin.Replace(",", "."));
                else
                {
                    error += "Неверный формат поля минимальной цены \n";
                    FlatFilter.PriceMin = null;
                }
            }

            if (FlatFilter.PriceMax is null || FlatFilter.PriceMax == String.Empty)
                command.Parameters.AddWithValue("@PriceMax", DBNull.Value);
            else
            {
                if (FlatFilter.ValidationArea(FlatFilter.PriceMax).Item2 == false)
                    command.Parameters.AddWithValue("@PriceMax", FlatFilter.PriceMax.Replace(",", "."));
                else
                {
                    error += "Неверный формат поля максимальной цены \n";
                    FlatFilter.PriceMax = null;
                }
            }


            if (FlatFilter.Repair is null || FlatFilter.Repair == String.Empty)
                command.Parameters.AddWithValue("@Repair", DBNull.Value);
            else
            {
                command.Parameters.AddWithValue("@Repair", FlatFilter.Repair);
            }

            if (FlatFilter.Address.Sity is null || FlatFilter.Address.Sity == String.Empty)
                command.Parameters.AddWithValue("@Sity", DBNull.Value);
            else
            {
                command.Parameters.AddWithValue("@Sity", FlatFilter.Address.Sity);
            }

            if (FlatFilter.Address.District is null || FlatFilter.Address.District == String.Empty)
                command.Parameters.AddWithValue("@District", DBNull.Value);
            else
            {
                command.Parameters.AddWithValue("@District", FlatFilter.Address.District);
            }

            if (FlatFilter.Address.Street is null || FlatFilter.Address.Street == String.Empty)
                command.Parameters.AddWithValue("@Street", DBNull.Value);
            else
            {
                command.Parameters.AddWithValue("@Street", FlatFilter.Address.Street);
            }

            if (FlatFilter.AreaMin is null || FlatFilter.AreaMin == String.Empty)
                command.Parameters.AddWithValue("@AreaMin", DBNull.Value);
            else
            {
                if (FlatFilter.ValidationArea(FlatFilter.AreaMin).Item2 == false)
                    command.Parameters.AddWithValue("@AreaMin", FlatFilter.AreaMin.Replace(",", "."));
                else
                {
                    error += "Неверный формат поля минимальной площади \n";
                    FlatFilter.AreaMin = null;
                }
            }

            if (FlatFilter.AreaMax is null || FlatFilter.AreaMax == String.Empty)
                command.Parameters.AddWithValue("@AreaMax", DBNull.Value);
            else
            {
                if (FlatFilter.ValidationArea(FlatFilter.AreaMax).Item2 == false)
                    command.Parameters.AddWithValue("@AreaMax", FlatFilter.AreaMax.Replace(",", "."));
                else
                {
                    error += "Неверный формат поля максимальной площади \n";
                    FlatFilter.AreaMax = null;
                }
            }

            if (FlatFilter.Address.FloorMin == null || FlatFilter.Address.FloorMin == String.Empty)
                command.Parameters.AddWithValue("@FloorMin", DBNull.Value);
            else
            {
                if (FlatFilter.Address.ValidationFloorMax(FlatFilter.Address.FloorMin).Item2 == false)
                    command.Parameters.AddWithValue("@FloorMin", FlatFilter.Address.FloorMin);
                else
                {
                    error += "Неверный формат поля минимального этажа \n";
                    FlatFilter.Address.FloorMin = null;
                }
            }

            if (FlatFilter.Address.FloorMax == null || FlatFilter.Address.FloorMax == String.Empty)
                command.Parameters.AddWithValue("@FloorMax", DBNull.Value);
            else
            {
                if (FlatFilter.Address.ValidationFloorMax(FlatFilter.Address.FloorMax).Item2 == false)
                    command.Parameters.AddWithValue("@FloorMax", FlatFilter.Address.FloorMax);
                else
                {
                    error += "Неверный формат поля максимального этажа \n";
                    FlatFilter.Address.FloorMax = null;
                }
            }

            if (FlatFilter.Address.Metro is null || FlatFilter.Address.Metro == String.Empty)
                command.Parameters.AddWithValue("@Metro", DBNull.Value);
            else
            {
                command.Parameters.AddWithValue("@Metro", FlatFilter.Address.Metro);
            }
            if (error.Length != 0)
            {
                MessageBox.Show(error);
                error = String.Empty;
                return false;
            }
            else
                return true;
        }

        private bool ParametersAddWithValueWithoutDemands(SqlCommand command)
        {

            string error = String.Empty;
            if (FlatFilter.CountRooms is null)
                command.Parameters.AddWithValue("@CountRooms", DBNull.Value);
            else
            {
                command.Parameters.AddWithValue("@CountRooms", FlatFilter.CountRooms);
            }

            if (FlatFilter.PriceMin is null || FlatFilter.PriceMin == String.Empty)
                command.Parameters.AddWithValue("@PriceMin", DBNull.Value);
            else
            {
                if (FlatFilter.ValidationArea(FlatFilter.PriceMin).Item2 == false)
                    command.Parameters.AddWithValue("@PriceMin", FlatFilter.PriceMin.Replace(",", "."));
                else
                {
                    error += "Неверный формат поля минимальной цены \n";
                    FlatFilter.PriceMin = null;
                }
            }

            if (FlatFilter.PriceMax is null || FlatFilter.PriceMax == String.Empty)
                command.Parameters.AddWithValue("@PriceMax", DBNull.Value);
            else
            {
                if (FlatFilter.ValidationArea(FlatFilter.PriceMax).Item2 == false)
                    command.Parameters.AddWithValue("@PriceMax", FlatFilter.PriceMax.Replace(",", "."));
                else
                {
                    error += "Неверный формат поля максимальной цены \n";
                    FlatFilter.PriceMax = null;
                }
            }


            if (FlatFilter.Repair is null || FlatFilter.Repair == String.Empty)
                command.Parameters.AddWithValue("@Repair", DBNull.Value);
            else
            {
                command.Parameters.AddWithValue("@Repair", FlatFilter.Repair);
            }

            if (FlatFilter.Address.Sity is null || FlatFilter.Address.Sity == String.Empty)
                command.Parameters.AddWithValue("@Sity", DBNull.Value);
            else
            {
                command.Parameters.AddWithValue("@Sity", FlatFilter.Address.Sity);
            }

            if (FlatFilter.Address.District is null || FlatFilter.Address.District == String.Empty)
                command.Parameters.AddWithValue("@District", DBNull.Value);
            else
            {
                command.Parameters.AddWithValue("@District", FlatFilter.Address.District);
            }

            if (FlatFilter.Address.Street is null || FlatFilter.Address.Street == String.Empty)
                command.Parameters.AddWithValue("@Street", DBNull.Value);
            else
            {
                command.Parameters.AddWithValue("@Street", FlatFilter.Address.Street);
            }

            if (FlatFilter.AreaMin is null || FlatFilter.AreaMin == String.Empty)
                command.Parameters.AddWithValue("@AreaMin", DBNull.Value);
            else
            {
                if (FlatFilter.ValidationArea(FlatFilter.AreaMin).Item2 == false)
                    command.Parameters.AddWithValue("@AreaMin", FlatFilter.AreaMin.Replace(",", "."));
                else
                {
                    error += "Неверный формат поля минимальной площади \n";
                    FlatFilter.AreaMin = null;
                }
            }

            if (FlatFilter.AreaMax is null || FlatFilter.AreaMax == String.Empty)
                command.Parameters.AddWithValue("@AreaMax", DBNull.Value);
            else
            {
                if (FlatFilter.ValidationArea(FlatFilter.AreaMax).Item2 == false)
                    command.Parameters.AddWithValue("@AreaMax", FlatFilter.AreaMax.Replace(",", "."));
                else
                {
                    error += "Неверный формат поля максимальной площади \n";
                    FlatFilter.AreaMax = null;
                }
            }

            if (FlatFilter.Address.FloorMin == null || FlatFilter.Address.FloorMin == String.Empty)
                command.Parameters.AddWithValue("@FloorMin", DBNull.Value);
            else
            {
                if (FlatFilter.Address.ValidationFloorMax(FlatFilter.Address.FloorMin).Item2 == false)
                    command.Parameters.AddWithValue("@FloorMin", FlatFilter.Address.FloorMin);
                else
                {
                    error += "Неверный формат поля минимального этажа \n";
                    FlatFilter.Address.FloorMin = null;
                }
            }

            if (FlatFilter.Address.FloorMax == null || FlatFilter.Address.FloorMax == String.Empty)
                command.Parameters.AddWithValue("@FloorMax", DBNull.Value);
            else
            {
                if (FlatFilter.Address.ValidationFloorMax(FlatFilter.Address.FloorMax).Item2 == false)
                    command.Parameters.AddWithValue("@FloorMax", FlatFilter.Address.FloorMax);
                else
                {
                    error += "Неверный формат поля максимального этажа \n";
                    FlatFilter.Address.FloorMax = null;
                }
            }

            if (FlatFilter.Address.Metro is null || FlatFilter.Address.Metro == String.Empty)
                command.Parameters.AddWithValue("@Metro", DBNull.Value);
            else
            {
                command.Parameters.AddWithValue("@Metro", FlatFilter.Address.Metro);
            }
            if (error.Length != 0)
            {
                MessageBox.Show(error);
                error = String.Empty;
                return false;
            }
            else
                return true;
        }

        #endregion


    }
}
