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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        bool Flag = true;
        int[] Values = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public string CheckWinner()
        {
            if ((Values[0] == 1 && Values[1] == 1 && Values[2] == 1) || (Values[3] == 1 && Values[4] == 1 && Values[5] == 1) || (Values[6] == 1 && Values[7] == 1 && Values[8] == 1) || (Values[0] == 1 && Values[3] == 1 && Values[6] == 1) || (Values[1] == 1 && Values[4] == 1 && Values[7] == 1) || (Values[2] == 1 && Values[5] == 1 && Values[8] == 1) || (Values[0] == 1 && Values[4] == 1 && Values[8] == 1) || (Values[2] == 1 && Values[4] == 1 && Values[6] == 1))
            {
                return "X won!";
            }
            if ((Values[0] == -1 && Values[1] == -1 && Values[2] == -1) || (Values[3] == -1 && Values[4] == -1 && Values[5] == -1) || (Values[6] == -1 && Values[7] == -1 && Values[8] == -1) || (Values[0] == -1 && Values[3] == -1 && Values[5] == -1) || (Values[1] == -1 && Values[4] == -1 && Values[7] == -1) || (Values[2] == -1 && Values[5] == -1 && Values[8] == -1) || (Values[0] == -1 && Values[4] == -1 && Values[8] == -1) || (Values[2] == -1 && Values[4] == -1 && Values[6] == -1))
            {
                return "O won!";
            }
            return "nothing";

        }
        public int FreePlace()
        {
            int count = 0;
            for(int i = 0; i < Values.Length; ++i)
            {
                if (Values[i] == 0)
                    count += 1;
            }
            if(count > 1)
            {
                return count;
            }
            else if(count == 1)
            {
                return count;
            }
            return count;
        }
        public void NextClick(object sender, RoutedEventArgs e)
        {
            if (FreePlace() > 1)
            {
                Random random = new Random();
                int rand = random.Next(0,8);
                if(Values[rand] == 0)
                {
                    switch (rand)
                    {
                        case 0:
                            Button_Click1(sender, e);
                            break;
                        case 1:
                            Button_Click2(sender, e);
                            break;
                        case 2:
                            Button_Click3(sender, e);
                            break;
                        case 3:
                            Button_Click4(sender, e);
                            break;
                        case 4:
                            Button_Click5(sender, e);
                            break;
                        case 5:
                            Button_Click6(sender, e);
                            break;
                        case 6:
                            Button_Click7(sender, e);
                            break;
                        case 7:
                            Button_Click8(sender, e);
                            break;
                        case 8:
                            Button_Click9(sender, e);
                            break;
                    }
                }
                else
                {
                    NextClick(sender, e);
                }
            }
            if(FreePlace() == 1)
            {
                for (int i = 0; i < Values.Length; ++i)
                {
                    if (Values[i] == 0)
                        switch (i)
                        {
                            case 0:
                                Button_Click1(sender, e);
                                break;
                            case 1:
                                Button_Click2(sender, e);
                                break;
                            case 2:
                                Button_Click3(sender, e);
                                break;
                            case 3:
                                Button_Click4(sender, e);
                                break;
                            case 4:
                                Button_Click5(sender, e);
                                break;
                            case 5:
                                Button_Click6(sender, e);
                                break;
                            case 6:
                                Button_Click7(sender, e);
                                break;
                            case 7:
                                Button_Click8(sender, e);
                                break;
                            case 8:
                                Button_Click9(sender, e);
                                break;

                        }
                }
            }   
        }
        public int SearchNumber(string str)
        {
            int last_letter = str.Length-1;
            string need = str[last_letter] + "0";
            int result = int.Parse(need);
            return result/10;
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            if (Flag)
            {
                int number = SearchNumber(Text.Text);
                if (number % 2 != 0)
                {
                    Button1.Content = "X";
                    Values[0] = 1;
                    Text.Text = $"Номер хода: {number + 1}";
                }
                else
                {
                    Button1.Content = "O";
                    Values[0] = -1;
                    Text.Text = $"Номер хода: {number + 1}";
                    NextClick(sender, e);
                }
            }
            else
            {
                int number = SearchNumber(Text.Text);
                if (number % 2 != 0)
                {
                    Button1.Content = "X";
                    Values[0] = 1;
                    Text.Text = $"Номер хода: {number + 1}";
                }
                else
                {
                    Button1.Content = "O";
                    Values[0] = -1;
                    Text.Text = $"Номер хода: {number + 1}";
                }
            }
            if (CheckWinner() == "X won!")
            {
                Winner.Text = "X won!";
                Button1.IsEnabled = false;
                Button2.IsEnabled = false;
                Button3.IsEnabled = false;
                Button4.IsEnabled = false;
                Button5.IsEnabled = false;
                Button6.IsEnabled = false;
                Button7.IsEnabled = false;
                Button8.IsEnabled = false;
                Button9.IsEnabled = false;
            }
            else if (CheckWinner() == "O won!")
            {
                Winner.Text = "O won!";
                Button1.IsEnabled = false;
                Button2.IsEnabled = false;
                Button3.IsEnabled = false;
                Button4.IsEnabled = false;
                Button5.IsEnabled = false;
                Button6.IsEnabled = false;
                Button7.IsEnabled = false;
                Button8.IsEnabled = false;
                Button9.IsEnabled = false;
            }
            else if (CheckWinner() == "nothing" && SearchNumber(Text.Text) == 10)
            {
                Winner.Text = "No one";
                Button1.IsEnabled = false;
                Button2.IsEnabled = false;
                Button3.IsEnabled = false;
                Button4.IsEnabled = false;
                Button5.IsEnabled = false;
                Button6.IsEnabled = false;
                Button7.IsEnabled = false;
                Button8.IsEnabled = false;
                Button9.IsEnabled = false;
            }
            
        }
        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            if (Flag)
            {
                int number = SearchNumber(Text.Text);
                if (number % 2 != 0)
                {
                    Button2.Content = "X";
                    Values[1] = 1;
                    Text.Text = $"Номер хода: {number + 1}";
                }
                else
                {
                    Button2.Content = "O";
                    Values[1] = -1;
                    Text.Text = $"Номер хода: {number + 1}";
                    NextClick(sender, e);
                }
            }
            else
            {
                int number = SearchNumber(Text.Text);
                if (number % 2 != 0)
                {
                    Button2.Content = "X";
                    Values[1] = 1;
                    Text.Text = $"Номер хода: {number + 1}";
                }
                else
                {
                    Button2.Content = "O";
                    Values[1] = -1;
                    Text.Text = $"Номер хода: {number + 1}";
                }
            }
            if (CheckWinner() == "X won!")
            {
                Winner.Text = "X won!";
                Button1.IsEnabled = false;
                Button2.IsEnabled = false;
                Button3.IsEnabled = false;
                Button4.IsEnabled = false;
                Button5.IsEnabled = false;
                Button6.IsEnabled = false;
                Button7.IsEnabled = false;
                Button8.IsEnabled = false;
                Button9.IsEnabled = false;
            }
            else if (CheckWinner() == "O won!")
            {
                Winner.Text = "O won!";
                Button1.IsEnabled = false;
                Button2.IsEnabled = false;
                Button3.IsEnabled = false;
                Button4.IsEnabled = false;
                Button5.IsEnabled = false;
                Button6.IsEnabled = false;
                Button7.IsEnabled = false;
                Button8.IsEnabled = false;
                Button9.IsEnabled = false;
            }
            else if (CheckWinner() == "nothing" && SearchNumber(Text.Text) == 10)
            {
                Winner.Text = "No one";
                Button1.IsEnabled = false;
                Button2.IsEnabled = false;
                Button3.IsEnabled = false;
                Button4.IsEnabled = false;
                Button5.IsEnabled = false;
                Button6.IsEnabled = false;
                Button7.IsEnabled = false;
                Button8.IsEnabled = false;
                Button9.IsEnabled = false;
            }
        }
        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            if (Flag)
            {
                int number = SearchNumber(Text.Text);
                if (number % 2 != 0)
                {
                    Button3.Content = "X";
                    Values[2] = 1;
                    Text.Text = $"Номер хода: {number + 1}";
                }
                else
                {
                    Button3.Content = "O";
                    Values[2] = -1;
                    Text.Text = $"Номер хода: {number + 1}";
                    NextClick(sender, e);
                }
            }
            else
            {
                int number = SearchNumber(Text.Text);
                if (number % 2 != 0)
                {
                    Button3.Content = "X";
                    Values[2] = 1;
                    Text.Text = $"Номер хода: {number + 1}";
                }
                else
                {
                    Button3.Content = "O";
                    Values[2] = -1;
                    Text.Text = $"Номер хода: {number + 1}";
                }
            }
            if (CheckWinner() == "X won!")
            {
                Winner.Text = "X won!";
                Button1.IsEnabled = false;
                Button2.IsEnabled = false;
                Button3.IsEnabled = false;
                Button4.IsEnabled = false;
                Button5.IsEnabled = false;
                Button6.IsEnabled = false;
                Button7.IsEnabled = false;
                Button8.IsEnabled = false;
                Button9.IsEnabled = false;
            }
            else if (CheckWinner() == "O won!")
            {
                Winner.Text = "O won!";
                Button1.IsEnabled = false;
                Button2.IsEnabled = false;
                Button3.IsEnabled = false;
                Button4.IsEnabled = false;
                Button5.IsEnabled = false;
                Button6.IsEnabled = false;
                Button7.IsEnabled = false;
                Button8.IsEnabled = false;
                Button9.IsEnabled = false;
            }
            else if (CheckWinner() == "nothing" && SearchNumber(Text.Text) == 10)
            {
                Winner.Text = "No one";
                Button1.IsEnabled = false;
                Button2.IsEnabled = false;
                Button3.IsEnabled = false;
                Button4.IsEnabled = false;
                Button5.IsEnabled = false;
                Button6.IsEnabled = false;
                Button7.IsEnabled = false;
                Button8.IsEnabled = false;
                Button9.IsEnabled = false;
            }
        }
        private void Button_Click4(object sender, RoutedEventArgs e)
        {
            if (Flag)
            {
                int number = SearchNumber(Text.Text);
                if (number % 2 != 0)
                {
                    Button4.Content = "X";
                    Values[3] = 1;
                    Text.Text = $"Номер хода: {number + 1}";
                }
                else
                {
                    Button4.Content = "O";
                    Values[3] = -1;
                    Text.Text = $"Номер хода: {number + 1}";
                    NextClick(sender, e);
                }
            }
            else
            {
                int number = SearchNumber(Text.Text);
                if (number % 2 != 0)
                {
                    Button4.Content = "X";
                    Values[3] = 1;
                    Text.Text = $"Номер хода: {number + 1}";
                }
                else
                {
                    Button4.Content = "O";
                    Values[3] = -1;
                    Text.Text = $"Номер хода: {number + 1}";
                }
            }
            if (CheckWinner() == "X won!")
            {
                Winner.Text = "X won!";
                Button1.IsEnabled = false;
                Button2.IsEnabled = false;
                Button3.IsEnabled = false;
                Button4.IsEnabled = false;
                Button5.IsEnabled = false;
                Button6.IsEnabled = false;
                Button7.IsEnabled = false;
                Button8.IsEnabled = false;
                Button9.IsEnabled = false;
            }
            else if (CheckWinner() == "O won!")
            {
                Winner.Text = "O won!";
                Button1.IsEnabled = false;
                Button2.IsEnabled = false;
                Button3.IsEnabled = false;
                Button4.IsEnabled = false;
                Button5.IsEnabled = false;
                Button6.IsEnabled = false;
                Button7.IsEnabled = false;
                Button8.IsEnabled = false;
                Button9.IsEnabled = false;
            }
            else if (CheckWinner() == "nothing" && SearchNumber(Text.Text) == 10)
            {
                Winner.Text = "No one";
                Button1.IsEnabled = false;
                Button2.IsEnabled = false;
                Button3.IsEnabled = false;
                Button4.IsEnabled = false;
                Button5.IsEnabled = false;
                Button6.IsEnabled = false;
                Button7.IsEnabled = false;
                Button8.IsEnabled = false;
                Button9.IsEnabled = false;
            }
        }
        private void Button_Click5(object sender, RoutedEventArgs e)
        {
            if (Flag)
            {
                int number = SearchNumber(Text.Text);
                if (number % 2 != 0)
                {
                    Button5.Content = "X";
                    Values[4] = 1;
                    Text.Text = $"Номер хода: {number + 1}";
                }
                else
                {
                    Button5.Content = "O";
                    Values[4] = -1;
                    Text.Text = $"Номер хода: {number + 1}";
                    NextClick(sender, e);
                }
            }
            else
            {
                int number = SearchNumber(Text.Text);
                if (number % 2 != 0)
                {
                    Button5.Content = "X";
                    Values[4] = 1;
                    Text.Text = $"Номер хода: {number + 1}";
                }
                else
                {
                    Button5.Content = "O";
                    Values[4] = -1;
                    Text.Text = $"Номер хода: {number + 1}";
                }
            }
            if (CheckWinner() == "X won!")
            {
                Winner.Text = "X won!";
                Button1.IsEnabled = false;
                Button2.IsEnabled = false;
                Button3.IsEnabled = false;
                Button4.IsEnabled = false;
                Button5.IsEnabled = false;
                Button6.IsEnabled = false;
                Button7.IsEnabled = false;
                Button8.IsEnabled = false;
                Button9.IsEnabled = false;
            }
            else if (CheckWinner() == "O won!")
            {
                Winner.Text = "O won!";
                Button1.IsEnabled = false;
                Button2.IsEnabled = false;
                Button3.IsEnabled = false;
                Button4.IsEnabled = false;
                Button5.IsEnabled = false;
                Button6.IsEnabled = false;
                Button7.IsEnabled = false;
                Button8.IsEnabled = false;
                Button9.IsEnabled = false;
            }
            else if (CheckWinner() == "nothing" && SearchNumber(Text.Text) == 10)
            {
                Winner.Text = "No one";
                Button1.IsEnabled = false;
                Button2.IsEnabled = false;
                Button3.IsEnabled = false;
                Button4.IsEnabled = false;
                Button5.IsEnabled = false;
                Button6.IsEnabled = false;
                Button7.IsEnabled = false;
                Button8.IsEnabled = false;
                Button9.IsEnabled = false;
            }
        }
        private void Button_Click6(object sender, RoutedEventArgs e)
        {
            if (Flag)
            {
                int number = SearchNumber(Text.Text);
                if (number % 2 != 0)
                {
                    Button6.Content = "X";
                    Values[5] = 1;
                    Text.Text = $"Номер хода: {number + 1}";
                }
                else
                {
                    Button6.Content = "O";
                    Values[5] = -1;
                    Text.Text = $"Номер хода: {number + 1}";
                    NextClick(sender, e);
                }
            }
            else
            {
                int number = SearchNumber(Text.Text);
                if (number % 2 != 0)
                {
                    Button6.Content = "X";
                    Values[5] = 1;
                    Text.Text = $"Номер хода: {number + 1}";
                }
                else
                {
                    Button6.Content = "O";
                    Values[5] = -1;
                    Text.Text = $"Номер хода: {number + 1}";
                }
            }
            if (CheckWinner() == "X won!")
            {
                Winner.Text = "X won!";
                Button1.IsEnabled = false;
                Button2.IsEnabled = false;
                Button3.IsEnabled = false;
                Button4.IsEnabled = false;
                Button5.IsEnabled = false;
                Button6.IsEnabled = false;
                Button7.IsEnabled = false;
                Button8.IsEnabled = false;
                Button9.IsEnabled = false;
            }
            else if (CheckWinner() == "O won!")
            {
                Winner.Text = "O won!";
                Button1.IsEnabled = false;
                Button2.IsEnabled = false;
                Button3.IsEnabled = false;
                Button4.IsEnabled = false;
                Button5.IsEnabled = false;
                Button6.IsEnabled = false;
                Button7.IsEnabled = false;
                Button8.IsEnabled = false;
                Button9.IsEnabled = false;
            }
            else if (CheckWinner() == "nothing" && SearchNumber(Text.Text) == 10)
            {
                Winner.Text = "No one";
                Button1.IsEnabled = false;
                Button2.IsEnabled = false;
                Button3.IsEnabled = false;
                Button4.IsEnabled = false;
                Button5.IsEnabled = false;
                Button6.IsEnabled = false;
                Button7.IsEnabled = false;
                Button8.IsEnabled = false;
                Button9.IsEnabled = false;
            }
        }
        private void Button_Click7(object sender, RoutedEventArgs e)
        {
            if (Flag)
            {
                int number = SearchNumber(Text.Text);
                if (number % 2 != 0)
                {
                    Button7.Content = "X";
                    Values[6] = 1;
                    Text.Text = $"Номер хода: {number + 1}";
                }
                else
                {
                    Button7.Content = "O";
                    Values[6] = -1;
                    Text.Text = $"Номер хода: {number + 1}";
                    NextClick(sender, e);
                }
            }
            else
            {
                int number = SearchNumber(Text.Text);
                if (number % 2 != 0)
                {
                    Button7.Content = "X";
                    Values[6] = 1;
                    Text.Text = $"Номер хода: {number + 1}";
                }
                else
                {
                    Button7.Content = "O";
                    Values[6] = -1;
                    Text.Text = $"Номер хода: {number + 1}";
                }
            }
            if (CheckWinner() == "X won!")
            {
                Winner.Text = "X won!";
                Button1.IsEnabled = false;
                Button2.IsEnabled = false;
                Button3.IsEnabled = false;
                Button4.IsEnabled = false;
                Button5.IsEnabled = false;
                Button6.IsEnabled = false;
                Button7.IsEnabled = false;
                Button8.IsEnabled = false;
                Button9.IsEnabled = false;
            }
            else if (CheckWinner() == "O won!")
            {
                Winner.Text = "O won!";
                Button1.IsEnabled = false;
                Button2.IsEnabled = false;
                Button3.IsEnabled = false;
                Button4.IsEnabled = false;
                Button5.IsEnabled = false;
                Button6.IsEnabled = false;
                Button7.IsEnabled = false;
                Button8.IsEnabled = false;
                Button9.IsEnabled = false;
            }
            else if (CheckWinner() == "nothing" && SearchNumber(Text.Text) == 10)
            {
                Winner.Text = "No one";
                Button1.IsEnabled = false;
                Button2.IsEnabled = false;
                Button3.IsEnabled = false;
                Button4.IsEnabled = false;
                Button5.IsEnabled = false;
                Button6.IsEnabled = false;
                Button7.IsEnabled = false;
                Button8.IsEnabled = false;
                Button9.IsEnabled = false;
            }
        }
        private void Button_Click8(object sender, RoutedEventArgs e)
        {
            if (Flag)
            {
                int number = SearchNumber(Text.Text);
                if (number % 2 != 0)
                {
                    Button8.Content = "X";
                    Values[7] = 1;
                    Text.Text = $"Номер хода: {number + 1}";
                }
                else
                {
                    Button8.Content = "O";
                    Values[7] = -1;
                    Text.Text = $"Номер хода: {number + 1}";
                    NextClick(sender, e);
                }
            }
            else
            {
                int number = SearchNumber(Text.Text);
                if (number % 2 != 0)
                {
                    Button8.Content = "X";
                    Values[7] = 1;
                    Text.Text = $"Номер хода: {number + 1}";
                }
                else
                {
                    Button8.Content = "O";
                    Values[7] = -1;
                    Text.Text = $"Номер хода: {number + 1}";
                }
            }
            if (CheckWinner() == "X won!")
            {
                Winner.Text = "X won!";
                Button1.IsEnabled = false;
                Button2.IsEnabled = false;
                Button3.IsEnabled = false;
                Button4.IsEnabled = false;
                Button5.IsEnabled = false;
                Button6.IsEnabled = false;
                Button7.IsEnabled = false;
                Button8.IsEnabled = false;
                Button9.IsEnabled = false;
            }
            else if (CheckWinner() == "O won!")
            {
                Winner.Text = "O won!";
                Button1.IsEnabled = false;
                Button2.IsEnabled = false;
                Button3.IsEnabled = false;
                Button4.IsEnabled = false;
                Button5.IsEnabled = false;
                Button6.IsEnabled = false;
                Button7.IsEnabled = false;
                Button8.IsEnabled = false;
                Button9.IsEnabled = false;
            }
            else if (CheckWinner() == "nothing" && SearchNumber(Text.Text) == 10)
            {
                Winner.Text = "No one";
                Button1.IsEnabled = false;
                Button2.IsEnabled = false;
                Button3.IsEnabled = false;
                Button4.IsEnabled = false;
                Button5.IsEnabled = false;
                Button6.IsEnabled = false;
                Button7.IsEnabled = false;
                Button8.IsEnabled = false;
                Button9.IsEnabled = false;
            }
        }
        private void Button_Click9(object sender, RoutedEventArgs e)
        {
            if (Flag)
            {
                int number = SearchNumber(Text.Text);
                if (number % 2 != 0)
                {
                    Button9.Content = "X";
                    Values[8] = 1;
                    Text.Text = $"Номер хода: {number + 1}";
                }
                else
                {
                    Button9.Content = "O";
                    Values[8] = -1;
                    Text.Text = $"Номер хода: {number + 1}";
                    NextClick(sender, e);
                }
            }
            else
            {
                int number = SearchNumber(Text.Text);
                if (number % 2 != 0)
                {
                    Button9.Content = "X";
                    Values[8] = 1;
                    Text.Text = $"Номер хода: {number + 1}";
                }
                else
                {
                    Button9.Content = "O";
                    Values[8] = -1;
                    Text.Text = $"Номер хода: {number + 1}";
                }
            }
            if (CheckWinner() == "X won!")
            {
                Winner.Text = "X won!";
                Button1.IsEnabled = false;
                Button2.IsEnabled = false;
                Button3.IsEnabled = false;
                Button4.IsEnabled = false;
                Button5.IsEnabled = false;
                Button6.IsEnabled = false;
                Button7.IsEnabled = false;
                Button8.IsEnabled = false;
                Button9.IsEnabled = false;
            }
            else if (CheckWinner() == "O won!")
            {
                Winner.Text = "O won!";
                Button1.IsEnabled = false;
                Button2.IsEnabled = false;
                Button3.IsEnabled = false;
                Button4.IsEnabled = false;
                Button5.IsEnabled = false;
                Button6.IsEnabled = false;
                Button7.IsEnabled = false;
                Button8.IsEnabled = false;
                Button9.IsEnabled = false;
            }
            else if (CheckWinner() == "nothing" && SearchNumber(Text.Text) == 10)
            {
                Winner.Text = "No one";
                Button1.IsEnabled = false;
                Button2.IsEnabled = false;
                Button3.IsEnabled = false;
                Button4.IsEnabled = false;
                Button5.IsEnabled = false;
                Button6.IsEnabled = false;
                Button7.IsEnabled = false;
                Button8.IsEnabled = false;
                Button9.IsEnabled = false;
            }
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            Flag = true;
            Button1.IsEnabled=true;
            Button2.IsEnabled=true;
            Button3.IsEnabled=true;
            Button4.IsEnabled=true;
            Button5.IsEnabled=true;
            Button6.IsEnabled=true;
            Button7.IsEnabled=true;
            Button8.IsEnabled=true;
            Button9.IsEnabled=true;
            Text.Text = "Номер хода: 1";
            Button_Click1(sender, e);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Flag = false;
            Button1.IsEnabled = true;
            Button2.IsEnabled = true;
            Button3.IsEnabled = true;
            Button4.IsEnabled = true;
            Button5.IsEnabled = true;
            Button6.IsEnabled = true;
            Button7.IsEnabled = true;
            Button8.IsEnabled = true;
            Button9.IsEnabled = true;
            Text.Text = "Номер хода: 1";
        }
    }
}
