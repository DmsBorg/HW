using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace My_Dictionary
{
    class DictionaryActions
    {
        private static string dictionariesFilePath = "dictionaries.json";
        private static List<Dictionary> dictionaries = new List<Dictionary>();

        public static List<Dictionary> Dictionaries
        {
            get { return dictionaries; }
        }

        public static void CreateDictionary()
        {
            Console.Write("Введите название словаря: ");
            string name = Console.ReadLine();

            if (dictionaries.Exists(n => n.Name == name))
            {
                Console.WriteLine("Словарь с таким названием уже существует.");
                return;
            }

            Dictionary newDictionary = new Dictionary { Name = name };
            dictionaries.Add(newDictionary);
            SaveDictionaries();

            Console.WriteLine($"Словарь '{name}' успешно создан.");

        }

        public static void OpenDictionary()
        {
            Console.Write("Введите название словаря: ");
            string name = Console.ReadLine();

            Dictionary dictionary = dictionaries.Find(n => n.Name == name);
            if (dictionary == null)
            {
                Console.WriteLine("Словарь не найден.");
                return;
            }

            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine($"Словарь: {dictionary.Name}");
                Console.WriteLine("=== Меню словаря ===");
                Console.WriteLine("1. Просмотреть все слова");
                Console.WriteLine("2. Добавить слово");
                Console.WriteLine("3. Вернуться в главное меню");
                Console.Write("Выберите действие (1-3): ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        DisplayContent.ViewDictionaryContains(dictionary);
                        break;
                    case "2":
                        AddDictionaryContains(dictionary);
                        break;
                    case "3":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                        break;
                }

                Console.WriteLine("Нажмите любую клавишу для продолжения:");
                Console.ReadKey();
            }
        }

        public static void DeleteDictionary()
        {
            Console.Write("Введите название словаря для удаления: ");
            string name = Console.ReadLine();

            Dictionary dictionary = dictionaries.Find(n => n.Name == name);
            if (dictionary == null)
            {
                Console.WriteLine("Словарь не найден.");
                return;
            }

            dictionaries.Remove(dictionary);
            SaveDictionaries();

            Console.WriteLine($"Словарь '{name}' успешно удален.");
        }

        public static void AddDictionaryContains(Dictionary dictionary)
        {
            Console.Write("Введите слово: ");
            string word = Console.ReadLine();

            Console.Write("Введите перевод: ");
            string translation = Console.ReadLine();

            DictionaryContent content = new DictionaryContent
            {
                Word = word,
                Translation = translation
            };

            dictionary.Contents.Add(content);
            SaveDictionaries();

            Console.WriteLine("Слово успешно добавлено в словарь.");
        }

        public static void LoadDictionaries()
        {
            if (File.Exists(dictionariesFilePath))
            {
                string json = File.ReadAllText(dictionariesFilePath);
                dictionaries = JsonConvert.DeserializeObject<List<Dictionary>>(json);
            }
        }

        public static void SaveDictionaries()
        {
            string json = JsonConvert.SerializeObject(dictionaries, Formatting.Indented);
            File.WriteAllText(dictionariesFilePath, json);
        }
    }
}
