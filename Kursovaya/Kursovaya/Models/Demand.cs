using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Kursovaya.Models
{
    class Demands : INotifyPropertyChanged
    {
        private bool waterHeater;
        private bool washer;
        private bool microwave;
        private bool refrigicator;
        private bool internet;
        private bool tv;
        private string tvText;
        private string waterHeaterText;
        private string washerText;
        private string microwaveText;
        private string refrigicatorText;
        private string internetText;

        public bool WaterHeater
        {
            get => waterHeater;
            set
            {
                waterHeater = value;
                OnPropertyChanged("WaterHeater");
            }
        }

        public bool Washer
        {
            get => washer;
            set
            {
                washer = value;
                OnPropertyChanged("Washer");
            }
        }

        public bool Microwave
        {
            get => microwave;
            set
            {
                microwave = value;
                OnPropertyChanged("Microwave");
            }
        }

        public bool Refrigicator
        {
            get => refrigicator;
            set
            {
                refrigicator = value;
                OnPropertyChanged("Refrigicator");
            }
        }

        public bool Internet
        {
            get => internet;
            set
            {
                internet = value;
                OnPropertyChanged("Internet");
            }
        }

        public bool TV
        {
            get => tv;
            set
            {
                tv = value;
                OnPropertyChanged("TV");
            }
        }

        public string TVText
        {
            get => tvText;
            set
            {
                tvText = value;
                OnPropertyChanged("TVText");
            }
        }

        public string WaterHeaterText
        {
            get => waterHeaterText;
            set
            {
                waterHeaterText = value;
                OnPropertyChanged("WaterHeaterText");
            }
        }

        public string WasherText
        {
            get => washerText;
            set
            {
                washerText = value;
                OnPropertyChanged("WasherText");
            }
        }

        public string MicrowaveText
        {
            get => microwaveText;
            set
            {
                microwaveText = value;
                OnPropertyChanged("MicrowaveText");
            }
        }

        public string RefrigicatorText
        {
            get => refrigicatorText;
            set
            {
                refrigicatorText = value;
                OnPropertyChanged("RefrigicatorText");
            }
        }

        public string InternetText
        {
            get => internetText;
            set
            {
                internetText = value;
                OnPropertyChanged("InternetText");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
