using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace proekt
{
    /// <summary>
    /// Логика взаимодействия для StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        public StartPage()
        {
            InitializeComponent();
        }

        Repository repository = new Repository();

        // при нажати на кнопку "зарегистрироваться" открывается страница регистрации
        private void LoginButton_Click(object sender, RoutedEventArgs e) 
        {
            NavigationService.Navigate(new RegistrationPage());
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            string password = passwordTextBox.Password;
            if (loginTextBox.Text != String.Empty && passwordTextBox.Password != String.Empty) // поля не должны быть пустыми
            {
                if (File.Exists(@"surname.txt"))
                {
                    string[] login = File.ReadAllLines(@"surname.txt");
                    foreach (string log in login)
                    {
                        if (log == loginTextBox.Text)
                        {
                            string[] pass = File.ReadAllLines(@"password.txt");
                            foreach (string p in pass)
                            {
                                if (p == password)
                                {
                                    NavigationService.Navigate(new MainPage());                                    
                                }
                                else
                                    errorLabel.Content = "  Неверный логин и/или пароль!";
                            }
                            repository.CreateFile(@"enter.txt", loginTextBox.Text);
                        }
                        else
                            errorLabel.Content = "  Неверный логин и/или пароль!";                        
                    }
                }
                else
                    errorLabel.Content = "\tВведите логин и пароль!";
            }
            else errorLabel.Content = "  Пожалуйста, зарегистрируйтесь.";                
        }
    }
}
