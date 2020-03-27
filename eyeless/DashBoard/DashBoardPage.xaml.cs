using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace eyeless.Views
{
    /// <summary>
    /// Логика взаимодействия для DashBoardPage.xaml
    /// </summary>
    public partial class DashBoardPage : Page
    {
        public DashBoardPage()
        {
            InitializeComponent();
        }

        private void UserControl_UnLoaded(object sender, RoutedEventArgs e)
        {
            Act.S1.Stop = true;
            Act.S2.Stop = true;
            Act.S3.Stop = true;
            Act.S4.Stop = true;
            Act.S5.Stop = true;
            Act.S6.Stop = true;
            Act.S7.Stop = true;

        }

    }
}
