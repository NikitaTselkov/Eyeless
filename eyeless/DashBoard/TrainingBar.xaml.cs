using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace eyeless.DashBoard
{
    /// <summary>
    /// Логика взаимодействия для TrainingBar.xaml
    /// </summary>
    public partial class TrainingBar : UserControl
    {
        public TrainingBar()
        {
            InitializeComponent();

            ThreadPool.QueueUserWorkItem((o) =>
            {
                var _percentage = 0;
                this.Dispatcher.Invoke(new Action(() => _percentage = Convert.ToInt32(HelpLabel.Content) / 18));
                for (int i = 0; i <= _percentage; i++)
                {
                    this.Dispatcher.BeginInvoke((Action)(() =>
                    {
                        Circle.Percentage = i;
                    }));

                    Thread.Sleep(30);
                }

            });
        }

    }
}
