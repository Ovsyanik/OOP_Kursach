using System.Windows.Controls;
using Kursovaya.ViewModels;
using Kursovaya.Models;

namespace Kursovaya.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddFlat.xaml
    /// </summary>
    public partial class AddFlat : Page
    {
        public AddFlat(Main main)
        {
            InitializeComponent();
            DataContext = new AddFlatViewModel(main);
        }
    }
}
