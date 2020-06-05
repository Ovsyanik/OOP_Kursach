using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Kursovaya.ViewModels;

namespace Kursovaya
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Window
    {

        public Main()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel(this);
            this.MaxHeight = SystemParameters.WorkArea.Height;
        }

        
        /// <summary>
        /// Перетаскивает окно 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Border_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
                this.DragMove();
        }


   
    }
}
