using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Json;
using System.Windows;
using System.Windows.Controls;
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

            List<int> Values = new List<int>();

            var jsonFoematter = new DataContractJsonSerializer(typeof(List<int>));

            if (File.Exists("Score.json"))
            {

                using (var file = new FileStream("Score.json", FileMode.Open))
                {
                    if (file != null)
                    {
                        var values = jsonFoematter.ReadObject(file) as List<int>;

                        if (values != null)
                        {
                            foreach (var Item in values)
                            {
                                Values.Add(-1 * (Item / 5) + 420);
                            }
                        }
                    }
                }
            }
            var x1 = 0;
                var x2 = 0;
                var y1 = 420;
                var y2 = 140;
                var Value = 0;
                double oldValueY = 0.0;
                Myiterator = Values.Count;

                for (var i = 0; i < Myiterator; i++)
                {
                    Value = Values[i];

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
                    ellipse.Y1 = Value;
                    ellipse.Y2 = Value;

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

                    Grid.Children.Add(ellipse);
                    Grid.SetZIndex(ellipse, 2);
                    Grid.Children.Add(line);


                }
            //}

        }

        public int Myiterator { get; set; }

        public static readonly DependencyProperty ScoreProperty =
   DependencyProperty.Register("Score", typeof(int),
           typeof(ChartControl),
           new PropertyMetadata(0));

        public int Score
        {
            get { return (int)GetValue(ScoreProperty); }
            set { SetValue(ScoreProperty, value); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
