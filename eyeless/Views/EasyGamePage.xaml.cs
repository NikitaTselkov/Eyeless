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
    /// Логика взаимодействия для EasyGamePage.xaml
    /// </summary>
    public partial class EasyGamePage : Page
    {
        public EasyGamePage()
        {
            InitializeComponent();
            TextBox1.Focus();
            Lab.Content = 0;
            MainTextBox.Text = MainTextTest();
            Chars = CreateCharArray();

        }

        private char[] Chars { get; set; }

        private int Number { get; set; }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            Number += 1;

            if (clock.Percentage == 100 || Chars.Length <= Number)
            {
                if (clock.Percentage != 100)
                {
                    clock.Stop = true;
                }
                Stop.Continue.Focus();
                Stop.Visibility = Visibility.Visible;

            }
            else
            {

                IsClick(e.Key.ToString());

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

                    MainTextBox.Foreground = BrushConverter.ConvertFrom("#3B2D13") as Brush;
                    Delet(1);
                    ScoreControll(-2);
                }

            }
        }

        private void ScoreControll(int Add)
        {
            Lab.Content = Convert.ToInt32(Lab.Content) + Add * 1;
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

        private string MainTextTest()
        {
            string name1 = "Array   Int   String   Text   Void   Console   Return   Empty   ToUpper" +
                "   Char   Private   Count   If   Else   Switch   Enum   List   New   Object   Sender   Foreground   " +
                "Key   Styles   Navigation   Config";

            return name1;
        }

        #region KeyBoard

        private void activator()
        {
            KeyBoard1.Q.IsEnabled = true;
            KeyBoard1.W.IsEnabled = true;
            KeyBoard1.E.IsEnabled = true;
            KeyBoard1.R.IsEnabled = true;
            KeyBoard1.T.IsEnabled = true;
            KeyBoard1.Y.IsEnabled = true;
            KeyBoard1.U.IsEnabled = true;
            KeyBoard1.I.IsEnabled = true;
            KeyBoard1.O.IsEnabled = true;
            KeyBoard1.P.IsEnabled = true;
            KeyBoard1.A.IsEnabled = true;
            KeyBoard1.S.IsEnabled = true;
            KeyBoard1.D.IsEnabled = true;
            KeyBoard1.F.IsEnabled = true;
            KeyBoard1.G.IsEnabled = true;
            KeyBoard1.H.IsEnabled = true;
            KeyBoard1.J.IsEnabled = true;
            KeyBoard1.K.IsEnabled = true;
            KeyBoard1.L.IsEnabled = true;
            KeyBoard1.Z.IsEnabled = true;
            KeyBoard1.X.IsEnabled = true;
            KeyBoard1.C.IsEnabled = true;
            KeyBoard1.V.IsEnabled = true;
            KeyBoard1.B.IsEnabled = true;
            KeyBoard1.N.IsEnabled = true;
            KeyBoard1.M.IsEnabled = true;

        }

        private void IsClick(string key)
        {
            switch (key)
            {
                case "Q":
                    activator();
                    KeyBoard1.Q.IsEnabled = false;
                    break;
                case "W":
                    activator();
                    KeyBoard1.W.IsEnabled = false;
                    break;
                case "E":
                    activator();
                    KeyBoard1.E.IsEnabled = false;
                    break;
                case "R":
                    activator();
                    KeyBoard1.R.IsEnabled = false;
                    break;
                case "T":
                    activator();
                    KeyBoard1.T.IsEnabled = false;
                    break;
                case "Y":
                    activator();
                    KeyBoard1.Y.IsEnabled = false;
                    break;
                case "U":
                    activator();
                    KeyBoard1.U.IsEnabled = false;
                    break;
                case "I":
                    activator();
                    KeyBoard1.I.IsEnabled = false;
                    break;
                case "O":
                    activator();
                    KeyBoard1.O.IsEnabled = false;
                    break;
                case "P":
                    activator();
                    KeyBoard1.P.IsEnabled = false;
                    break;
                case "A":
                    activator();
                    KeyBoard1.A.IsEnabled = false;
                    break;
                case "S":
                    activator();
                    KeyBoard1.S.IsEnabled = false;
                    break;
                case "D":
                    activator();
                    KeyBoard1.D.IsEnabled = false;
                    break;
                case "F":
                    activator();
                    KeyBoard1.F.IsEnabled = false;
                    break;
                case "G":
                    activator();
                    KeyBoard1.G.IsEnabled = false;
                    break;
                case "H":
                    activator();
                    KeyBoard1.H.IsEnabled = false;
                    break;
                case "J":
                    activator();
                    KeyBoard1.J.IsEnabled = false;
                    break;
                case "K":
                    activator();
                    KeyBoard1.K.IsEnabled = false;
                    break;
                case "L":
                    activator();
                    KeyBoard1.L.IsEnabled = false;
                    break;
                case "Z":
                    activator();
                    KeyBoard1.Z.IsEnabled = false;
                    break;
                case "X":
                    activator();
                    KeyBoard1.X.IsEnabled = false;
                    break;
                case "C":
                    activator();
                    KeyBoard1.C.IsEnabled = false;
                    break;
                case "V":
                    activator();
                    KeyBoard1.V.IsEnabled = false;
                    break;
                case "B":
                    activator();
                    KeyBoard1.B.IsEnabled = false;
                    break;
                case "N":
                    activator();
                    KeyBoard1.N.IsEnabled = false;
                    break;
                case "M":
                    activator();
                    KeyBoard1.M.IsEnabled = false;
                    break;
 

            }
        }

        #endregion




    }
}
