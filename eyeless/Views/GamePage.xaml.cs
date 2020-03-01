using OpenQA.Selenium;
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
    /// Логика взаимодействия для GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        public GamePage()
        {
            InitializeComponent();
            TextBox1.Focus();
            Chars = CreateCharArray();
        }

        public char[] Chars { get; set; } 

        private int Number { get; set; }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            Number += 1;

            var BrushConverter = new BrushConverter();


            if (Chars.Length > Number - 1)
            {

                if (TextBox.Text.IndexOf(' ') - 1 == 0)
                {
                    Delet(3);
                }

                if (Chars[Number - 1].ToString() == e.Key.ToString())
                {

                    Delet(1);
                    TextBox.Foreground = BrushConverter.ConvertFrom("#5B5B3A") as Brush;

                    ScoreControll(1);

                    Console.WriteLine(e.Key.ToString());
                }
                else 
                {

                    TextBox.Foreground = BrushConverter.ConvertFrom("#3B2D13") as Brush;
                    Delet(1);
                    ScoreControll(-2);
                }
            }
        }

        private void ScoreControll(int Add)
        {
            Lab.Content = Convert.ToInt32(Lab.Content) + Add;
        }

        private void Delet(int count)
        {
            if (TextBox.Text != string.Empty) 
            {
                TextBox.Text = TextBox.Text.Remove(0, count);
            }
        }

        private char[] CreateCharArray()
        {
            var text = TextBox.Text.ToString().ToUpper();
            text = text.Replace("\t", string.Empty);
            text = text.Replace(" ", string.Empty);
            Console.WriteLine(text);
            return text.ToCharArray();
        }
        

    }
}
