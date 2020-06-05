using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Kursovaya.Pages;
using Kursovaya.Models;

namespace Kursovaya.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {
        private Page addFlat;
        public Page mainPage;
        private Page pageAdmin;
        public Page pageDetailsFlat;

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
        Main main;

        private string title = "Главная";
        public string Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }

        public MainWindowViewModel(Main main)
        {
            this.main = main;
            addFlat = new AddFlat(main);
            mainPage = new MainPage(main);
            pageAdmin = new PageAdmin();
            pageDetailsFlat = new PageFlat();

            CurrentPage = mainPage;
        }

        #region Command

        public Command.Command OpenAddFlat => new Command.Command((obj) => { CurrentPage = addFlat; Title = "Добавление квартиры"; });

        public Command.Command OpenMainPage => new Command.Command((obj) => { CurrentPage = mainPage; Title = "Главная"; });

        public Command.Command OpenPageAdmin => new Command.Command((obj) => { CurrentPage = pageAdmin; Title = "Администрирование"; });

        public Command.Command CloseMainWindow
        {
            get
            {
                return new Command.Command((obj) =>
                {
                    Main window = obj as Main;
                    window.Close();
                });
            }
        }

        public ICommand MainWindowMaximize
        {
            get
            {
                return new Command.Command((obj) =>
                {
                    Main window = obj as Main;
                    if (window.WindowState == WindowState.Maximized)
                    {
                        window.WindowState = WindowState.Normal;
                    }
                    else
                        window.WindowState = WindowState.Maximized;
                });
            }
        }

        public ICommand MainWindowMinimize
        {
            get
            {
                return new Command.Command((obj) =>
                {
                    Main window = obj as Main;
                    window.WindowState = WindowState.Minimized;
                });
            }
        }

        public ICommand ChangeUser
        {
            get
            {
                return new Command.Command((obj) =>
                {
                    AutorizationWindow window = new AutorizationWindow();
                    window.Show();
                    main.Close();

                });
            }
        }

        #endregion


    }
}
