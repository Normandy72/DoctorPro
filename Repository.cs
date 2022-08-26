using System.Collections.Generic;
using System.IO;

namespace proekt
{
    // класс для хранения различных методов
    class Repository                            
    {
        private static List<string> surname = new List<string>();                   // лист для хранения фамилий
        private static List<string> name = new List<string>();                      // лист для хранения ИО
        private static List<string> password = new List<string>();                  // лист для хранения паролей
        private static List<string> spetialisation = new List<string>();            // лист для хранения специализаций
        
        public void AddSurname(string s)                                    // метод для добавления фамилии в лист
        {
            surname.Add(s);
        }

        public void AddName(string n)                                       // метод для добавления имени а лист
        {
            name.Add(n);
        }

        public void AddPassword(string p)                                   // метод для добавления пароля в лист
        {
            password.Add(p);
        }

        public void AddSpetialisation(string spec)                          // метод для добавления специализации в лист
        {
            spetialisation.Add(spec);
        }

        public void CreateSurnameFile(string path)                          // метод для создания файла для фамилий
        {
            using (StreamWriter sw = new StreamWriter(path, true))          // файл дописывается
            {
                foreach(string sur in surname)
                {
                    sw.WriteLine(sur);
                }
            }
        }

        public void CreateNameFile(string path)                             // метод для создания файла для имен
        {
            using (StreamWriter sw = new StreamWriter(path, true))          // файл дописывается
            {
                foreach (string n in name)
                {
                    sw.WriteLine(n);
                }
            }
        }

        public void CreatePasswordFile(string path)                         // метод для создания файла для паролей
        {
            using (StreamWriter sw = new StreamWriter(path, true))          // файл дописывается
            {
                foreach (string pass in password)
                {
                    sw.WriteLine(pass);
                }
            }
        }

        public void CreateSpetialisationFile(string path)                   // метод для создания файла для специализации
        {
            using (StreamWriter sw = new StreamWriter(path, false))          // файл перезаписывается
            {
                foreach (string spec in spetialisation)
                {
                    sw.WriteLine(spec);
                }
            }
        }

        public void CreateFile(string path, object e)                    // метод для создания файлов
        {
            using (StreamWriter sw = new StreamWriter(path, false))
            {
                sw.WriteLine(e);
            }           
        }

        public void CreateDirectory(string path)                        // метод создания папки
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            if (!directory.Exists)
            {
                directory.Create();
            }
        }
    }
}
