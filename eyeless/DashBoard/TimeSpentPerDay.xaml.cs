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
using LiveCharts;
using LiveCharts.Wpf;

namespace eyeless.DashBoard
{
    /// <summary>
    /// Логика взаимодействия для TimeSpentPerDay.xaml
    /// </summary>
    public partial class TimeSpentPerDay : UserControl
    {

        public int Easy { get; set; }

        public int Medium { get; set; }

        public int Hard { get; set; }

        public TimeSpentPerDay()
        {
            InitializeComponent();

            DataContext = this;

            BrushConverter brushConverter = new BrushConverter();

            Easy = 64;

            Medium = 21;

            Hard = 15;

            SeriesCollection piechartData = new SeriesCollection
            {

                new PieSeries
                {
                    Title = "Hard",
                    Values = new ChartValues<double> {Hard},
                    DataLabels = false,
                    Stroke = brushConverter.ConvertFrom("#2CB9E6") as Brush,
                    Fill = brushConverter.ConvertFrom("#2CB9E6") as Brush
                },
                new PieSeries
                {
                    Title = "Mdium",
                    Values = new ChartValues<double> {Medium},
                    DataLabels = false,
                    Stroke = brushConverter.ConvertFrom("#EE98D0") as Brush,
                    Fill = brushConverter.ConvertFrom("#EE98D0") as Brush
                },
                new PieSeries
                {
                    Title = "Easy",
                    Values = new ChartValues<double> {Easy},
                    DataLabels = false,
                    Stroke = brushConverter.ConvertFrom("#7120EA") as Brush,
                    Fill = brushConverter.ConvertFrom("#7120EA") as Brush
                }
            };

            Pie.Series = piechartData;

        }
    }
}
