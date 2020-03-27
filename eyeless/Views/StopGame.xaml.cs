using eyeless.Models;
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

namespace eyeless.Views
{
    /// <summary>
    /// Логика взаимодействия для StopGame.xaml
    /// </summary>
    public partial class StopGame : UserControl, INotifyPropertyChanged
    {
        Navigation.NavigateViewModel NavigateViewModel = new Navigation.NavigateViewModel();
        

        public static readonly DependencyProperty TimeProperty =
  DependencyProperty.Register("Time", typeof(int),
          typeof(StopGame),
          new FrameworkPropertyMetadata(0));

        public static readonly DependencyProperty LevelProperty =
   DependencyProperty.Register("Level", typeof(int),
           typeof(StopGame),
          new FrameworkPropertyMetadata(0));

        public static readonly DependencyProperty ScoreProperty =
   DependencyProperty.Register("Score", typeof(int),
           typeof(StopGame),
           new FrameworkPropertyMetadata(0));


        public int Level
        {
            get { return (int)GetValue(LevelProperty); }
            set{  SetValue(LevelProperty, value);
                //this.OnPropertyChanged("Level");
            }
        }

        public int Score
        {
            get { return (int)GetValue(ScoreProperty); }
            set { SetValue(ScoreProperty, value);
               // this.OnPropertyChanged("Score");
            }
        }

        public int Time
        {
            get { return (int)GetValue(TimeProperty); }
            set { SetValue(TimeProperty, value);
               // this.OnPropertyChanged("Time");
            }
        }

        public StopGame()
        {
            InitializeComponent();
            this.DataContext = this;
            
        }

        public RelayCommand GoToDashBoardPage { get; set; }

        private void Continue_Click(object sender, RoutedEventArgs e)
        {
            StopPanel.Visibility = Visibility.Collapsed;
            NavigateViewModel.SendData(Score, Time, Level);
            GoToDashBoardPage = new RelayCommand(PathToDashBoard);  
        }

        private void PathToDashBoard(object param)
        {
           NavigateViewModel.Navigate("DashBoard/DashBoardPage.xaml");
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
