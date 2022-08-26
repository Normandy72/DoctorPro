using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace proekt
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        Repository repository = new Repository();       

        public MainPage()
        {
            InitializeComponent();
            repository.CreateDirectory(@"temp");
            if (File.Exists(@"enter.txt"))
            {
                string[] docName = File.ReadAllLines(@"enter.txt");
                doctor.Content = "Врач __________________________________" + docName[0];
            }
            else
                doctor.Content = "Врач __________________________________";
            date.Content = "Дата: " + DateTime.Now.ToString("dd.MM.yyyy") + "  " + DateTime.Now.ToString("HH:mm");
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (File.Exists(@"enter.txt"))
            {
                string[] docName = File.ReadAllLines(@"enter.txt");
                header.Content = "В системе работает: врач  " + docName[0];
            }
            else
                header.Content = "В системе работает: Неизвестный";
        }

        private void OAK_Click(object sender, RoutedEventArgs e)
        {
            commonBloodAnalysis.Visibility = Visibility.Visible;
        }

        private void CloseButton_1_Click(object sender, RoutedEventArgs e)
        {
            commonBloodAnalysis.Visibility = Visibility.Hidden;
        }

        private void OAM_Click(object sender, RoutedEventArgs e)
        {
            commonUrineAnalysis.Visibility = Visibility.Visible;
        }

        private void CloseButton_2_Click(object sender, RoutedEventArgs e)
        {
            commonUrineAnalysis.Visibility = Visibility.Hidden;
        }

        private void БАК_Click(object sender, RoutedEventArgs e)
        {
            biochemicalBloodAnalysis.Visibility = Visibility.Visible;
        }

        private void CloseButton_3_Click(object sender, RoutedEventArgs e)
        {
            biochemicalBloodAnalysis.Visibility = Visibility.Hidden;
        }

        private void Коагулограмма_Click(object sender, RoutedEventArgs e)
        {
            coagulogramma.Visibility = Visibility.Visible;
        }

        private void CloseButton_4_Click(object sender, RoutedEventArgs e)
        {
            coagulogramma.Visibility = Visibility.Hidden;
        }

        private void Копрограмма_Click(object sender, RoutedEventArgs e)
        {
            coprogramma.Visibility = Visibility.Visible;
        }

        private void CloseButton_5_Click(object sender, RoutedEventArgs e)
        {
            coprogramma.Visibility = Visibility.Hidden;
        }

        private void ЭКГ_Click(object sender, RoutedEventArgs e)
        {
            ecg.Visibility = Visibility.Visible;
        }

        private void CloseButton_6_Click(object sender, RoutedEventArgs e)
        {
            ecg.Visibility = Visibility.Hidden;
        }

        private void Weight_Click(object sender, RoutedEventArgs e)
        {
            childWeight.Visibility = Visibility.Visible;
        }

        private void CloseButton_7_Click(object sender, RoutedEventArgs e)
        {
            childWeight.Visibility = Visibility.Hidden;
        }

        private void Height_Click(object sender, RoutedEventArgs e)
        {
            childHeight.Visibility = Visibility.Visible;
        }

        private void CloseButton_8_Click(object sender, RoutedEventArgs e)
        {
            childHeight.Visibility = Visibility.Hidden;
        }

        private void Head_Click(object sender, RoutedEventArgs e)
        {
            childHead.Visibility = Visibility.Visible;
        }

        private void CloseButton_9_Click(object sender, RoutedEventArgs e)
        {
            childHead.Visibility = Visibility.Hidden;
        }

        private void Thorax_Click(object sender, RoutedEventArgs e)
        {
            childThorax.Visibility = Visibility.Visible;
        }

        private void CloseButton_10_Click(object sender, RoutedEventArgs e)
        {
            childThorax.Visibility = Visibility.Hidden;
        }

        private void Area_Click(object sender, RoutedEventArgs e)
        {
            areaOfBody.Visibility = Visibility.Visible;
        }

        private void CloseButton_11_Click(object sender, RoutedEventArgs e)
        {
            areaOfBody.Visibility = Visibility.Hidden;
            heightTextBox.Clear();
            weightTextBox.Clear();
            areaLabel.Content = "";
        }

        private void AreaButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double height = double.Parse(heightTextBox.Text);
                double weight = double.Parse(weightTextBox.Text);
                double result = Math.Round((Math.Sqrt(height * weight) / 60), 1);
                areaLabel.Content = result.ToString() + " м.кв.";
            }
            catch
            {
                areaLabel.Content = "Неверный формат данных!";
                areaLabel.Foreground = System.Windows.Media.Brushes.Coral;
            }
        }

        private void Ibm_Click(object sender, RoutedEventArgs e)
        {
            indexBodyMass.Visibility = Visibility.Visible;
        }

        private void CloseButton_12_Click(object sender, RoutedEventArgs e)
        {
            indexBodyMass.Visibility = Visibility.Hidden;
            heightTB.Clear();
            weightTB.Clear();
            indexLabel.Content = "";
        }

        private void IndexButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double height = double.Parse(heightTB.Text);
                double weight = double.Parse(weightTB.Text);
                double result = Math.Round(weight / Math.Pow(height, 2), 1);
                if(result < 18.5)
                {
                    indexLabel.Foreground = System.Windows.Media.Brushes.Blue;
                }
                else if(result >= 18.5 && result < 25)
                {
                    indexLabel.Foreground = System.Windows.Media.Brushes.Green;
                }
                else
                {
                    indexLabel.Foreground = System.Windows.Media.Brushes.Red;
                }
                indexLabel.Content = result.ToString() + " кг/м.кв.";
            }
            catch
            {
                indexLabel.Content = "Неверный формат данных!";
                indexLabel.Foreground = System.Windows.Media.Brushes.Red;
            }            
        }

        object d_value, m_value, y_value;        

        private void Day_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            d_value = day.SelectedItem;
        }

        private void Month_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            m_value = month.SelectedItem;
        }

        private void Year_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            y_value = year.SelectedItem;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)       // возврат на страницу входа
        {
            this.NavigationService.Navigate(new StartPage());
        }

        private void aboutProgram_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Данная программа разработана студенткой\nгруппы 42121(ПОИС) СЛИЖЕВСКОЙ Е.Е.\nв качестве курсового проекта.\nДля вызова справки нажмите F1", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        string reg = "System.Windows.Controls.ListBoxItem:";

        private void ReadyButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PrePrintPage());         // переход на страницу предварительного просмотра

            // ниже создаются файлы для временного хранения информации, далее она будет нужна для предварительного просмотра печати

            repository.CreateFile(@"temp\name.txt", nameTB.Text);
            repository.CreateFile(@"temp\dateOfBirth.txt", Regex.Replace(d_value.ToString(), reg, "") + "." + Regex.Replace(m_value.ToString(), reg, "") + "." + Regex.Replace(y_value.ToString(), reg, ""));
            if (sexFemale.IsChecked == true)
            {
               repository.CreateFile(@"temp\female.txt", sexFemale.Content.ToString());
               if (File.Exists(@"temp\male.txt"))
                   File.Delete(@"temp\male.txt");
            }
            else
            {
                repository.CreateFile(@"temp\male.txt", sexMale.Content.ToString());
                if (File.Exists(@"temp\female.txt"))
                    File.Delete(@"temp\female.txt");
            }                

            System.Windows.Documents.TextRange range1 = new System.Windows.Documents.TextRange(complaintsRTB.Document.ContentStart, complaintsRTB.Document.ContentEnd);
            repository.CreateFile(@"temp\complaints.txt", range1.Text);

            System.Windows.Documents.TextRange range2 = new System.Windows.Documents.TextRange(anamnesisRTB.Document.ContentStart, anamnesisRTB.Document.ContentEnd);
            repository.CreateFile(@"temp\anamnesis.txt", range2.Text);

            System.Windows.Documents.TextRange range3 = new System.Windows.Documents.TextRange(skinRTB.Document.ContentStart, skinRTB.Document.ContentEnd);
            repository.CreateFile(@"temp\skin.txt", range3.Text);

            System.Windows.Documents.TextRange range4 = new System.Windows.Documents.TextRange(pulmoRTB.Document.ContentStart, pulmoRTB.Document.ContentEnd);
            repository.CreateFile(@"temp\pulmo.txt", range4.Text);

            System.Windows.Documents.TextRange range5 = new System.Windows.Documents.TextRange(cardioRTB.Document.ContentStart, cardioRTB.Document.ContentEnd);
            repository.CreateFile(@"temp\cardio.txt", range5.Text);

            System.Windows.Documents.TextRange range6 = new System.Windows.Documents.TextRange(gastroRTB.Document.ContentStart, gastroRTB.Document.ContentEnd);
            repository.CreateFile(@"temp\gastro.txt", range6.Text);
            
            System.Windows.Documents.TextRange range7 = new System.Windows.Documents.TextRange(bonesRTB.Document.ContentStart, bonesRTB.Document.ContentEnd);
            repository.CreateFile(@"temp\bones.txt", range7.Text);

            System.Windows.Documents.TextRange range8 = new System.Windows.Documents.TextRange(neuroRTB.Document.ContentStart, neuroRTB.Document.ContentEnd);
            repository.CreateFile(@"temp\neuro.txt", range8.Text);

            System.Windows.Documents.TextRange range9 = new System.Windows.Documents.TextRange(diagnosisRTB.Document.ContentStart, diagnosisRTB.Document.ContentEnd);
            repository.CreateFile(@"temp\diagnosis.txt", range9.Text);

            System.Windows.Documents.TextRange range10 = new System.Windows.Documents.TextRange(diagnosticRTB.Document.ContentStart, diagnosticRTB.Document.ContentEnd);
            repository.CreateFile(@"temp\diagnostic.txt", range10.Text);

            System.Windows.Documents.TextRange range11 = new System.Windows.Documents.TextRange(therapyRTB.Document.ContentStart, therapyRTB.Document.ContentEnd);
            repository.CreateFile(@"temp\therapy.txt", range11.Text);

            repository.CreateFile(@"temp\doctor.txt", doctor.Content.ToString());

            repository.CreateFile(@"temp\date.txt", date.Content.ToString());
         
        }
    }
}
