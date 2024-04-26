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
            1. Нет документации (непонятно, как пользоваться, если не знаешь)
            2. Окно приложения можно уменьшить так, что не все кнопки будут доступны
            3. Нет ввода с клавиатуры
            4. Невозможно выделить курсором результат вычислений
            5. При вводе можно выйти за границу окна и ничего не будет видно
            6. Скобки не работают (не написан код)
            7. При вычислении функций не подписывается, какая функция вычисляется
            8. За один подход производится только одно действие
            9. При повторном нажатии кнопки = не повторяется последнее действие
            10. Флажки с единицами измерения бесполезны (нет применения в вычислениях)
            11. При очень большом результате вычислений в ответ выводится знак бесконечности
            12. Факториал считается только до 33, больше - выдаёт 0
            13. Перевод в десятичную форму записи из экспоненциальной не работает на очень больших числах
            14. Извлечение корня произвольной степени не работает (не написан код)
            15. Число пи нормально не переводится в экспоненциальную форму и обратно
            16. При пустом поле ввода Ln не считает функцию от нуля
            17. При пустом поле ввода Int не считает функцию от нуля
            18. При пустом поле ввода sinh не считает функцию от нуля
            19. При пустом поле ввода sin не считает функцию от нуля
            20. При пустом поле ввода x^2 не считает функцию от нуля
            21. При пустом поле ввода n! не считает функцию от нуля
            22. При пустом поле ввода dms не считает функцию от нуля
            23. При пустом поле ввода cosh не считает функцию от нуля
            24. При пустом поле ввода cos не считает функцию от нуля
            25. При пустом поле ввода x^n не считает функцию от нуля
            26. При пустом поле ввода nrx не считает функцию от нуля
            27. При пустом поле ввода tanh не считает функцию от нуля
            28. При пустом поле ввода tan не считает функцию от нуля
            29. При пустом поле ввода x^3 не считает функцию от нуля
            30. При пустом поле ввода 3rx не считает функцию от нуля
            31. При пустом поле ввода Mod не считает функцию от нуля
            32. При пустом поле ввода log не считает функцию от нуля
            33. При пустом поле ввода 10^x не считает функцию от нуля
            34. Флажок Inv не работает
            35. При нажатии + приложение вылетает
            36. При нажатии - приложение вылетает
            37. При нажатии / приложение вылетает
            38. При нажатии * приложение вылетает
            */

            InitializeComponent();
            entry.Text = "";
        }

        /// <summary>
        /// Чтобы RadioButton Degrees отжималась
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
        /// Чтобы RadioButton Radians отжималась
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
        /// Чтобы RadioButton Grads отжималась
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
        /// Чтобы RadioButton Inv отжималась
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
        /// Значение выражения (для кнопки)
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
        /// Значение выражения
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
        /// Стереть последний символ
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
        /// Очистить ввод и память
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Clear(object? sender, RoutedEventArgs e)
        {
            entry.Text = "";
            memory = "";
        }

        /// <summary>
        /// Очистить ввод
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ClearEntry(object? sender, RoutedEventArgs e)
        {
            entry.Text = "";
        }

        /// <summary>
        /// Очистить память
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MemoryClear(object? sender, RoutedEventArgs e)
        {
            memory = "";
        }

        /// <summary>
        /// Сохранить в память
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MemorySave(object? sender, RoutedEventArgs e)
        {
            if (entry.Text != "") //можно убрать
            {
                memory = entry.Text;
            }
        }

        /// <summary>
        /// Отобразить память
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MemoryRead(object? sender, RoutedEventArgs e)
        {
            if (memory != "") //можно убрать
            {
                entry.Text = memory;
            }
        }

        /// <summary>
        /// Сложить память и ввод
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MemoryPlus(object? sender, RoutedEventArgs e)
        {
            if (entry.Text != "" && memory != "") //можно убрать
            {
                entry.Text = Convert.ToString(Convert.ToDouble(memory) + Convert.ToDouble(entry.Text));
            }
        }

        /// <summary>
        /// Вычесть ввод из памяти
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MemoryMinus(object? sender, RoutedEventArgs e)
        {
            if (entry.Text != "" && memory != "") //можно убрать
            {
                entry.Text = Convert.ToString(Convert.ToDouble(memory) - Convert.ToDouble(entry.Text));
            }
        }

        /// <summary>
        /// Число пи
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
        /// Цифра ноль
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
        /// Цифра один
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void One(object? sender, RoutedEventArgs e)
        {
            entry.Text += "1";
        }

        /// <summary>
        /// Цифра два
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Two(object? sender, RoutedEventArgs e)
        {
            entry.Text += "2";
        }

        /// <summary>
        /// Цифра три
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Three(object? sender, RoutedEventArgs e)
        {
            entry.Text += "3";
        }

        /// <summary>
        /// Цифра четыре
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Four(object? sender, RoutedEventArgs e)
        {
            entry.Text += "4";
        }

        /// <summary>
        /// Цифра пять
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Five(object? sender, RoutedEventArgs e)
        {
            entry.Text += "5";
        }

        /// <summary>
        /// Цифра шесть
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Six(object? sender, RoutedEventArgs e)
        {
            entry.Text += "6";
        }

        /// <summary>
        /// Цифра семь
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Seven(object? sender, RoutedEventArgs e)
        {
            entry.Text += "7";
        }

        /// <summary>
        /// Цифра восемь
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Eight(object? sender, RoutedEventArgs e)
        {
            entry.Text += "8";
        }

        /// <summary>
        /// Цифра девять
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Nine(object? sender, RoutedEventArgs e)
        {
            entry.Text += "9";
        }

        /// <summary>
        /// Запятая
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
        /// Открывающаяся скобка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BracketStart(object? sender, RoutedEventArgs e)
        {
            
        }

        /// <summary>
        /// Закрывающаяся скобка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BracketEnd(object? sender, RoutedEventArgs e)
        {
             
        }

        /// <summary>
        /// Сложение
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
        /// Вычитание
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
        /// Умножение
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
        /// Деление
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
        /// Процент от числа
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
        /// Остаток от деления
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
        /// Возведение в указанную степень
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
        /// Корень указанной степени
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
        /// Инверсия
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
        /// Выделение целой части
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
        /// Дробь с единицей в числителе и вводом в знаменателе
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
        /// десятичный логарифм
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
        /// Натуральный логарифм
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
        /// Квадрат числа
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
        /// Квадратный корень
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
        /// Куб числа
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
        /// Кубический корень
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
        /// 10 в степени ввода
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
        /// Синус или арксинус
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
        /// Гиперболический синус или арксинус
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
        /// Косинус или арккосинус
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
        /// Гиперболический косинус или арккосинус
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
        /// Тангенс или арктангенс
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
        /// Гиперболический тангенс или арктангенс
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
        /// Перевод в градусы-минуты-секунды из градусов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Dms(object? sender, RoutedEventArgs e)
        {
            if (entry.Text != "")
            {
                entry.Text = Math.Truncate(Convert.ToDouble(entry.Text)) + "°" + Math.Truncate((Convert.ToDouble(entry.Text) - Math.Truncate(Convert.ToDouble(entry.Text))) * 60) + "'" + ((Convert.ToDouble(entry.Text) - Math.Truncate(Convert.ToDouble(entry.Text))) * 60 - Math.Truncate((Convert.ToDouble(entry.Text) - Math.Truncate(Convert.ToDouble(entry.Text))) * 60)) * 60 + "''";
            }
        }

        /// <summary>
        /// Десятичная форма записи числа
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
        /// Экспоненциальная форма записи числа
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
        /// Факториал (для кнопки)
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
        /// Факториал
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