using System.Windows;
using System.Windows.Input;

namespace proekt
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.WindowState = WindowState.Normal;
            MainFrame.Content = new StartPage();           
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                MessageBox.Show("1. Для входа в программу необходимо зарегистрироваться.\n" +
                    "2. При входе в программу необходимо ввести логин и пароль.\n" +
                    "3. Для создания протокола введите в поля необходимые данные и нажмите кнопку \"Готово\"\n" +
                    "4. После создания протокола выберите действие:\n1) сохранить и продолжить, чтобы вернуться на главную\n" +
                    "    страницу и продолжить создание протоколов;\n" +
                    "2) сохранить и выйти, чтобы завершить работу с программой;\n" +
                    "3) печать, чтобы распечатать готовый протокол;\n" +
                    "4) отмена, чтобы вернуться к форме текущего протокола.", "Справка", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
