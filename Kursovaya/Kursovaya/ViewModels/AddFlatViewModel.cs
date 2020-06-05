using Kursovaya.Pages;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Media;
using Kursovaya.Models;
using System.IO;
using System.Drawing;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using System;
using Tulpep.NotificationWindow;

namespace Kursovaya.ViewModels
{

    class AddFlatViewModel : ViewModelBase
    {
        private string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Environment.CurrentDirectory + @"\KursFlat.mdf;Integrated Security=True";

        private Main Main;
        private Flat newFlat;

        public Flat NewFlat
        {
            get => newFlat;
            set
            {
                newFlat = value;
                OnPropertyChanged("NewFlat");
            }
        }

        public AddFlatViewModel(Main main)
        {
            Main = main;
            NewFlat = new Flat {CountRooms = 1, Repair = "Косметический" };   
        }


        #region Commands

        public Command.Command SendFlat => new Command.Command(obj =>
        {
            AddFlat addPage = obj as AddFlat;
            SendFlatMethod(addPage);
            Notification.Notification.NotificationPopup();
            var MainDC = Main.DataContext as MainWindowViewModel;
            MainDC.OpenMainPage.Execute(obj);

            NewFlat = new Flat() { CountRooms = 1, Repair = "Косметический" };    
        },
       (obj) => CanExecuteSendFlat());

        /// <summary>
        /// Добавление изображения квартиры
        /// </summary>
        public Command.Command AddImage => new Command.Command(obj =>
        {
            OpenFileDialog PhotoDialog = new OpenFileDialog();
            PhotoDialog.Filter =
                "Image files|*.jpg;*.png;|All files|*.*";
            if (PhotoDialog.ShowDialog() == true)
            {
                System.Drawing.Image Image = System.Drawing.Image.FromFile(PhotoDialog.FileName);
                using (Bitmap bitmapimage = new Bitmap(PhotoDialog.FileName))
                {
                    MemoryStream stream = new MemoryStream();
                    bitmapimage.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                    NewFlat.Image = stream.ToArray();
                }

                System.Windows.Controls.Image image = new System.Windows.Controls.Image() { MaxWidth = 200, Height = 100 };
                image.HorizontalAlignment = HorizontalAlignment.Center;
                image.Height = 150;
                image.Source = new BitmapImage(new Uri(PhotoDialog.FileName));

                DockPanel ImagePanel = obj as DockPanel;
                if (ImagePanel.Children.Count == 1)
                {
                    ImagePanel.Children.Clear();
                    ImagePanel.Children.Add(image);
                }
                else
                    ImagePanel.Children.Add(image);
            }
        },
       (obj) => true);

        #endregion

        #region Methods
        
        private async void SendFlatMethod(AddFlat addFlat){
            SqlConnection connection = new SqlConnection(ConnectionString);
            try{
                await connection.OpenAsync();
                SqlCommand command = new SqlCommand("Insert into Addresses(Sity, District, Street, NumberHouse, Floor, Metro) " +
                    "values (@Sity, @District, @Street, @NumberHouse, @Floor, @Metro) " +
                    "Insert into Demands(WaterHeater, Washer, Microwave, Refrigicator, Internet, TV) " +
                    "values (@WaterHeater, @Washer, @Microwave, @Refrigicator, @Internet, @TV) " +
                    "Insert Into Flats (IDAddress, Images, CountRooms, Area, Repair, Price, IDDemand, IDOwner, Out, TimeAdd, Description) " +
                    "values ((select max(IDAddress) from Addresses), @Images, @CountRooms, @Area, @Repair, @Price, (select max(IDDemand) from Demands), (select IDUser from Users where Login = @Login)," +
                    " 'False', @TimeAdd, @Description)", connection);
                command.Parameters.AddWithValue("@Sity", NewFlat.Address.Sity);
                command.Parameters.AddWithValue("@District", NewFlat.Address.District);
                command.Parameters.AddWithValue("@Street", NewFlat.Address.Street);
                command.Parameters.AddWithValue("@NumberHouse", NewFlat.Address.NumberHouse);
                command.Parameters.AddWithValue("@Floor", NewFlat.Address.Floor);
                command.Parameters.AddWithValue("@Metro", NewFlat.Address.Metro);
                command.Parameters.AddWithValue("@CountRooms", NewFlat.CountRooms);
                if(NewFlat.Image == null)
                {
                    AddDefaultImage();
                    command.Parameters.AddWithValue("@Images", NewFlat.Image);
                }
                else
                    command.Parameters.AddWithValue("@Images", NewFlat.Image);
                command.Parameters.AddWithValue("@Area", double.Parse(NewFlat.Area.Replace(".",",")));
                command.Parameters.AddWithValue("@Repair", NewFlat.Repair);
                command.Parameters.AddWithValue("@Price", NewFlat.Price);
                if (NewFlat.Description is null)
                    command.Parameters.AddWithValue("@Description", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@Description", NewFlat.Description);
                command.Parameters.AddWithValue("@WaterHeater", NewFlat.Demands.WaterHeater);
                command.Parameters.AddWithValue("@Washer", NewFlat.Demands.Washer);
                command.Parameters.AddWithValue("@Microwave", NewFlat.Demands.Microwave);
                command.Parameters.AddWithValue("@Refrigicator", NewFlat.Demands.Refrigicator);
                command.Parameters.AddWithValue("@Internet", NewFlat.Demands.Internet);
                command.Parameters.AddWithValue("@TV", NewFlat.Demands.TV);
                command.Parameters.AddWithValue("@Login", Main.UserTextBlock.Text);
                command.Parameters.AddWithValue("@TimeAdd", DateTime.Now);
                await command.ExecuteNonQueryAsync();
                connection.Close();
                NewFlat = new Flat { CountRooms = 1, Repair = "Косметический" };
                addFlat.ImagePanel.Children.Clear();
            }
            catch (SqlException ex)
            {
                StringBuilder errors = new StringBuilder();
                foreach (SqlError item in ex.Errors)
                {
                    errors.Append(item.ToString() + '\n');
                }
                MessageBox.Show(errors.ToString());
            }
        }

        public void AddDefaultImage()
        {
            System.Drawing.Image Image = System.Drawing.Image.FromFile(Environment.CurrentDirectory + @"\Source\NoPhoto.png");
            using (Bitmap bitmapimage = new Bitmap(Environment.CurrentDirectory + @"\Source\NoPhoto.png"))
            {
                MemoryStream stream = new MemoryStream();
                bitmapimage.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                NewFlat.Image = stream.ToArray();
            }
        }

        /// <summary>
        /// Определяет может ли выполняться команда отправки квартиры на обработку
        /// </summary>
        private bool CanExecuteSendFlat()
        {
            if (NewFlat.ValidationArea(NewFlat.Area).Item2 ||
                NewFlat.ValidationPrice(NewFlat.Price).Item2 ||
                NewFlat.Address.ValidationSity(NewFlat.Address.Sity).Item2 ||
                NewFlat.Address.ValidationDistrict(NewFlat.Address.District).Item2 ||
                NewFlat.Address.ValidationStreet(NewFlat.Address.Street).Item2 ||
                NewFlat.Address.ValidationMetro(NewFlat.Address.Metro).Item2)
            {
                return false;
            }
            else
                return true;
        }
        
        #endregion
    }
}
