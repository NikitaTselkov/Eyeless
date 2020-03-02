using DevExpress.Mvvm;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace eyeless.ViewModels
{
    public class MainViewModel : Navigation.NavigateViewModel
    {
        Models.MainModel mainModel = new Models.MainModel();

        public bool IsPressed { get; set; } = true;

        public string TextBoxT { get { return mainModel.MethodDivide(); } set { } }

        public int Score { get; set; } 

        public string Level { get; set; } = "Level 90";

        public char[] TextChar { get; set; }
     
        public string Test { get; set; }


        public ICommand GoToGamePage
        {
            get 
            {
                return new RelayCommand(() =>
                {
                    Navigate("Views/GamePage.xaml");
                    IsPressed = false;
                   
                });
            }
        }

    }
}
