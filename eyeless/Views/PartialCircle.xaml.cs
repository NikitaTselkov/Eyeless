    using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace eyeless.Views
{
    /// <summary>
    /// Логика взаимодействия для PartialCircle.xaml
    /// </summary>
    public partial class PartialCircle : UserControl, INotifyPropertyChanged
    {
        private double radius = 100;

        //private double percentage = 60;


        public PartialCircle()
        {
            this.InitializeComponent();
            this.DataContext = this;

            ThreadPool.QueueUserWorkItem((o) =>
            {
                for (int i = 0; i <= 100; i++)
                {
                    this.Dispatcher.BeginInvoke((Action)(() =>
                    {
                        this.Percentage = i;

                    }));

                    Thread.Sleep(600);
                }
            });
        }

        public static readonly DependencyProperty PercentageProperty =
   DependencyProperty.Register("Percentage", typeof(double),
           typeof(PartialCircle),
           new PropertyMetadata(4.6, new PropertyChangedCallback(OnSettingsChanged)));



        private static void OnSettingsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (PartialCircle)d;
            var newSettings = (double)e.NewValue;
            control.Percentage = newSettings;


        }

            /// <summary>
            /// Задает процент
            /// </summary>
        public double Percentage
        {
            get { return (double)GetValue(PercentageProperty); }
            set
            {

                SetValue(PercentageProperty, value);
                //this.percentage = value;
               // this.OnPropertyChanged();

                //this.OnPropertyChanged("Angle");
                //this.OnPropertyChanged("IsLarge");
                //this.OnPropertyChanged("EndPoint");
            }

            //get { return this.percentage; }
            //set
            //{
            //    this.percentage = value;
            //    this.OnPropertyChanged();

            //    this.OnPropertyChanged("Angle");
            //    this.OnPropertyChanged("IsLarge");
            //    this.OnPropertyChanged("EndPoint");

            //}
        }

        /// <summary>
        /// Радиус закругления
        /// </summary>
        public double Radius
        {
            get
            {
                return this.radius;
            }

            set
            {
                this.radius = value;
                this.OnPropertyChanged();

                this.OnPropertyChanged("StartPoint");
                this.OnPropertyChanged("Center");
                this.OnPropertyChanged("Size");
                this.OnPropertyChanged("EndPoint");
            }
        }

        /// <summary>
        /// Координаты центра окружности
        /// </summary>
        public Point Center
        {
            get
            {
                return new Point(this.Width / 2, this.Height / 2);
            }
        }

        /// <summary>
        /// Gets the starting point of the path
        /// </summary>
        public Point StartPoint
        {
            get
            {
                return new Point(this.Center.X, this.Center.Y - this.radius);
            }
        }

        /// <summary>
        /// Размеры сегмента
        /// </summary>
        public Size Size
        {
            get
            {
                return new Size(this.radius, this.radius);
            }
        }

        /// <summary>
        /// Угол, на котором необходимо остановиться
        /// </summary>
        public double Angle
        {
            get
            {
                
                   return 359.99 * Percentage / 100;
                
                
            }
        }

        /// <summary>
        /// Корректировка при переходе через 180 градусов
        /// </summary>
        public bool IsLarge
        {
            get
            {
                return (this.Percentage > 50);
            }
        }

        /// <summary>
        /// Вычисление конечной точки
        /// </summary>
        public Point EndPoint
        {
            get
            {
                // Pi correction
                var angle = this.Angle - 90;
                return this.CalculateCircleCoordinates(this.Center, this.radius, angle);
            }
        }

        private Point CalculateCircleCoordinates(Point center, double radius, double angle)
        {
            var radians = (angle * Math.PI) / 180;
            return new Point(center.X + radius * Math.Cos(radians), center.Y + radius * Math.Sin(radians));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
