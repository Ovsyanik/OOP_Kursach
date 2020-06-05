using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Kursovaya.Models
{
    class Address : INotifyPropertyChanged, IDataErrorInfo
    {
        private string sity;
        private string district;
        private string street;
        private string numberHouse;
        private int? floor;
        private string metro;
        private string floorMin;
        private string floorMax;

        public string this[string name]
        {
            get
            {
                string error = String.Empty;

                switch (name)
                {
                    case "Sity":
                        if (ValidationSity(Sity).Item2)
                            error = ValidationSity(Sity).Item1;
                        break;
                    case "District":
                        if (ValidationDistrict(District).Item2)
                            error = ValidationDistrict(District).Item1;
                        break;
                    case "Street":
                        if (ValidationStreet(Street).Item2)
                            error = ValidationStreet(Street).Item1;
                        break;
                    case "Floor":
                        if (ValidationFloor(Floor).Item2)
                            error = ValidationFloor(Floor).Item1;
                        break;
                    case "NumberHouse":
                        if (ValidationNumberHouse(NumberHouse).Item2)
                            error = ValidationNumberHouse(NumberHouse).Item1;
                        break;
                    case "Metro":
                        if (ValidationMetro(Metro).Item2)
                            error = ValidationMetro(Metro).Item1;
                        break;
                }
                return error;
            }
        }

        /// <summary>
        /// Метод валидирующий этаж
        /// </summary>
        public (string, bool) ValidationFloor(int? _floor)
        {

            if (!_floor.HasValue)
            {
                return ("Поле не должно быть пустым", true);
            }
            if (_floor > 500 || _floor < 0)
            {
                return ("Ввели некорректный этаж", true);
            }
            else
                return (null, false);
        }

        public (string, bool) ValidationFloorMax(string _floor)
        {
            string regexPrice = @"^\d*$";
            bool flags;
            if (_floor != null)
                flags = Regex.IsMatch(_floor, regexPrice);
            else
                flags = false;
            if (flags == false)
            {
                return ("", true);
            }
            if (_floor.Length > 15)
                return ("", true);
            else
                return (null, false);
        }

        /// <summary>
        /// Метод валидирующий номер дома
        /// </summary>
        public (string, bool) ValidationNumberHouse(string _numberHouse)
        {
            string regexNumberHouse = @"^\d+[а-яА-я]?$";
            bool flags;
            if (_numberHouse != null)
                flags = Regex.IsMatch(_numberHouse, regexNumberHouse);
            else
                flags = false;
            if (String.IsNullOrWhiteSpace(_numberHouse))
            {
                return ("Поле не должно быть пустым", true);
            }
            if(flags == false)
            {
                return ("Допускаются цифры, русская буква", true);
            }
            if (_numberHouse.Length > 4 )
            {
                return ("Длинане может быть больше 4 символов", true);
            }
            else
                return (null, false);
        }

        /// <summary>
        /// Метод валидирующий город
        /// </summary>
        public (string, bool) ValidationSity(string _sity)
        {
            string regexSity = @"^([а-яА-ЯёЁ]+[\s-]?)+$";
            bool flags;
            if (_sity != null)
                flags = Regex.IsMatch(_sity, regexSity);
            else
                flags = false;
            if (String.IsNullOrWhiteSpace(_sity))
            {
                return ("Поле не должно быть пустым", true);
            }
            if (flags == false)
            {
                return ("Допускается русский язык, пробел, -", true);
            }
            if (_sity.Length > 20 || _sity.Length < 3)
            {
                return ("Длина не может быть меньше 3 символов и больше 20 символов", true);
            }
            else
                return (null, false);
        }

        /// <summary>
        /// Метод валидирующий Метро
        /// </summary>
        public (string, bool) ValidationMetro(string _metro)
        {
            string regexMetro = @"^([а-яА-ЯёЁ]+[\s-.]?)+$";
            bool flags;
            if (_metro != null)
                flags = Regex.IsMatch(_metro, regexMetro);
            else
                flags = false;
            if (String.IsNullOrWhiteSpace(_metro))
            {
                return ("Поле не должно быть пустым", true);
            }
            if (flags == false)
            {
                return ("Допускается русский язык, пробел, -", true);
            }
            if (_metro.Length < 3 || _metro.Length > 20)
            {
                return ("Длина не может быть меньше 3 символов и больше 20 символов", true);
            }
            else
                return (null, false);
        }

        /// <summary>
        /// Метод валидирующий район
        /// </summary>
        public (string, bool) ValidationDistrict(string _district)
        {
            string regexDistrict = @"^([а-яА-ЯёЁ]+[\s-]?)+$";
            bool flags;
            if (_district != null)
                flags = Regex.IsMatch(_district, regexDistrict);
            else
                flags = false;
            if (String.IsNullOrWhiteSpace(_district))
            {
                return ("Поле не должно быть пустым", true);
            }
            if (flags == false)
            {
                return ("Допускается русский язык, пробел, -", true);
            }
            if (_district.Length > 20 || _district.Length < 3)
            {
                return ("Длина не может быть меньше 3 символов и больше 20 символов", true);
            }
            else
                return (null, false);
        }

        /// <summary>
        /// Метод валидирующий улицу
        /// </summary>
        public (string, bool) ValidationStreet(string _street)
        {
            string regexStreet = @"^([а-яА-Я]+[\s-]?)+$";
            bool flags;
            if (_street != null)
                flags = Regex.IsMatch(_street, regexStreet);
            else
                flags = false;
            if (String.IsNullOrWhiteSpace(_street))
            {
                return ("Поле не должно быть пустым", true);
            }
            if (flags == false)
            {
                return ("Допускается русский язык, пробел, -", true);
            }
            if (_street.Length > 20 || _street.Length < 3)
            {
                return ("Длина не может быть меньше 3 символов и больше 20 символов", true);
            }
            else
                return (null, false);
        }


        public string Sity
        {
            get => sity;
            set
            {
                sity = value;
                OnPropertyChanged("Sity");
            }
        }

        public string District
        {
            get => district;
            set
            {
                district = value;
                OnPropertyChanged("District");
            }
        }

        public string Street
        {
            get => street;
            set
            {
                street = value;
                OnPropertyChanged("Street");
            }
        }

        public string NumberHouse
        {
            get => numberHouse;
            set
            {
                numberHouse = value;
                OnPropertyChanged("NumberHouse");
            }
        }

        public int? Floor
        {
            get => floor;
            set
            {
                floor = value;
                OnPropertyChanged("Floor");
            }
        }

        public string FloorMax
        {
            get => floorMax;
            set
            {
                floorMax = value;
                OnPropertyChanged("FloorMax");
            }
        }

        public string FloorMin
        {
            get => floorMin;
            set
            {
                floorMin = value;
                OnPropertyChanged("FloorMin");
            }
        }

        public string Metro
        {
            get => metro;
            set
            {
                metro = value;
                OnPropertyChanged("Metro");
            }
        }

        public string Error => throw new System.NotImplementedException();

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
