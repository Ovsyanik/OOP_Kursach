using System.Text;
using System.Data.SqlClient;
using System.Windows;
using Kursovaya.Models;
using System.Security.Cryptography;
using System;
using System.Threading.Tasks;

namespace Kursovaya.ViewModels
{
    class RegistrationViewModel : ViewModelBase
    {
        public User NewUser { get; set; }

        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + System.Environment.CurrentDirectory + @"\KursFlat.mdf;Integrated Security=True";

        private AutorizationWindow window;

        public RegistrationViewModel(AutorizationWindow window)
        {
            NewUser = new User() { Role = "Пользователь" };

            this.window = window;
        }

        private float opacityButtonRegistration = 1;
        public float OpacityButtonRegistration
        {
            get => opacityButtonRegistration;
            set
            {
                opacityButtonRegistration = value;
                OnPropertyChanged("OpacityButtonRegistration");
            }
        }

        public Command.Command NavigateAutorization => new Command.Command(obj =>
        {
            window.MaxHeight = 600;
            window.MaxWidth = 400;
            window.Height = 600;
            window.Width = 400;
            window.Rectangle.Height = 360;
            window.BorderFrame1.Height = 400;
            window.BorderFrame1.Width = 280;
            var DCWindow = window.DataContext as LoginWindowViewModel;
            DCWindow.CurrentPage = DCWindow.autorization;
        },
        (obj) => true);

        /// <summary>
        /// Заносит пользователя в бд
        /// </summary>
        public Command.Command AddUserCommand => new Command.Command(obj =>
        {
            if (CheckedUserInDB(NewUser) == true)
            {
                SqlConnection connection = new SqlConnection(connectionString);
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("Insert Into Users(NameRoles, FirstName, LastName, NumberPhone, Login, Password) " +
                        $"values (@NameRoles, @FirstName, @LastName, @NumberPhone, @Login, @Password)", connection);
                    command.Parameters.AddWithValue("@NameRoles", NewUser.Role);
                    command.Parameters.AddWithValue("@FirstName", NewUser.FirstName);
                    command.Parameters.AddWithValue("@LastName", NewUser.LastName);
                    command.Parameters.AddWithValue("@NumberPhone", NewUser.NumberPhone);
                    command.Parameters.AddWithValue("@Login", NewUser.Mail);
                    command.Parameters.AddWithValue("@Password",getSHA256(NewUser.Password));
                    command.ExecuteNonQuery();
                    MessageBox.Show($"Успешно зарегистрировались");
                    NavigateAutorization.Execute(obj);
                    connection.Close();
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
            else
            {
                MessageBox.Show("Пользователь с такой почтой существует");
            }
        },
        (obj) => CanExecuteAddUser());

        /// <summary>
        /// Определяет может ли выполнять команда AddUserCommand
        /// </summary>
        /// <returns></returns>
        private bool CanExecuteAddUser()
        {
            if (NewUser.ValidationFirstName(NewUser.FirstName).Item2 ||
                NewUser.ValidationLastName(NewUser.LastName).Item2 ||
                NewUser.ValidationMail(NewUser.Mail).Item2 ||
                NewUser.ValidationNumberPhone(NewUser.NumberPhone).Item2 ||
                NewUser.ValidationPassword(NewUser.Password).Item2 ||
                NewUser.ValidationPassword(NewUser.Password2).Item2)
            {
                OpacityButtonRegistration = 0.7F;
                return false;
            }
            else
            {
                OpacityButtonRegistration = 1;
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

        private bool CheckedUserInDB(User user)
        {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand($"select count(*) from Users where Login = '{user.Mail}'", connection);
                    int count = (int)command.ExecuteScalar();
                    connection.Close();
                    if (count != 0)
                    {                    
                        return false;
                    }
                    else
                    {
                    return true;
                    }
                }
        }
    }
}
