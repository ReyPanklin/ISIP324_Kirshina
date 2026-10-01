using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
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
        }
    }
}
