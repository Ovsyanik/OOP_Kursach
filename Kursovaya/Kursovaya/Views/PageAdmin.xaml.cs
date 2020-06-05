using System.Windows.Controls;
using Kursovaya.ViewModels;

namespace Kursovaya.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAdmin.xaml
    /// </summary>
    public partial class PageAdmin : Page
    {
        public PageAdmin()
        {
            InitializeComponent();
            DataContext = new AdminPageVIewModel(this);
        }
    }
}
