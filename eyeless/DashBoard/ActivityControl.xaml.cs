using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Логика взаимодействия для ActivityControl.xaml
    /// </summary>
    public partial class ActivityControl : UserControl, INotifyPropertyChanged
    {
        public ActivityControl()
        {
            InitializeComponent();
            this.DataContext = this;

            ThreadPool.QueueUserWorkItem((o) =>
            {
                var _score = 0;
                var _time = 0;
                var _level = 0;
                var i = 320;
                var _stop = false;

                this.Dispatcher.Invoke(new Action(() => _score = 320 - Score));
                this.Dispatcher.Invoke(new Action(() => _time = 320 - Time));
                this.Dispatcher.Invoke(new Action(() => _level = 320 - Level));

                int[] vs = new[] { _level, _score, _time };

                while (true)
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

                    if (i >= _time)
                    {
                        this.Dispatcher.BeginInvoke((Action)(() =>
                        {
                            this.Time = i;
                        }));
                    }

                    if (i >= _score)
                    {
                        this.Dispatcher.BeginInvoke((Action)(() =>
                        {
                            this.Score = i;
                        }));
                    }

                    if (i >= _level)
                    {
                        this.Dispatcher.BeginInvoke((Action)(() =>
                        {
                            this.Level = i;
                        }));
                    }

                    if (vs.Min() == i)
                    {
                        break;
                    }

                    i--;

                    Thread.Sleep(5);
                }

            });
        }

        public static readonly DependencyProperty ScoreProperty =
   DependencyProperty.Register("Score", typeof(int),
           typeof(ActivityControl),
           new PropertyMetadata(0));

        public static readonly DependencyProperty TimeProperty =
   DependencyProperty.Register("Time", typeof(int),
           typeof(ActivityControl),
           new PropertyMetadata(0));

        public static readonly DependencyProperty LevelProperty =
   DependencyProperty.Register("Level", typeof(int),
           typeof(ActivityControl),
           new PropertyMetadata(0));

        public static readonly DependencyProperty StopProperty =
   DependencyProperty.Register("Stop", typeof(bool),
           typeof(ActivityControl),
           new PropertyMetadata(false));

        public int Score
        {
            get { return (int)GetValue(ScoreProperty); }
            set { SetValue(ScoreProperty, value); }
        }

        public int Time
        {
            get { return (int)GetValue(TimeProperty); }
            set { SetValue(TimeProperty, value); }
        }

        public int Level
        {
            get { return (int)GetValue(LevelProperty); }
            set { SetValue(LevelProperty, value); }
        }

        public bool Stop
        {
            get { return (bool)GetValue(StopProperty); }
            set { SetValue(StopProperty, value); }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
