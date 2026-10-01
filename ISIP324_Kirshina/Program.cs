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
        static void Main(string[] args)
        {
            List<string> text = new List<string>();
            Console.WriteLine("Введите текст. Минимум 100 символов.");
            string input = Console.ReadLine();
            if (input.Length >= 100)
            {
                Console.WriteLine("Условие ввода выполнено");
            }else
            {
                Console.WriteLine("Условие ввода выполнено неверно!");
                return;
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
            
            for (int i = 0; i< input.Length; i++)
            {
                if (vowels.Contains(input[i]))
                {
                    countVowels++;
                } else if (consonants.Contains(input[i]))
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
        }
    }
}
