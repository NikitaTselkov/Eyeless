using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace eyeless.ViewModels
{
    public class MainViewModel : ViewModelBase
    {




        public ICommand GoToGamePage
        {
            get 
            {
                return new RelayCommand(() =>
                {

                });
            }
        }

    }
}
