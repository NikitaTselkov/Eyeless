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

namespace eyeless.Views
{
    /// <summary>
    /// Логика взаимодействия для HardGamePage.xaml
    /// </summary>
    public partial class HardGamePage : Page
    {
        public HardGamePage()
        {
            InitializeComponent();
            TextBox1.Focus();
            Lab.Content = 0;
            MainTextBox.Text = MainTextTest();
            Chars = CreateCharArray();
  
        }

        private Random rnd = new Random(Guid.NewGuid().ToByteArray().Sum(s => s));

        public char[] Chars { get; set; }

        private int Number { get; set; }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (GException.Visibility == Visibility.Collapsed)
            {
                Number += 1;

                if (clock.Percentage == 100 || Chars.Length <= Number)
                {
                    if(clock.Percentage != 100)
                    {
                        clock.Stop = true;
                    }
                    Stop.Visibility = Visibility.Visible;
                    
                }
                else
                {


                    var BrushConverter = new BrushConverter();
                    if (MainTextBox.Text.IndexOf(' ') - 1 == 0)
                    {
                        Delet(3);
                    }

                    if (Chars[Number - 1].ToString() == e.Key.ToString())
                    {

                        Delet(1);
                        MainTextBox.Foreground = BrushConverter.ConvertFrom("#5B5B3A") as Brush;

                        ScoreControll(1);

                        Console.WriteLine(e.Key.ToString());
                    }
                    else
                    {
                        GException.Visibility = Visibility.Visible;
                        GException.letterLabel.Content = Randomletter(rnd);
                        ThreadPool.QueueUserWorkItem((o) =>
                        {
                            for (int i = 0; i <= 100; i++)
                            {
                                this.Dispatcher.BeginInvoke((Action)(() =>
                                {
                                    GException.clock2.Percentage = i;

                                    if (GException.clock2.Percentage == 100)
                                    {
                                        GException.Visibility = Visibility.Collapsed;
                                        fine();
                                    }

                                }));

                                Thread.Sleep(15);

                                if (GException.Visibility == Visibility.Collapsed)
                                {
                                    break;
                                }
                            }
                        });

                        MainTextBox.Foreground = BrushConverter.ConvertFrom("#3B2D13") as Brush;
                        Delet(1);
                        ScoreControll(-2);
                    }

                }
            }
            else
            {
                if (GException.letterLabel.Content.ToString() != e.Key.ToString())
                {
                    fine();
                }

                GException.Visibility = Visibility.Collapsed;

            }
                    
        }

        private string Randomletter(Random random)
        {
            char[] _letter = { 'Q', 'W', 'E', 'R', 'T', 'Y', 'U', 'I', 'O', 'P', 'A', 'S', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'Z', 'X', 'C', 'V', 'B', 'N', 'M' };

            return _letter[random.Next(0, 25)].ToString();

        }

        private void fine()
        {
            Lab.Content = Convert.ToInt32(Lab.Content) - 20;
        }

        private void ScoreControll(int Add)
        {
            Lab.Content = Convert.ToInt32(Lab.Content) + Add * 3;
        }

        private void Delet(int count)
        {
            if (MainTextBox.Text != string.Empty)
            {
                MainTextBox.Text = MainTextBox.Text.Remove(0, count);
            }
        }

        private char[] CreateCharArray()
        {
            var text = MainTextBox.Text.ToString().ToUpper();
            text = text.Replace("\t", string.Empty);
            text = text.Replace(" ", string.Empty);
            Console.WriteLine(text);
            return text.ToCharArray();
        }

        public string MainTextTest()
        {
            string name1 = "Array   Int   String   Text   Void   Console   Return   Empty   ToUpper" +
                "   Char   Private   Count   If   Else   Switch   Enum   List   New   Object   Sender   Foreground   " +
                "Key   Styles   Navigation   Config";

            return name1;
        }
    
    }
}
