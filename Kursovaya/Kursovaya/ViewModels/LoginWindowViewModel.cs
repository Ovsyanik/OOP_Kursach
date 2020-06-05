using System.Windows;
using Kursovaya.Pages;
using System.Windows.Controls;
using System.Windows.Input;

namespace Kursovaya.ViewModels
{
    class LoginWindowViewModel : ViewModelBase
    {
        public Page registration;
        public Page autorization;
        private Page currentPage;
        public Page CurrentPage
        {
            get => currentPage;
            set
            {
                currentPage = value;
                OnPropertyChanged("CurrentPage");
            }
        }

        public LoginWindowViewModel(AutorizationWindow window)
        {
            autorization = new Autorization(window);
            registration = new Registration(window);
            CurrentPage = autorization;
        }


        #region Команды окна авторизации
        

        public ICommand CloseMainWindow
        {
            get
            {
                return new Command.Command((obj) =>
                {
                    AutorizationWindow window = obj as AutorizationWindow;
                    window.Close();
                });
            }
        }

        public ICommand MainWindowMinimize
        {
            get
            {
                return new Command.Command((obj) =>
                {
                    AutorizationWindow window = obj as AutorizationWindow;
                    window.WindowState = WindowState.Minimized;
                });
            }
        }

        #endregion

    }
}
