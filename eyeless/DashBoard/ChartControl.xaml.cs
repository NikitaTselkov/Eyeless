using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace eyeless.DashBoard
{
    /// <summary>
    /// Логика взаимодействия для ChartControl.xaml
    /// </summary>
    public partial class ChartControl : UserControl, INotifyPropertyChanged
    {
        public ChartControl()
        {
            InitializeComponent();

            this.DataContext = this;
            List<Line> lines = new List<Line>();

            Random random = new Random(Guid.NewGuid().ToByteArray().Sum(s => s));

            var x1 = 0;
            var x2 = 0;
            var y1 = 420;
            var y2 = 140;
            var rndValue = 0;
            double oldValueY = 0.0;
            Myiterator = 12;


            for (var i = 0; i < Myiterator; i++)
            {
                rndValue = random.Next(140, 420);

                Line line = new Line();
                line.X1 = x1 += 145;
                line.X2 = x2 += 145;
                line.Y1 = y1;
                line.Y2 = y2;
                line.Style = (Style)FindResource("LineStyle");


                Line ellipse = new Line();
                ellipse.Style = (Style)FindResource("EllipseW");
                ellipse.X1 = line.X1;
                ellipse.X2 = line.X2;
                ellipse.Y1 = rndValue;
                ellipse.Y2 = rndValue;

                if (oldValueY != 0.0)
                {
                    Line line1 = new Line();
                    line1.Style = (Style)FindResource("LineConect");
                    line1.X1 = line.X1 - 145;
                    line1.X2 = ellipse.X1;
                    line1.Y1 = oldValueY;
                    line1.Y2 = ellipse.Y2;

                    Grid.Children.Add(line1);
                    Grid.SetZIndex(line1, 1);
                }

                oldValueY = ellipse.Y1; 

                //lines.Add(ellipse);

                Grid.Children.Add(ellipse);
                Grid.SetZIndex(ellipse, 2);
                Grid.Children.Add(line);
                

            }

            
        }

        public double Myiterator { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
