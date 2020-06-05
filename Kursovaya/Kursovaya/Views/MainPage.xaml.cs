using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Kursovaya.ViewModels;

namespace Kursovaya.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage(Main main)
        {
            InitializeComponent();

            DataContext = new MainPageViewModel(main);
        }
    }
}
