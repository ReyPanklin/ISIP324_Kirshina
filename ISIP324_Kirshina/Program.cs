using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ISIP324_Kirshina
{
    internal class Program
    {
        class TextStatistics
        {
            public int WordCount;
            public string MinWord;
            public int SentenceCount;
            public int VowelCount;
            public int ConsonantCount;
            public string MaxWord;
            public Dictionary<char, int> LetterFrequency;
        }
        static void Main(string[] args)
        {
            List<string> text = new List<string>();
            List<TextStatistics> allStatistics = new List<TextStatistics>();
            while (true)
            {
                Console.WriteLine("1. Ввести текст.");
                Console.WriteLine("2. Вывести статистику о текстах.");
                Console.WriteLine("0. Выход.");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Введите текст. Минимум 100 символов");
                        string input = Console.ReadLine();
                        if (input.Length >= 100)
                        {
                            Console.WriteLine("Условие ввода выполнено");
                        }
                        else
                        {
                            Console.WriteLine("Условие ввода выполнено неверно!");
                            break;
                        }
                        string[] words = input.Split(' ');
                        int count = 0;
                        for (int i = 0; i < words.Length; i++)
                        {
                            count++;
                        }
                        Console.WriteLine($"Слов в тексте: {count}");

                        string minword = words[0];
                        int minlength = words[0].Length;
                        for (int i = 1; i < words.Length; i++)
                        {
                            if (words[i].Length < minlength)
                            {
                                minlength = words[i].Length;
                                minword = words[i];
                            }
                        }
                        Console.WriteLine($"Самое короткое слово: {minword}");

                        int counts = input.Split(new char[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
                        Console.WriteLine($"Предложений в тексте: {counts}");

                        string vowels = "аеёиоуыэюяАЕЁИОУЫЭЮЯ";
                        string consonants = "бвгджзклмнпрстфхцчшщйБВГДЖЗКЛМНПРСТФХЦЧШЩЙ";
                        int countVowels = 0;
                        int countConsonants = 0;

                        for (int i = 0; i < input.Length; i++)
                        {
                            if (vowels.Contains(input[i]))
                            {
                                countVowels++;
                            }
                            else if (consonants.Contains(input[i]))
                            {
                                countConsonants++;
                            }
                        }
                        Console.WriteLine($"Гласных букв: {countVowels}");
                        Console.WriteLine($"Согласных букв: {countConsonants}");

                        string maxword = words[0];
                        int maxlength = words[0].Length;
                        for (int i = 1; i < words.Length; i++)
                        {
                            string cleanWord = words[i].Trim('.', ',', '!', '?', ':', ';', '-', '(', ')');
                            if (cleanWord.Length > maxlength)
                            {
                                maxlength = cleanWord.Length;
                                maxword = cleanWord;
                            }
                        }
                        Console.WriteLine($"Самое длинное слово: {maxword}");

                        Dictionary<char, int> letterFrequency = new Dictionary<char, int>();
                        for (int i = 0; i < input.Length; i++)
                        {
                            char c = input[i];
                            if (char.IsLetter(c))
                            {
                                c = char.ToLower(c);
                                if (letterFrequency.ContainsKey(c))
                                {
                                    letterFrequency[c]++;
                                }
                                else
                                {
                                    letterFrequency[c] = 1;
                                }
                            }
                        }
                        Console.WriteLine("Частота встречаемости букв:");
                        foreach (KeyValuePair<char, int> pair in letterFrequency)
                        {
                            Console.WriteLine($"{pair.Key} - {pair.Value} раз");
                        }
                        TextStatistics currentStats = new TextStatistics
                        {
                            WordCount = count,
                            MinWord = minword,
                            SentenceCount = counts,
                            VowelCount = countVowels,
                            ConsonantCount = countConsonants,
                            MaxWord = maxword,
                            LetterFrequency = letterFrequency
                        };
                        allStatistics.Add(currentStats);
                        Console.WriteLine("Статистика сохранена");
                        break;
                    case "2":

                }
            }
        }
    }
}
