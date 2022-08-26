using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace proekt
{
    /// <summary>
    /// Логика взаимодействия для PrePrintPage.xaml
    /// </summary>
    public partial class PrePrintPage : Page
    {
        Repository repository = new Repository();

        public PrePrintPage()
        {
            InitializeComponent();
            repository.CreateDirectory(@"protocols");
        }
        string str1, str2, str3, str4, str5, str6, str7, str8, str9, str10, str11, str12, str13, str14, str15, str16, str17, text;

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            str1 = File.ReadAllText(@"temp\name.txt");
            name.Content = str1;

            str2 = File.ReadAllText(@"temp\dateOfBirth.txt");
            dateOfBirth.Content = str2;

            if (File.Exists(@"temp\female.txt"))
            {
                str3 = File.ReadAllText(@"temp\female.txt");
                sex.Content = str3;
            }
            else
            {
                str4 = File.ReadAllText(@"temp\male.txt");
                sex.Content = str4;
            }
               
            str5 = File.ReadAllText(@"temp\complaints.txt");
            complaints.Content = str5;

            str6 = File.ReadAllText(@"temp\anamnesis.txt");
            anamnesis.Content = str6;

            str7 = File.ReadAllText(@"temp\skin.txt");
            skin.Content = str7;

            str8 = File.ReadAllText(@"temp\pulmo.txt");
            pulmo.Content = str8;

            str9 = File.ReadAllText(@"temp\cardio.txt");
            cardio.Content = str9;

            str10 = File.ReadAllText(@"temp\gastro.txt");
            gastro.Content = str10;

            str11 = File.ReadAllText(@"temp\bones.txt");
            bones.Content = str11;

            str12 = File.ReadAllText(@"temp\neuro.txt");
            neuro.Content = str12;

            str13 = File.ReadAllText(@"temp\diagnosis.txt");
            diagnosis.Content = str13;

            str14 = File.ReadAllText(@"temp\diagnostic.txt");
            diagnistic.Content = str14;

            str15 = File.ReadAllText(@"temp\therapy.txt");
            therapy.Content = str15;

            str16 = File.ReadAllText(@"temp\doctor.txt");
            doctor.Content = str16;

            str17 = File.ReadAllText(@"temp\date.txt");
            date.Content = str17;
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog dialog = new PrintDialog();
            if (dialog.ShowDialog() == true)
            {                
                dialog.PrintVisual(stack, "Печать протокола...");
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(@"temp\female.txt"))
            {
               text = "Ф.И.О. пациента: " + str1 + "\nДата рождения: " + str2 + "\nПол: " + str3 + "\nЖалобы: " + str5 +
                    "\nАнамнез: " + str6 + "\nКожа и слизистые: " + str7 + "\nДыхательная система: " + str8 +
                    "\nСердечно-сосудистая система: " + str9 + "\nЖелудочно-кишечный тракт: " + str10 + "\nОпорно-двигательный аппарат: " + str11 +
                    "\nНервная система: " + str12 + "\nПредварительный диагноз: " + str13 + "\nПлан обследования: " + str14 +
                    "\nПлан лечения: " + str15 + "\n" + str16 + "\n" + str17;
            }
            else
            {
                text = "Ф.И.О. пациента: " + str1 + "\nДата рождения: " + str2 + "\nПол: " + str4 + "\nЖалобы: " + str5 +
                    "\nАнамнез: " + str6 + "\nКожа и слизистые: " + str7 + "\nДыхательная система: " + str8 +
                    "\nСердечно-сосудистая система: " + str9 + "\nЖелудочно-кишечный тракт: " + str10 + "\nОпорно-двигательный аппарат: " + str11 +
                    "\nНервная система: " + str12 + "\nПредварительный диагноз: " + str13 + "\nПлан обследования: " + str14 +
                    "\nПлан лечения: " + str15 + "\n" + str16 + "\n" + str17;
            }
            
            string path = @"protocols\Протокол_" + DateTime.Now.ToString("dd-MM-yy_HH-mm-ss") + ".txt";
            repository.CreateFile(path, text);
           
            MessageBox.Show("Файл успешно сохранен!\nПуть к файлу: " + path, "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            NavigationService.Navigate(new MainPage());
        }

        private void saveAndEsc_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(@"temp\female.txt"))
            {
                text = "Ф.И.О. пациента: " + str1 + "\nДата рождения: " + str2 + "\nПол: " + str3 + "\nЖалобы: " + str5 +
                     "\nАнамнез: " + str6 + "\nКожа и слизистые: " + str7 + "\nДыхательная система: " + str8 +
                     "\nСердечно-сосудистая система: " + str9 + "\nЖелудочно-кишечный тракт: " + str10 + "\nОпорно-двигательный аппарат: " + str11 +
                     "\nНервная система: " + str12 + "\nПредварительный диагноз: " + str13 + "\nПлан обследования: " + str14 +
                     "\nПлан лечения: " + str15 + "\n" + str16 + "\n" + str17;
            }
            else
            {
                text = "Ф.И.О. пациента: " + str1 + "\nДата рождения: " + str2 + "\nПол: " + str4 + "\nЖалобы: " + str5 +
                    "\nАнамнез: " + str6 + "\nКожа и слизистые: " + str7 + "\nДыхательная система: " + str8 +
                    "\nСердечно-сосудистая система: " + str9 + "\nЖелудочно-кишечный тракт: " + str10 + "\nОпорно-двигательный аппарат: " + str11 +
                    "\nНервная система: " + str12 + "\nПредварительный диагноз: " + str13 + "\nПлан обследования: " + str14 +
                    "\nПлан лечения: " + str15 + "\n" + str16 + "\n" + str17;
            }

            string path = @"protocols\Протокол_" + DateTime.Now.ToString("dd-MM-yy_HH-mm-ss") + ".txt";
            repository.CreateFile(path, text);

            MessageBoxResult result = MessageBox.Show("Сохранить файл и выйти из программы?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                MessageBox.Show("Файл успешно сохранен!\nПуть к файлу: " + path, "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                Application.Current.Shutdown();
            }
        }
    }
}
