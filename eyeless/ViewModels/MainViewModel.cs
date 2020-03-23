using DevExpress.Mvvm;
using eyeless.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Input;

namespace eyeless.ViewModels
{
    public class MainViewModel : Navigation.NavigateViewModel, INotifyPropertyChanged
    {
        Models.MainModel mainModel = new Models.MainModel();      

        public string TextBoxT { get; set; }

        public int Score { get; set; } 

        public int Level { get {return mainModel.LevelControll(Score, 0); } set { } }

        public char[] TextChar { get; set; }
     
        public string Test { get; set; }

        public RelayCommand GoToStartPage { get; set; }

        public RelayCommand GoToGamePage { get; set; }

        public RelayCommand GoToDashBoardPage { get; set; }

        public MainViewModel()
        {
            GoToDashBoardPage = new RelayCommand(PathToDashBoard);

            GoToStartPage = new RelayCommand(PathToStartPage);

            GoToGamePage = new RelayCommand(PathToGamePage);
            
        }

        private bool _IsPressed;
        public bool IsPressed
        {
            get { return _IsPressed; }
            set
            {
                _IsPressed = value;
            }

        }

        public ICommand PressButton
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    this.IsPressed = mainModel.press(IsPressed);
                });
            }
        }


        public void PathToStartPage(object param)
        {
            Navigate("Views/StartGame.xaml");
        }

        public void PathToDashBoard(object param)
        {
            Navigate("DashBoard/DashBoardPage.xaml");
        }

        public void PathToGamePage(object param)
        {

            switch (param as string)
            {
                case "Easy":
                    Navigate("Views/EasyGamePage.xaml");
                    break;
                case "Medium":
                    Navigate("Views/MediumGamePage.xaml");
                    break;
                case "Hard":
                    Navigate("Views/HardGamePage.xaml");
                    break;
            }
            Console.WriteLine($"Clicked: {param as string}");

        }

        


        

    }
}
