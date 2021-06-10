using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int b = 0;
        public List<string> name = new List<string>();
        public List<string> surename = new List<string>();
        public List<string> otchestvo = new List<string>();
        public List<string> mail = new List<string>();
        public List<string> nomer = new List<string>();
        public List<string> snils = new List<string>();
        bool provmail = false;
        bool provnomer = false;
        bool provsnils = false;
        bool provname = false;
        bool provsurename = false;
        bool provotchestvo = false;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void dobavka_Click(object sender, RoutedEventArgs e)
        {
            if (provmail == true && provnomer == true && provsnils == true && provname == true && provsurename == true && provotchestvo == true)
            {
                name.Add(nameT.Text);
                surename.Add(surenameT.Text);
                otchestvo.Add(otchestvoT.Text);
                mail.Add(mailT.Text);
                nomer.Add(nomerT.Text);
                snils.Add(snilsT.Text);
                listBox.Items.Add($"Имя: {name[b]}\nФамилия: {surename[b]}\nОтчество: {otchestvo[b]}\nПочта: {mail[b]}\nНомер телефона: {nomer[b]}\nСНИЛС: {snils[b]}");
                b++;
            }
        }

        private void udalenie_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < listBox.Items.Count; i++)
            {

                if (deleteText.Text.Equals(surename[i]))
                {
                    listBox.Items.Remove($"Имя: {name[i]}\nФамилия: {surename[i]}\nОтчество: {otchestvo[i]}\nПочта: {mail[i]}\nНомер телефона: {nomer[i]}\nСНИЛС: {snils[i]}");   
                    name.RemoveAt(i);
                    surename.RemoveAt(i);
                    otchestvo.RemoveAt(i);
                    mail.RemoveAt(i);
                    nomer.RemoveAt(i);
                    snils.RemoveAt(i);
                    b--;
                }
            }
        }
        private void poisk_Click(object sender, RoutedEventArgs e)
        {
            //Window1 taskWindow = new Window1();
            //taskWindow.Show();
            int ct = 0;
            listBox.Items.Clear();
            for (int i = 0; i < b; i++)
            {
                if (poiskovik.Text.Equals(name[i]) || poiskovik.Text.Equals(surename[i]) || poiskovik.Text.Equals(otchestvo[i]))
                {
                    listBox.Items.Add($"Имя: {name[i]}\nФамилия: {surename[i]}\nОтчество: {otchestvo[i]}\nПочта: {mail[i]}\nНомер телефона: {nomer[i]}\nСНИЛС: {snils[i]}");
                    ct++;
                }
            }
            if (ct == 0)
            {
                for (int i = 0; i < b; i++)
                {
                    listBox.Items.Add($"Имя: {name[i]}\nФамилия: {surename[i]}\nОтчество: {otchestvo[i]}\nПочта: {mail[i]}\nНомер телефона: {nomer[i]}\nСНИЛС: {snils[i]}");
                }
            }
        }
        private void snilsT_TextChanged(object sender, TextChangedEventArgs e)
        {
            snilsT.MaxLength = 14;
            int ct = 0;
            for (int i = 0; i < snilsT.Text.Length; i++)
            {
                if (char.IsDigit(snilsT.Text[i]))
                {
                    ct++;
                }
            }
            if (snilsT.Text.Length == 3)
            {
                snilsT.Text += '-';
                snilsT.CaretIndex = 4;
            }
            else if (snilsT.Text.Length == 7)
            {
                snilsT.Text += '-';
                snilsT.CaretIndex = 8;
            }
            if (snilsT.Text.Length == 11)
            {
                snilsT.Text += '-';
                snilsT.CaretIndex = 12;
            }

            if (snilsT.Text.Length == 14 && ct == 11)
            {
                tSnils.Text = "Проверка пройдена успешно";
                tSnils.Foreground = Brushes.LightGreen;
                provsnils = true;
            }
            else if (snilsT.Text.Length == 0)
            {
                tSnils.Text = "Поле не заполнено";
                tSnils.Foreground = Brushes.LightSlateGray;
                provsnils = false;
            }
            else
            {
                tSnils.Text = "СНИЛС введён неверно";
                tSnils.Foreground = Brushes.IndianRed;
                provsnils = false;
            }
        }
        private void mailT_TextChanged(object sender, TextChangedEventArgs e)
        {
            string simvols = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
             + "@"+ @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$";

            if (Regex.IsMatch(mailT.Text, simvols, RegexOptions.IgnoreCase))
            {
                tMail.Text = "Проверка пройдена успешно";
                tMail.Foreground = Brushes.LightGreen;
                provmail = true;
            }
            else if (mailT.Text.Length == 0)
            {
                tMail.Text = "Поле не заполнено";
                tMail.Foreground = Brushes.LightSlateGray;
                provmail = false;
            }
            else
            {
                tMail.Text = "e-mail введён неверно";
                tMail.Foreground = Brushes.IndianRed;
                provmail = false;
            }
        }
        private void nomerT_TextChanged(object sender, TextChangedEventArgs e)
        {
            nomerT.MaxLength = 11;
            int ct = 0;
            for (int i = 0; i < nomerT.Text.Length; i++)
            {
                if (char.IsDigit(nomerT.Text[i]))
                {
                    ct++;
                }
            }
            try
            {
                if ((nomerT.Text[0] == '8' || nomerT.Text[0] == '7') && nomerT.Text.Length == 11)
                {
                    tNomer.Text = "Проверка пройдена успешно";
                    tNomer.Foreground = Brushes.LightGreen;
                    provnomer = true;
                }
                else if (nomerT.Text.Length == 0)
                {
                    tNomer.Text = "Поле не заполнено";
                    tNomer.Foreground = Brushes.LightSlateGray;
                    provnomer = false;
                }
                else
                {
                    tNomer.Text = "Номер введён неверно";
                    tNomer.Foreground = Brushes.IndianRed;
                    provnomer = false;
                }
            }
            catch
            {
                tNomer.Text = "Номер введён неверно";
                tNomer.Foreground = Brushes.IndianRed;
                provnomer = false;
            }
        }
        private void nameT_TextChanged(object sender, TextChangedEventArgs e)
        {
            int ct = 0;
            for (int i = 0; i < nameT.Text.Length; i++)
            {
                if (char.IsLetter(nameT.Text[0]) != true)
                {
                    ct++;
                }
            }
            if (ct == 0 && nameT.Text.Length > 0)
            {
                tName.Text = "Проверка пройдена успешно";
                tName.Foreground = Brushes.LightGreen;
                provname = true;
            }
            else if (nameT.Text.Length == 0)
            {
                tName.Text = "Поле не заполнено";
                tName.Foreground = Brushes.LightSlateGray;
                provname = false;
            }
            else
            {
                tName.Text = "Имя введено неверно";
                tName.Foreground = Brushes.IndianRed;
                provname = false;
            }
        }
        private void surenameT_TextChanged(object sender, TextChangedEventArgs e)
        {
            int ct = 0;
            for (int i = 0; i < surenameT.Text.Length; i++)
            {
                if (char.IsLetter(surenameT.Text[i]) != true)
                {
                    ct++;
                }

            }
            if (ct == 0 && surenameT.Text.Length > 0)
            {
                tSure.Text = "Проверка пройдена успешно";
                tSure.Foreground = Brushes.LightGreen;
                provsurename = true;
            }
            else if (surenameT.Text.Length == 0)
            {
                tSure.Text = "Поле не заполнено";
                tSure.Foreground = Brushes.LightSlateGray;
                provsurename = false;
            }
            else
            {
                tSure.Text = "Фамилия введена неверно";
                tSure.Foreground = Brushes.IndianRed;
                provsurename = false;
            }
        }

        private void otchestvoT_TextChanged(object sender, TextChangedEventArgs e)
        {
            int ct = 0;
            for (int i = 0; i < otchestvoT.Text.Length; i++)
            {
                if (char.IsLetter(otchestvoT.Text[i]) != true)
                {
                    ct++;
                }

            }
            if (ct == 0 && otchestvoT.Text.Length > 0)
            {
                tOtch.Text = "Проверка пройдена успешно";
                tOtch.Foreground = Brushes.LightGreen;
                provotchestvo = true;
            }
            else if (otchestvoT.Text.Length == 0)
            {
                tOtch.Text = "Поле не заполнено";
                tOtch.Foreground = Brushes.LightSlateGray;
                provotchestvo = false;
            }
            else
            {
                tOtch.Text = "Отчество введено неверно";
                tOtch.Foreground = Brushes.IndianRed;
                provotchestvo = false;
            }
        }
    }
}
