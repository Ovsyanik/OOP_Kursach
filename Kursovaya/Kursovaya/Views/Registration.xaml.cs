using System.Windows.Controls;
using Kursovaya.ViewModels;

namespace Kursovaya.Pages
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public Registration(AutorizationWindow window)
        {
            InitializeComponent();
            DataContext = new RegistrationViewModel(window);
        }
    }
}
