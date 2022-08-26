using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Text.RegularExpressions;
using System.Threading;                     // для задержки выполнения действий

namespace proekt
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        Repository repository = new Repository();
        string spetialisation_value;
        bool flagSurname = false;
        bool flagPassword = false;
        bool flagCheck = false;        

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            string surnameReg = @"\w{2,}";                                          // рег.выраж. для проверки фамилий
            string nameReg = @"\w{2,} \w*";                                         // рег.выраж. для проверки ИО
            string passwordReg = @"[\w\d]{6,20}";                                   // рег.выраж. для проверки паролей

            // проверка фамилий
            if(Regex.IsMatch(surnameTextBox.Text, surnameReg))
            {                
                flagSurname = true;
            }
            else
            {
                info1.Foreground = Brushes.Crimson;       // иначе шрифт и цвет информационного блока меняется,
                info1.FontSize = 16;                    // чтобы акцентировать внимание на требования к регистрации
            }           

            // проверка паролей
            if (Regex.IsMatch(passwordTextBox.Text, passwordReg))
            {                
                flagPassword = true;
            }
            else
            {
                info2.Foreground = Brushes.Crimson;       // иначе шрифт и цвет информационного блока меняется,
                info2.FontSize = 16;                    // чтобы акцентировать внимание на требования к регистрации
            }           

            if(flagSurname && flagPassword && flagCheck)
            {                 
                repository.AddSurname(surnameTextBox.Text);                        // если соответствует рег.выраж., то добавляется в лист

                // проверка ИО (это необязательное поле, поэтому требования минимальные)
                if (Regex.IsMatch(nameTextBox.Text, nameReg))
                {
                    repository.AddName(nameTextBox.Text);                         // если соответствует рег.выраж., то добавляется в лист
                }
                else
                    repository.AddName(" ");                                      // если не соответствует, добавляется пустой элемент

                repository.AddPassword(passwordTextBox.Text);                     // если соответсвует рег.выраж., то добавляется в лист
                repository.AddSpetialisation(spetialisation_value);               // добавление выбраннной специальности в лист
                info3.Content = "   Регистрация прошла успешно!";
                continueButton.IsEnabled = true;                        // кнопка перехода на форму входа становится активной
                backButton.IsEnabled = false;
                Thread.Sleep(500);                                      // задержка в 0.5 секунд

                // создаются или дописываются файлы для хранения данных (пока это вместо БД)
                repository.CreateSurnameFile(@"surname.txt");
                repository.CreateNameFile(@"name.txt");
                repository.CreatePasswordFile(@"password.txt");
                repository.CreateSpetialisationFile(@"spetialisation.txt");
            }
            else
            {
                surnameTextBox.Clear();         // иначе все поля очищаются для повторной регистрации
                nameTextBox.Clear();
                passwordTextBox.Clear();
            }            
        }

        private void SpetialisationListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            spetialisation_value = spetialisationListBox.SelectedValue.ToString().Replace("System.Windows.Controls.ListBoxItem:","");      // выбор спецализации
            flagCheck = true;
        }

        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StartPage());         // возврат на страницу входа            
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StartPage());         // возврат на страницу входа            
        }
    }
}
