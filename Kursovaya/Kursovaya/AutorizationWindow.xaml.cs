using System.Windows;
using System.Windows.Input;
using Kursovaya.ViewModels;

namespace Kursovaya
{
    /// <summary>
    /// Логика взаимодействия для AutorizationWindow.xaml
    /// </summary>
    public partial class AutorizationWindow : Window
    {
        public AutorizationWindow()
        {
            InitializeComponent();
            DataContext = new LoginWindowViewModel(this);
        }
       


        /// <summary>
        /// Перетаскивает окно 
        /// </summary>
        private void Border_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }


    }
}
