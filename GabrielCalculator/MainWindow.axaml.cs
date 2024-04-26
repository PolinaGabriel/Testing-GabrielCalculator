using Avalonia.Controls;
using Avalonia.Interactivity;
using System;
using System.Linq;

namespace GabrielCalculator
{
    public partial class MainWindow : Window
    {
        public string memory = "";
        public double firstNumber = 0;
        public double secondNumber = 0;
        public char sign = ' ';
        public int degCheck = 0;
        public int radCheck = 0;
        public int gonCheck = 0;
        public int invCheck = 0;
        
        public MainWindow()
        {
            /*
            1. ��� ������������ (���������, ��� ������������, ���� �� ������)
            2. ���� ���������� ����� ��������� ���, ��� �� ��� ������ ����� ��������
            3. ��� ����� � ����������
            4. ���������� �������� �������� ��������� ����������
            5. ��� ����� ����� ����� �� ������� ���� � ������ �� ����� �����
            6. ������ �� �������� (�� ������� ���)
            7. ��� ���������� ������� �� �������������, ����� ������� �����������
            8. �� ���� ������ ������������ ������ ���� ��������
            9. ��� ��������� ������� ������ = �� ����������� ��������� ��������
            10. ������ � ��������� ��������� ���������� (��� ���������� � �����������)
            11. ��� ����� ������� ���������� ���������� � ����� ��������� ���� �������������
            12. ��������� ��������� ������ �� 33, ������ - ����� 0
            13. ������� � ���������� ����� ������ �� ���������������� �� �������� �� ����� ������� ������
            14. ���������� ����� ������������ ������� �� �������� (�� ������� ���)
            15. ����� �� ��������� �� ����������� � ���������������� ����� � �������
            16. ��� ������ ���� ����� Ln �� ������� ������� �� ����
            17. ��� ������ ���� ����� Int �� ������� ������� �� ����
            18. ��� ������ ���� ����� sinh �� ������� ������� �� ����
            19. ��� ������ ���� ����� sin �� ������� ������� �� ����
            20. ��� ������ ���� ����� x^2 �� ������� ������� �� ����
            21. ��� ������ ���� ����� n! �� ������� ������� �� ����
            22. ��� ������ ���� ����� dms �� ������� ������� �� ����
            23. ��� ������ ���� ����� cosh �� ������� ������� �� ����
            24. ��� ������ ���� ����� cos �� ������� ������� �� ����
            25. ��� ������ ���� ����� x^n �� ������� ������� �� ����
            26. ��� ������ ���� ����� nrx �� ������� ������� �� ����
            27. ��� ������ ���� ����� tanh �� ������� ������� �� ����
            28. ��� ������ ���� ����� tan �� ������� ������� �� ����
            29. ��� ������ ���� ����� x^3 �� ������� ������� �� ����
            30. ��� ������ ���� ����� 3rx �� ������� ������� �� ����
            31. ��� ������ ���� ����� Mod �� ������� ������� �� ����
            32. ��� ������ ���� ����� log �� ������� ������� �� ����
            33. ��� ������ ���� ����� 10^x �� ������� ������� �� ����
            34. ������ Inv �� ��������
            35. ��� ������� + ���������� ��������
            36. ��� ������� - ���������� ��������
            37. ��� ������� / ���������� ��������
            38. ��� ������� * ���������� ��������
            */

            InitializeComponent();
            entry.Text = "";
        }

        /// <summary>
        /// ����� RadioButton Degrees ����������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CheckDeg(object? sender, RoutedEventArgs e)
        {
            degCheck++;
            if (degCheck % 2 == 0)
            {
                Deg.IsChecked = false;
            }
            else
            {
                Deg.IsChecked = true;
            }
        }

        /// <summary>
        /// ����� RadioButton Radians ����������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CheckRad(object? sender, RoutedEventArgs e)
        {
            radCheck++;
            if (radCheck % 2 == 0)
            {
                Rad.IsChecked = false;
            }
            else
            {
                Rad.IsChecked = true;
            }
        }

        /// <summary>
        /// ����� RadioButton Grads ����������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CheckGon(object? sender, RoutedEventArgs e)
        {
            gonCheck++;
            if (gonCheck % 2 == 0)
            {
                Gon.IsChecked = false;
            }
            else
            {
                Gon.IsChecked = true;
            }
        }

        /// <summary>
        /// ����� RadioButton Inv ����������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CheckInv(object? sender, RoutedEventArgs e)
        {
            invCheck++;
            if (invCheck % 2 == 0)
            {
                Inv.IsChecked = false;
            }
            else
            {
                Inv.IsChecked = true;
            }
        }

        /// <summary>
        /// �������� ��������� (��� ������)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Solve(object? sender, RoutedEventArgs e)
        {
            if (entry.Text != "")
            {
                secondNumber = Convert.ToDouble(entry.Text);
                Solving();
            }
        }

        /// <summary>
        /// �������� ���������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Solving()
        {
            switch (sign)
            {
                case '+':
                    entry.Text = Convert.ToString(firstNumber + secondNumber);
                    break;

                case '-':
                    entry.Text = Convert.ToString(firstNumber - secondNumber);
                    break;

                case '*':
                    entry.Text = Convert.ToString(firstNumber * secondNumber);
                    break;

                case '/':
                    entry.Text = Convert.ToString(firstNumber / secondNumber);
                    break;

                case '%':
                    entry.Text = Convert.ToString(firstNumber / 100 * secondNumber);
                    break;

                case 'm':
                    entry.Text = Convert.ToString(firstNumber % secondNumber);
                    break;

                case '^':
                    entry.Text = Convert.ToString(Math.Pow(firstNumber, secondNumber));
                    break;

                case 'r':
                    //?
                    break;
            }
            expression.Text = "";
            firstNumber = 0;
            secondNumber = 0;
            sign = ' ';
        }

        /// <summary>
        /// ������� ��������� ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Backspace(object? sender, RoutedEventArgs e)
        {
            if (entry.Text.Length > 0)
            {
                entry.Text = entry.Text.Substring(0, entry.Text.Length - 1);
            }
        }

        /// <summary>
        /// �������� ���� � ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Clear(object? sender, RoutedEventArgs e)
        {
            entry.Text = "";
            memory = "";
        }

        /// <summary>
        /// �������� ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ClearEntry(object? sender, RoutedEventArgs e)
        {
            entry.Text = "";
        }

        /// <summary>
        /// �������� ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MemoryClear(object? sender, RoutedEventArgs e)
        {
            memory = "";
        }

        /// <summary>
        /// ��������� � ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MemorySave(object? sender, RoutedEventArgs e)
        {
            if (entry.Text != "") //����� ������
            {
                memory = entry.Text;
            }
        }

        /// <summary>
        /// ���������� ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MemoryRead(object? sender, RoutedEventArgs e)
        {
            if (memory != "") //����� ������
            {
                entry.Text = memory;
            }
        }

        /// <summary>
        /// ������� ������ � ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MemoryPlus(object? sender, RoutedEventArgs e)
        {
            if (entry.Text != "" && memory != "") //����� ������
            {
                entry.Text = Convert.ToString(Convert.ToDouble(memory) + Convert.ToDouble(entry.Text));
            }
        }

        /// <summary>
        /// ������� ���� �� ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MemoryMinus(object? sender, RoutedEventArgs e)
        {
            if (entry.Text != "" && memory != "") //����� ������
            {
                entry.Text = Convert.ToString(Convert.ToDouble(memory) - Convert.ToDouble(entry.Text));
            }
        }

        /// <summary>
        /// ����� ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Pi(object? sender, RoutedEventArgs e)
        {
            if (entry.Text == "")
            {
                entry.Text += "3,1415926535897932384626433832795";
            }
        }

        /// <summary>
        /// ����� ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Zero(object? sender, RoutedEventArgs e)
        {
            if (entry.Text != "")
            {
                entry.Text += "0";
            }  
        }

        /// <summary>
        /// ����� ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void One(object? sender, RoutedEventArgs e)
        {
            entry.Text += "1";
        }

        /// <summary>
        /// ����� ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Two(object? sender, RoutedEventArgs e)
        {
            entry.Text += "2";
        }

        /// <summary>
        /// ����� ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Three(object? sender, RoutedEventArgs e)
        {
            entry.Text += "3";
        }

        /// <summary>
        /// ����� ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Four(object? sender, RoutedEventArgs e)
        {
            entry.Text += "4";
        }

        /// <summary>
        /// ����� ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Five(object? sender, RoutedEventArgs e)
        {
            entry.Text += "5";
        }

        /// <summary>
        /// ����� �����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Six(object? sender, RoutedEventArgs e)
        {
            entry.Text += "6";
        }

        /// <summary>
        /// ����� ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Seven(object? sender, RoutedEventArgs e)
        {
            entry.Text += "7";
        }

        /// <summary>
        /// ����� ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Eight(object? sender, RoutedEventArgs e)
        {
            entry.Text += "8";
        }

        /// <summary>
        /// ����� ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Nine(object? sender, RoutedEventArgs e)
        {
            entry.Text += "9";
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Comma(object? sender, RoutedEventArgs e)
        {
            if (entry.Text.Contains(",") == false)
            {
                entry.Text += ",";
            }
        }

        /// <summary>
        /// ������������� ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BracketStart(object? sender, RoutedEventArgs e)
        {
            
        }

        /// <summary>
        /// ������������� ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BracketEnd(object? sender, RoutedEventArgs e)
        {
             
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Plus(object? sender, RoutedEventArgs e)
        {
            firstNumber = Convert.ToDouble(entry.Text);
            sign = '+';
            expression.Text = entry.Text + " + ";
            entry.Text = "";
        }

        /// <summary>
        /// ���������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Minus(object? sender, RoutedEventArgs e)
        {
            firstNumber = Convert.ToDouble(entry.Text);
            sign = '-';
            expression.Text = entry.Text + " - ";
            entry.Text = "";
        }

        /// <summary>
        /// ���������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Multiple(object? sender, RoutedEventArgs e)
        {
            firstNumber = Convert.ToDouble(entry.Text);
            sign = '*';
            expression.Text = entry.Text + " * ";
            entry.Text = "";
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Divide(object? sender, RoutedEventArgs e)
        {
            firstNumber = Convert.ToDouble(entry.Text);
            sign = '/';
            expression.Text = entry.Text + " / ";
            entry.Text = "";
        }

        /// <summary>
        /// ������� �� �����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Percent(object? sender, RoutedEventArgs e)
        {
            firstNumber = Convert.ToDouble(entry.Text);
            sign = '%';
            expression.Text = entry.Text + " % ";
            entry.Text = ""; 
        }

        /// <summary>
        /// ������� �� �������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Mod(object? sender, RoutedEventArgs e)
        {
            if (entry.Text != "")
            {
                firstNumber = Convert.ToDouble(entry.Text);
                sign = 'm';
                expression.Text = entry.Text + " mod ";
                entry.Text = "";
            }
        }

        /// <summary>
        /// ���������� � ��������� �������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void PowerY(object? sender, RoutedEventArgs e)
        {
            if (entry.Text != "")
            {
                firstNumber = Convert.ToDouble(entry.Text);
                sign = '^';
                expression.Text = entry.Text + " ^ ";
                entry.Text = "";
            }
        }

        /// <summary>
        /// ������ ��������� �������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void RadixY(object? sender, RoutedEventArgs e) //?
        {
            if (entry.Text != "")
            {
                firstNumber = Convert.ToDouble(entry.Text);
                sign = 'r';
                expression.Text = entry.Text + " r ";
                entry.Text = "";
            }
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Negate(object? sender, RoutedEventArgs e)
        {
            if (entry.Text != "" && Math.Sign(Convert.ToDouble(entry.Text)) == -1)
            {
                entry.Text = entry.Text.Substring(1, entry.Text.Length - 1);
            }
            else
            {
                entry.Text = "-" + entry.Text;
            }
        }

        /// <summary>
        /// ��������� ����� �����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Int(object? sender, RoutedEventArgs e)
        {
            if (entry.Text != "")
            {
                entry.Text = Convert.ToString(Math.Truncate(Convert.ToDouble(entry.Text)));
            }
        }

        /// <summary>
        /// ����� � �������� � ��������� � ������ � �����������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Division(object? sender, RoutedEventArgs e)
        {
            if (entry.Text != "")
            {
                entry.Text = Convert.ToString((double)1 / Convert.ToDouble(entry.Text));
            }
        }

        /// <summary>
        /// ���������� ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Log(object? sender, RoutedEventArgs e)
        {
            if (entry.Text != "")
            {
                entry.Text = Convert.ToString(Math.Log10(Convert.ToDouble(entry.Text)));
            }
        }

        /// <summary>
        /// ����������� ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Ln(object? sender, RoutedEventArgs e)
        {
            if (entry.Text != "")
            {
                entry.Text = Convert.ToString(Math.Log(Convert.ToDouble(entry.Text)));
            }
        }

        /// <summary>
        /// ������� �����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Power2(object? sender, RoutedEventArgs e)
        {
            if (entry.Text != "")
            {
                entry.Text = Convert.ToString(Math.Pow(Convert.ToDouble(entry.Text), 2));
            }
        }

        /// <summary>
        /// ���������� ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Radix2(object? sender, RoutedEventArgs e)
        {
            if (entry.Text != "")
            {
                entry.Text = Convert.ToString(Math.Sqrt(Convert.ToDouble(entry.Text)));
            }
        }

        /// <summary>
        /// ��� �����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Power3(object? sender, RoutedEventArgs e)
        {
            if (entry.Text != "")
            {
                entry.Text = Convert.ToString(Math.Pow(Convert.ToDouble(entry.Text), 3));
            }
        }

        /// <summary>
        /// ���������� ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Radix3(object? sender, RoutedEventArgs e)
        {
            if (entry.Text != "")
            {
                entry.Text = Convert.ToString(Math.Cbrt(Convert.ToDouble(entry.Text)));
            }
        }

        /// <summary>
        /// 10 � ������� �����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TenPower(object? sender, RoutedEventArgs e)
        {
            if (entry.Text != "")
            {
                entry.Text = Convert.ToString(Math.Pow(10, Convert.ToDouble(entry.Text)));
            }
        }

        /// <summary>
        /// ����� ��� ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Sin(object? sender, RoutedEventArgs e)
        {
            if (entry.Text != "")
            {
                if (Inv.IsPressed == true)
                {
                    entry.Text = Convert.ToString(Math.Asin(Convert.ToDouble(entry.Text)));
                }
                else
                {
                    entry.Text = Convert.ToString(Math.Sin(Convert.ToDouble(entry.Text)));
                }
            }
        }

        /// <summary>
        /// ��������������� ����� ��� ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SinH(object? sender, RoutedEventArgs e)
        {
            if (entry.Text != "")
            {
                if (Inv.IsPressed == true)
                {
                    entry.Text = Convert.ToString(Math.Asinh(Convert.ToDouble(entry.Text)));
                }
                else
                {
                    entry.Text = Convert.ToString(Math.Sinh(Convert.ToDouble(entry.Text)));
                }
            }
        }

        /// <summary>
        /// ������� ��� ����������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Cos(object? sender, RoutedEventArgs e)
        {
            if (entry.Text != "")
            {
                if (Inv.IsPressed == true)
                {
                    entry.Text = Convert.ToString(Math.Acos(Convert.ToDouble(entry.Text)));
                }
                else
                {
                    entry.Text = Convert.ToString(Math.Cos(Convert.ToDouble(entry.Text)));
                }
            }
        }

        /// <summary>
        /// ��������������� ������� ��� ����������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void CosH(object? sender, RoutedEventArgs e)
        {
            if (entry.Text != "")
            {
                if (Inv.IsPressed == true)
                {
                    entry.Text = Convert.ToString(Math.Acosh(Convert.ToDouble(entry.Text)));
                }
                else
                {
                    entry.Text = Convert.ToString(Math.Cosh(Convert.ToDouble(entry.Text)));
                }
            }
        }

        /// <summary>
        /// ������� ��� ����������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Tan(object? sender, RoutedEventArgs e)
        {
            if (entry.Text != "")
            {
                if (Inv.IsPressed == true)
                {
                    entry.Text = Convert.ToString(Math.Atan(Convert.ToDouble(entry.Text)));
                }
                else
                {
                    entry.Text = Convert.ToString(Math.Tan(Convert.ToDouble(entry.Text)));
                }
            }
        }

        /// <summary>
        /// ��������������� ������� ��� ����������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TanH(object? sender, RoutedEventArgs e)
        {
            if (entry.Text != "")
            {
                if (Inv.IsPressed == true)
                {
                    entry.Text = Convert.ToString(Math.Atanh(Convert.ToDouble(entry.Text)));
                }
                else
                {
                    entry.Text = Convert.ToString(Math.Tanh(Convert.ToDouble(entry.Text)));
                }
            }
        }

        /// <summary>
        /// ������� � �������-������-������� �� ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Dms(object? sender, RoutedEventArgs e)
        {
            if (entry.Text != "")
            {
                entry.Text = Math.Truncate(Convert.ToDouble(entry.Text)) + "�" + Math.Truncate((Convert.ToDouble(entry.Text) - Math.Truncate(Convert.ToDouble(entry.Text))) * 60) + "'" + ((Convert.ToDouble(entry.Text) - Math.Truncate(Convert.ToDouble(entry.Text))) * 60 - Math.Truncate((Convert.ToDouble(entry.Text) - Math.Truncate(Convert.ToDouble(entry.Text))) * 60)) * 60 + "''";
            }
        }

        /// <summary>
        /// ���������� ����� ������ �����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void FE(object? sender, RoutedEventArgs e)
        {
            if (entry.Text != "" && entry.Text.Contains("E+") == true)
            {
                string bas = "1";
                for (int i = 0; i < Convert.ToInt32(entry.Text.Substring(entry.Text.IndexOf("+") + 1)); i++)
                {
                    bas += "0";
                }
                entry.Text = Convert.ToString(Convert.ToDouble(entry.Text.Substring(0, entry.Text.IndexOf("E"))) * Convert.ToDouble(bas));
            }
        }

        /// <summary>
        /// ���������������� ����� ������ �����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Exp(object? sender, RoutedEventArgs e)
        {
            if (entry.Text != "" && entry.Text.Contains("E+") == false)
            {
                string bas = "1";
                for (int i = 0; i < entry.Text.Length; i++)
                {
                    bas += "0";
                }
                entry.Text = Convert.ToString((double)Convert.ToDouble(entry.Text) / Convert.ToDouble(bas)) + "E+" + entry.Text.Length;
            }
        }

        /// <summary>
        /// ��������� (��� ������)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Factorial(object? sender, RoutedEventArgs e)
        {
            if (entry.Text != "" && entry.Text.Contains(",") == false)
            {
                entry.Text = Convert.ToString(Fact(Convert.ToInt32(entry.Text)));
            }
        }

        /// <summary>
        /// ���������
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int Fact(int n)
        {
            if (n == 1)
            {
                return 1;
            }
            else
            {
                return n * Fact(n - 1);
            }
        }
    }
}