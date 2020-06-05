using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Kursovaya.Models
{
    public class User : INotifyPropertyChanged, IDataErrorInfo
    {
        private string firstName;
        private string lastName;
        private string numberPhone;
        private string mail;
        private string password;
        private string password2;
        private string role;

        public string FirstName
        {
            get => firstName;
            set
            { 
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }
        public string LastName
        {
            get => lastName;
            set
            {
                    lastName = value;
                    OnPropertyChanged("LastName");
            }
        }
        public string Mail
        {
            get => mail;
            set
            {
                mail = value;
                OnPropertyChanged("Mail");
            }
        }
        public string NumberPhone
        {
            get => numberPhone;
            set
            {
                numberPhone = value;
                OnPropertyChanged("NumberPhone");
            }
        }       
        public string Role
        {
            get => role;
            set
            {
                role = value;
                OnPropertyChanged("Role");
            }
        }
        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }
        public string Password2
        {
            get => password2;
            set
            {
                password2 = value;
                OnPropertyChanged("Password2");
            }
        }

        public string this[string name]
        {
            get
            {
                string error = String.Empty;

                switch (name)
                {
                    case "FirstName":
                        if (ValidationFirstName(FirstName).Item2)
                            error = ValidationFirstName(FirstName).Item1;
                        break;
                    case "LastName":
                        if (ValidationLastName(LastName).Item2)
                            error = ValidationLastName(LastName).Item1;
                        break;
                    case "NumberPhone":
                        if (ValidationNumberPhone(NumberPhone).Item2)
                            error = ValidationNumberPhone(NumberPhone).Item1;
                        break;
                    case "Mail":
                        if (ValidationMail(Mail).Item2)
                            error = ValidationMail(Mail).Item1;
                        break;
                    case "Password":
                        if (ValidationPassword(Password).Item2)
                            error = ValidationPassword(Password).Item1;
                        break;
                    case "Password2":
                        if (ValidationPassword(Password2).Item2)
                            error = ValidationPassword(Password2).Item1;
                        if (Password != Password2)
                            error = "Пароль не совпадают";
                        break;
                        //    break;
                }
                return error;
            }
        }

        public string Error
        {
            get { throw new NotImplementedException(); }
        }


        #region Validation Methods

        /// <summary>
        /// Метод валидации имени
        /// </summary>
        public (string, bool) ValidationFirstName(string _firstName)
        {
            string regexFirstName = @"^([а-яА-Я]+[\s-]?)+$";
            bool flags;
            if (_firstName != null)
                flags = Regex.IsMatch(_firstName, regexFirstName);
            else
                flags = false;
            if (String.IsNullOrWhiteSpace(_firstName))
            {
                return ("Поле не должно быть пустым", true);
            }
            if (flags == false)    
            {
                return ("Имя должно быть написано кириллицей", true);
            }
            if(_firstName.Length > 30)
                return ("Слишком длинное имя", true);
            else
                return (null, false);
        }


        /// <summary>
        /// Метод валидации фамилии
        /// </summary>
        public (string, bool) ValidationLastName(string _lastName)
        {
            string regexLastName = @"^([а-яА-Я]+[\s-]?)+$";
            if (String.IsNullOrWhiteSpace(_lastName))
            {
                return ("Поле не должно быть пустым", true);
            }
            if (Regex.IsMatch(_lastName, regexLastName) == false)
            {
                return ("Фамилия должно быть написано кириллицей", true);
            }
            if (_lastName.Length > 30)
                return ("Слишком длинная фамилия", true);
            else
                return (null, false);
        }


        /// <summary>
        /// Метод валидации мобильного телефона
        /// </summary>
        public (string, bool) ValidationNumberPhone(string _numberPhone)
        {
            string regexNumberPhone = @"^(33|29|25|44)(\d){7}$";
            bool flags;
            if (_numberPhone != null)
                flags = Regex.IsMatch(_numberPhone, regexNumberPhone);
            else 
                flags = false;
            if (String.IsNullOrWhiteSpace(_numberPhone))
            {
                return ("Поле не должно быть пустым", true);
            }
            if (flags == false)
            {
                return ("Неправильно веден номер", true);
            }
            if(_numberPhone.Length != 9)
            {
                return ("Длина телефона должна быть 9 символов", true);
            }
            else
                return (null, false);
        }


        /// <summary>
        /// Метод валидации электронной почты
        /// </summary>
        public (string, bool) ValidationMail(string _mail)
        {
            string regexMail = @"^[-A-z0-9_.]+@([A-z0-9][-A-z0-9]+\.)+[A-z]{2,4}$";
            bool flags;
            if (_mail != null)
                flags = Regex.IsMatch(_mail, regexMail);
            else
                flags = false;
            if (String.IsNullOrWhiteSpace(Mail))
            {
                return ("Поле не должно быть пустым", true);
            }
            if (flags == false)
            {
                return ("Неправильно введена почта", true);
            }
            else
                return (null, false);
        }


        public (string, bool) ValidationPassword(string _password)
        {
            string regexPass = @"^[a-zA-Z0-9]+$";
            bool flags;
            if (_password != null)
                flags = Regex.IsMatch(_password, regexPass);
            else
                flags = false;
            if (String.IsNullOrWhiteSpace(_password))
            {
                return ("Поле не должно быть пустым", true);
            }
            if (flags == false)    
            {
                return ("Пароль может содержать английские буквы и цифры", true);
            }
            if (_password.Length > 20 || _password.Length < 8)
                return ("Длина пароля должна быть от 8 до 20 символов", true);
            else
                return (null, false);
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
