using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Kursovaya.Models
{
    class Flat : INotifyPropertyChanged, IDataErrorInfo
    {
        private Byte[] image;
        private int? countRooms;
        private string area;
        private string repair;
        private string price;
        private Address address = new Address();
        private Demands demands = new Demands();
        private int id;
        private Boolean output;
        private string description;
        private string priceMin;
        private string priceMax;
        private string areaMin;
        private string areaMax;
        private User user = new User();
        private DateTime timeAdd;

        public DateTime TimeAdd
        {
            get => timeAdd;
            set
            {
                timeAdd = value;
                OnPropertyChanged("TimaAdd");
            }
        }


        public Address Address
        {
            get => address;
            set
            {
                address = value;
                OnPropertyChanged("Address");
            }
        }

        public User User
        {
            get => user;
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }

        public Boolean Output
        {
            get => output;
            set
            {
                output = value;
                OnPropertyChanged("Output");
            }
        }

        public Demands Demands
        {
            get => demands;
            set
            {
                demands = value;
                OnPropertyChanged("Demands");
            }
        }

        public Byte[] Image
        {
            get => image;
            set
            {
                image = value;
                OnPropertyChanged("Image");
            }
        }

        public int? CountRooms
        {
            get => countRooms;
            set
            {
                countRooms = value;
                OnPropertyChanged("CountRooms");
            }
        }

        public int ID 
        {
            get => id;
            set
            {
                id = value;
                OnPropertyChanged("ID");
            }
        }

        public string Area
        {
            get => area;
            set
            {
                area = value;
                OnPropertyChanged("Area");
            }
        }

        public string AreaMin
        {
            get => areaMin;
            set
            {
                areaMin = value;
                OnPropertyChanged("AreaMin");
            }
        }

        public string AreaMax
        {
            get => areaMax;
            set
            {
                areaMax = value;
                OnPropertyChanged("AreaMax");
            }
        }

        public string Repair
        {
            get => repair;
            set
            {
                repair = value;
                OnPropertyChanged("Repair");
            }
        }

        public string Description
        {
            get => description;
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }

        public string Price
        {
            get => price;
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }

        public string PriceMin
        {
            get => priceMin;
            set
            {
                priceMin = value;
                OnPropertyChanged("PriceMin");
            }
        }

        public string PriceMax
        {
            get => priceMax;
            set
            {
                priceMax = value;
                OnPropertyChanged("PriceMax");
            }
        }

        public string this[string name]
        {
            get
            {
                string error = String.Empty;

                switch (name)
                {
                    case "Area":
                        if (ValidationArea(Area).Item2)
                            error = ValidationArea(Area).Item1;
                        break;
                    case "Price":
                        if (ValidationPrice(Price).Item2)
                            error = ValidationPrice(Price).Item1;
                        break;
                }
                return error;
            }
        }

        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public (string, bool) ValidationArea(string _area)
        {
            if(String.IsNullOrEmpty(_area))
                return ("Поле не должно быть пустым.", true);
            string regexPrice = @"^\d+[\.\,]?\d+$";
            bool flags;
            if (_area != null)
                flags = Regex.IsMatch(_area, regexPrice);
            else
                flags = false;
            if (flags == false)
            {
                return ("Поле может содержать только цифры, точку, запятая", true);
            }
            if (_area.Length > 15)
                return ("Слишком большая площадь", true);
            else
                return (null, false);
        }

        
        /// <summary>
        /// Метод валидирующий количество комнат
        /// </summary>
        public (string, bool) ValidationCountRooms(int? _countRooms)
        {

            if (!_countRooms.HasValue)
            {
                return ("Поле не должно быть пустым", true);
            }
            if (_countRooms > 5 || _countRooms < 0)
            {
                return ("Ввели некорректное количество комнат", true);
            }
            else
                return (null, false);
        }

        public (string, bool) ValidationPrice(string _price)
        {
            if (String.IsNullOrEmpty(_price))
                return ("Поле не должно быть пустым.", true);
            string regexPrice = @"^\d+[\.\,]?\d+";
            bool flags;
            if (_price != null)
                flags = Regex.IsMatch(_price, regexPrice);
            else
                flags = false;
            if (flags == false)
            {
                return ("Поле может содержать только цифры , точку, запятая", true);
            }
            if (_price.Length > 15)
                return ("Слишком большая Цена", true);
            else
                return (null, false);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
