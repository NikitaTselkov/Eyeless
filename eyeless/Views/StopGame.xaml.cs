using eyeless.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Windows;
using System.Windows.Controls;


namespace eyeless.Views
{
    /// <summary>
    /// Логика взаимодействия для StopGame.xaml
    /// </summary>
    [DataContract]
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
            set { SetValue(LevelProperty, value); }
        }

        [DataMember]
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

            var jsonFoematter = new DataContractJsonSerializer(typeof(List<int>));

            List<int> Scores = new List<int>();

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
                                Scores.Add(Item);
                            }
                        }
                    }
                }

            }
            Scores.Add(Score);

            using (var file = new FileStream("Score.json", FileMode.OpenOrCreate))
            {
                jsonFoematter.WriteObject(file, Scores);
            }
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
