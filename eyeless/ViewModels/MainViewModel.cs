using DevExpress.Mvvm;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Input;

namespace eyeless.ViewModels
{
    public class MainViewModel : Navigation.NavigateViewModel
    {
        Models.MainModel mainModel = new Models.MainModel();

        public string TextBoxT { get { return mainModel.Divide(); } set { } }

        public int Score { get; set; } 

        public string Level { get { return mainModel.LevelControll(Score, 0); }  set { } }

        public char[] TextChar { get; set; }
     
        public string Test { get; set; }

        public int Time { get; set; }

        public ICommand GoToGamePage
        {
            get 
            {
                return new RelayCommand(() =>
                {
                    Navigate("Views/GamePage.xaml");

                    ThreadPool.QueueUserWorkItem((o) =>
                    {
                        for (int i = 10; i <= 100; i++)
                        {

                            Time = i;

                            Thread.Sleep(600);

                        }
                    });
                });
            }
        }

    }
}
