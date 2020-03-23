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

        public PartialCircle()
        {
            this.InitializeComponent();
            this.DataContext = this;

            ThreadPool.QueueUserWorkItem((o) =>
            {
                var _speed = 0;
                var _stop = false;
                this.Dispatcher.Invoke(new Action(() => _speed = Speed));
                for (int i = 0; i <= 100; i++)
                {
                    try
                    {
                        this.Dispatcher.Invoke(new Action(() => _stop = Stop));
                    }
                    catch (TaskCanceledException)
                    {

                    }

                    if (_stop)
                    {
                        break;
                    }

                    this.Dispatcher.BeginInvoke((Action)(() =>
                    {
                        this.Percentage = i;
                    }));

                    Thread.Sleep(_speed);
                }

            });

        }


        public static readonly DependencyProperty PercentageProperty =
   DependencyProperty.Register("Percentage", typeof(int),
           typeof(PartialCircle),
           new PropertyMetadata(0));

        public static readonly DependencyProperty SpeedProperty =
   DependencyProperty.Register("Speed", typeof(int),
           typeof(PartialCircle),
           new PropertyMetadata(600));

        public static readonly DependencyProperty StrokeThicknessProperty =
   DependencyProperty.Register("StrokeThickness", typeof(int),
           typeof(PartialCircle),
           new PropertyMetadata(3));

        public static readonly DependencyProperty StopProperty =
   DependencyProperty.Register("Stop", typeof(bool),
           typeof(PartialCircle),
           new PropertyMetadata(false));

        public static readonly DependencyProperty VisibleProperty =
   DependencyProperty.Register("isVisibleEllipse", typeof(Visibility),
           typeof(PartialCircle),
           new PropertyMetadata(Visibility.Collapsed));

        public int StrokeThickness
        {
            get { return (int)GetValue(StrokeThicknessProperty); }
            set { SetValue(StrokeThicknessProperty, value); }
        }


        public int Speed
        {
            get { return (int)GetValue(SpeedProperty); }
            set { SetValue(SpeedProperty, value); }
        }

        public bool Stop
        {
            get { return (bool)GetValue(StopProperty); }
            set { SetValue(StopProperty, value); }
        }

        /// <summary>
        /// Задает процент
        /// </summary>
        public int Percentage
        {
            get { return (int)GetValue(PercentageProperty); }
            set { SetValue(PercentageProperty, value); }

        }

        public Visibility isVisibleEllipse
        {
            get { return (Visibility)GetValue(VisibleProperty); }
            set { SetValue(VisibleProperty, value); }

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
                return new Size(this.radius , this.radius );
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
