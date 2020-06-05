using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kursovaya.Models;
using System.Windows;

namespace Kursovaya.ViewModels
{
    class PageFlatViewModel : ViewModelBase
    {
        private Flat currentFlat;
        public Flat CurrentFlat
        {
            get => currentFlat;
            set
            {
                currentFlat = value;
                OnPropertyChanged("CurrentFlat");
            }
        }

        public PageFlatViewModel()
        {
            CurrentFlat = new Flat();
        }
    }
}
