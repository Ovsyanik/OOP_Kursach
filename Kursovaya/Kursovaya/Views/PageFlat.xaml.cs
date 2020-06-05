using System.Windows.Controls;
using Kursovaya.ViewModels;

namespace Kursovaya.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageFlat.xaml
    /// </summary>
    public partial class PageFlat : Page
    {
        public PageFlat()
        {
            InitializeComponent();
            DataContext = new PageFlatViewModel();
        }
    }
}
