using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ISIP324_Kirshina
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> products = new List<string>();
            List <double> costs = new List<double>();
            int numberofoper = 0;
            while (true)
            {
                Console.WriteLine("Введите количество операций (от 2 до 40)");
                numberofoper = Convert.ToInt32(Console.ReadLine());
                if (numberofoper >=2 && numberofoper <= 40)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Ошибка. Операций должно быть от 2 до 40.");
                }
            }
            for (int i = 0; i < numberofoper; i++)
            {
                Console.WriteLine("Введите трату в формате: Название услуги или товара; Кол-во денег");
                string input = Console.ReadLine();
                string[] parts = input.Split(';');
                if (parts.Length == 2)
                {
                    string product = parts[0].Trim();
                    int cost = Convert.ToInt32(parts[1].Trim());
                    products.Add(product);
                    costs.Add(cost);
                    Console.WriteLine($"Записано: {product} - {cost} рублей");
                }
                else
                {
                    Console.WriteLine("Вы используете неправильный форат ввода.");
                    i--;
                }
            }
            ShowMenu();
            void ShowMenu()
            {
                while (true)
                {
                    Console.WriteLine("Выберите пункт:");
                    Console.WriteLine("1. Вывод данных");
                    Console.WriteLine("2. Статистика (среднее, максимальное, минимальное, сумма)");
                    Console.WriteLine("3. Сортировка по цене");
                    Console.WriteLine("4. Конвертация валюты");
                    Console.WriteLine("5. Поиск по названию");
                    Console.WriteLine("0. Выход");
                    string choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            DisplayData();
                            break;
                        case "2":
                            Statistics();
                            break;
                        case "3":
                            BubbleSort();
                            break;
                        case "4":
                            ConvertMoney();
                            break;
                        case "5":
                            NameSearch();
                            break;
                        case "0":
                            return;
                        default:
                            Console.WriteLine("Неверный выбор");
                            break;
                    }
                }
            }
            void DisplayData()
            {
                Console.WriteLine("Все траты:");
                for (int i = 0; i < numberofoper; i++)
                {
                    Console.WriteLine($"{i + 1}. {products[i]} - {costs[i]} рублей.");
                }
            }
            void Statistics()
            {
                double sum = costs.Sum();
                double avg = costs.Average();
                double max = costs.Max();
                double min = costs.Min();

                Console.WriteLine("Статистика:");
                Console.WriteLine($"Сумма: {sum} рублей");
                Console.WriteLine($"Среднее: {avg} рублей");
                Console.WriteLine($"Максимальное: {max} рублей");
                Console.WriteLine($"Минимальное: {min} рублей");
            }
            void BubbleSort()
            {
                List<string> sortedProducts = new List<string>(products);
                List<double> sortedCosts = new List<double>(costs);

                for(int i = 0; i < numberofoper - 1; i++)
                {
                    for (int j = 0; j < numberofoper - 1 - i; j++)
                    {
                        if (sortedCosts[j] > sortedCosts[j + 1])
                        {
                            double tempCost = sortedCosts[j];
                            sortedCosts[j] = sortedCosts[j + 1];
                            sortedCosts[j + 1] = tempCost;

                            string tempProduct = sortedProducts[j];
                            sortedProducts[j] = sortedProducts[j + 1];
                            sortedProducts[j + 1] = tempProduct;
                        }
                    }
                }
                Console.WriteLine("Отсортировано по возрастанию цены:");
                for (int i = 0; i < numberofoper; i++)
                {
                    Console.WriteLine($"{i + 1}. {sortedProducts[i]} - {sortedCosts[i]} рублей");
                }
            }
            void ConvertMoney()
            {
                Console.WriteLine("Выберите валюту:");
                Console.WriteLine("1. USD - 84,26 рублей");
                Console.WriteLine("2. EUR - 97,87 рублей");
                Console.WriteLine("3. KZT - 522,98 рублей");

                double rate = 1;
                string chosenValue = Console.ReadLine();
                switch(chosenValue)
                {
                    case "1":
                        rate = 84.26;
                        break;
                    case "2":
                        rate = 97.87;
                        break;
                    case "3":
                        rate = 0.1869;
                        break;
                    default:
                        Console.WriteLine("Введён неправильный выбор");
                        break;
                }
                Console.WriteLine("Конвертированная валюта:");
                for (int i = 0; i < numberofoper; i++)
                {
                    Console.WriteLine($"{products[i]} - {costs[i]/rate}");
                } 
            }
            void NameSearch()
            {
                Console.WriteLine("Введите слово для поиска:");
                string forSearch = Console.ReadLine();
                for (int i = 0; i < numberofoper; i++)
                {
                    if (forSearch == products[i])
                    {
                        Console.WriteLine($"Найдено совпадение: {products[i]} - {costs[i]} рублей");
                    }
                }
            }
        }
    }
}
