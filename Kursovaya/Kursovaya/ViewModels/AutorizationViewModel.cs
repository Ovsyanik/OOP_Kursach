using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Data.SqlClient;
using System.Windows;
using Kursovaya.Models;
using Kursovaya.Pages;
using System.Windows.Controls;
using System.Windows.Input;
using System.Security.Cryptography;

namespace Kursovaya.ViewModels
{
    class AutorizationViewModel : ViewModelBase
    {
        private AutorizationWindow window;
        public User User { get; set; }
        private float opacityButtonAutorization = 1;
        public float OpacityButtonAutorization
        {
            get => opacityButtonAutorization;
            set
            {
                opacityButtonAutorization = value;
                OnPropertyChanged("OpacityButtonAutorization");
            }
        }

        public AutorizationViewModel(AutorizationWindow window)
        {
            User = new User();
            this.window = window;
        }

        public Command.Command NavigateRegistration => new Command.Command(obj =>
        {
            window.MaxHeight = 800;
            window.MaxWidth = 500;
            window.Height = 800;
            window.Width = 500;
            window.Rectangle.Height = 470;
            window.BorderFrame1.Margin = new System.Windows.Thickness(0, 40, 0, 0);
            window.BorderFrame1.Height = 650;
            window.BorderFrame1.Width = 350;
            var DCWindow = window.DataContext as LoginWindowViewModel;
            DCWindow.CurrentPage = DCWindow.registration;
        },
       (obj) => true);

        public Command.Command Autorization => new Command.Command(obj =>{
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + System.Environment.CurrentDirectory + @"\KursFlat.mdf;Integrated Security=True";
            Main main = new Main();
            SqlConnection connection = new SqlConnection(connectionString);
            try{
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT rtrim(Login), rtrim(NameRoles) from Users where Login = @Mail and Password = @Password", connection);
                command.Parameters.AddWithValue("@Mail", User.Mail);
                command.Parameters.AddWithValue("@Password", getSHA256(User.Password));
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows){
                    while (reader.Read()){
                        if (reader.GetString(1) == "Пользователь"){
                            main.UserTextBlock.Text = reader.GetString(0);
                            main.MenuPanel.Children.Remove(main.AdminButton);
                            main.Show();
                            window.Close();
                        }
                        if(reader.GetString(1) == "Админ"){
                            main.UserTextBlock.Text = reader.GetString(0);
                            main.MenuPanel.Children.Remove(main.AddFlatButton);
                            main.Show();
                            window.Close();
                        }
                    }
                    reader.NextResult();
                    reader.Close();
                }
                else
                    MessageBox.Show($"Пользователя {User.Mail} не существует!!!\n\tИли введите корректные данные");
            }
            catch (SqlException ex){
                StringBuilder errors = new StringBuilder();
                foreach (SqlError item in ex.Errors){
                    errors.Append(item.ToString() + '\n');
                }
                MessageBox.Show(errors.ToString());
            }
},
        (obj) => CanExecuteAutorization());

        private bool CanExecuteAutorization()
        {
            if (User.ValidationMail(User.Mail).Item2 || User.ValidationPassword(User.Password).Item2)
            {
                OpacityButtonAutorization = 0.7F;
                return false;
            }
            else
            {
                OpacityButtonAutorization = 1;
                return true;
            }
        }

        private string getSHA256(string input)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            SHA256Managed hashString = new SHA256Managed();
            byte[] hash = hashString.ComputeHash(bytes);
            string outHash = String.Empty;
            foreach (byte x in hash)
            {
                outHash += String.Format("{0:x2}", x);
            }
            return outHash;
        }
    }
}
