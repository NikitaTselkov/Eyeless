﻿using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eyeless.Navigation
{
    public class NavigateViewModel : ViewModelBase
    {
        public NavigateViewModel()
        {

        }

        public string Title { get; set; }
        public void Navigate(string url)
        {
            Messenger.Default.Send<NavigateArgs>(new NavigateArgs(url));
        }
    }
}
