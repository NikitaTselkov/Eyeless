using DevExpress.Mvvm;
using eyeless.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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

        public MainViewModel()
        {

            GoToStartPage = new RelayCommand(PathToStartPage);

            GoToGamePage = new RelayCommand(PathToGamePage);
            
        }


        public void PathToStartPage(object param)
        {
            Navigate("Views/StartGame.xaml");
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
