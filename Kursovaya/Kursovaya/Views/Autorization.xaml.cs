using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Data;
using Kursovaya.ViewModels;


namespace Kursovaya.Pages
{
    /// <summary>
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : Page
    {

        public Autorization(AutorizationWindow window)
        {
            InitializeComponent();
            DataContext = new AutorizationViewModel(window);
        }

    }
}
