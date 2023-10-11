using System;

namespace My_Dictionary
{
    class DisplayContent
    {
        public static void ViewDictionaries()
        {
            if (DictionaryActions.Dictionaries.Count > 0)
            {
                Console.WriteLine("Список словарей:");
                foreach (var dictionary in DictionaryActions.Dictionaries)
                {
                    Console.WriteLine(dictionary.Name);
                }
            }
            else
            {
                Console.WriteLine("Нет доступных словарей.");
            }
        }

        public static void ViewDictionaryContains(Dictionary dictionary)
        {
            Console.WriteLine($"Слова в словаре '{dictionary.Name}':");

            if (dictionary.Contents.Count > 0)
            {
                foreach (var contain in dictionary.Contents)
                {
                    Console.WriteLine($"{contain.Word} - {contain.Translation}");
                }
            }
            else
            {
                Console.WriteLine("Словарь пуст.");
            }
        }
    }
}
