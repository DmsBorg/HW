using System;

namespace My_Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            DictionaryActions.LoadDictionaries();

            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=== Меню ===\n");
                Console.WriteLine("1. Создать словарь");
                Console.WriteLine("2. Открыть словарь");
                Console.WriteLine("3. Удалить словарь");
                Console.WriteLine("4. Просмотреть список словарей");
                Console.WriteLine("5. Выйти");
                Console.Write("Выберите действие (1-5): ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        DictionaryActions.CreateDictionary();
                        break;
                    case "2":
                        DictionaryActions.OpenDictionary();
                        break;
                    case "3":
                        DictionaryActions.DeleteDictionary();
                        break;
                    case "4":
                        DisplayContent.ViewDictionaries();
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                        break;
                }

                Console.WriteLine();
                Console.WriteLine("Нажмите любую клавишу для продолжения:");
                Console.ReadKey();
            }
        }
    }
}
