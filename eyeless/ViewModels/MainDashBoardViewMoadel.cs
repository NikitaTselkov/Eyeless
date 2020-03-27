﻿
using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace eyeless.ViewModels
{
    public class MainDashBoardViewMoadel : Navigation.NavigateViewModel, INotifyPropertyChanged
    {
        Models.MainModel mainModel = new Models.MainModel();

        public int Score { get; set; }

        public int Time { get; set; }

        public int Level { get; set; }

        public int TodayScore { get; set; }

        public int TodayTime { get; set; }

        public int TodayLevel { get; set; }

        public MainDashBoardViewMoadel()
        {
            NavigationSetup2();
        }


        void NavigationSetup2()
        {
            Messenger.Default.Register<Navigation.NavigateArgs2>(this, (x) =>
            {
                Score = x.Score;
                Time = x.Time;
                Level = x.Level;

                TodayScore += x.Score;
                TodayTime += x.Time;
                TodayLevel += x.Level;
            });
        }

        private bool _IsPressed2;
        public bool IsPressed2
        {
            get { return _IsPressed2; }
            set
            {
                _IsPressed2 = value;
            }

        }

        public ICommand PressButton2
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    this.IsPressed2 = mainModel.press(IsPressed2);
                });
            }
        }

    }
}
