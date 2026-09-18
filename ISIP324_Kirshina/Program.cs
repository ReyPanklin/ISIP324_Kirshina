using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP324_Kirshina
{
    internal class Program
    {
        enum Category
        {
            Drinks = 1,
            Bakery = 2,
            FastFood = 3,
            HomeSupplies = 4,
            Food = 5
        }
        public class Product
        {
            public int code;
            public string name;
            public double cost;
            public int quantity;
            public bool isThere;
            public Category category;

            public Product(string name, double cost, int quantity, Category category)
            {
                this.name = name;
                this.cost = cost;
                this.quantity = quantity;
                this.category = category;
                this.isThere = quantity > 0;
            }
        }
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();
            int nextCode = 1;
            ShowMenu();
            void ShowMenu()
            {
                Console.WriteLine("Меню:");
                Console.WriteLine("1.Добвить товар");
                Console.WriteLine("2. Удалить товар");
                Console.WriteLine("3. Заказать поставку товара");
                Console.WriteLine("4. Продать товар");
                Console.WriteLine("5. Найти товар (по коду, названию и категории)");
                Console.WriteLine("0. Выход");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddProduct();
                        break;
                    case "2":
                        DeleteProduct();
                        break;
                    case "3":
                        OrderDelivery();
                        break;
                    case "4":
                        SellProdcut();
                        break;
                    case "5":
                        SearchProduct();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Такого варианта нет");
                        break;
                }
                void AddProduct()
                {
                    Console.WriteLine("Введите товары в следующем виде: Название; цена; кол-во");
                    Console.WriteLine("Категории: 1 - Drinks, 2 - Bakery, 3 - FastFood, 4 - HouseSupplies, 5 - Food");
                    string input = Console.ReadLine();
                    string[] parts = input.Split(';');
                    if (parts.Length != 4)
                    {
                        Console.WriteLine("Неверный формат! Нужно 4 значения через точку с запятой.");
                        return;
                    }
                    string name = parts[0].Trim();
                    if (name.Length == 0)
                    {
                        Console.WriteLine("Строка не может быть пустой!");
                        return;
                    }
                    double cost = Convert.ToDouble(parts[1].Trim());
                    if (cost < 0)
                    {
                        Console.WriteLine("Цена не может быть отрицательной!");
                        return;
                    }
                    int quantity = Convert.ToInt32(parts[2].Trim());
                    if (quantity < 0)
                    {
                        Console.WriteLine("Кол-во не может быть отрицательным");
                        return;
                    }
                    int categoryNum = Convert.ToInt32(parts[3].Trim());

                    if (categoryNum < 1 || categoryNum > 5)
                    {
                        Console.WriteLine("Категория должна быть от 1 до 5!");
                        return;
                    }
                    Category category = (Category)categoryNum;
                    Product newProduct = new Product(name, cost, quantity, category);
                    newProduct.code = nextCode;
                    nextCode++;

                    newProduct.isThere = quantity > 0;

                    products.Add(newProduct);
                    Console.WriteLine($"Товар {name} добвлен с кодом {newProduct.code} в кол-ве {quantity}, категории {newProduct.category}");
                }
                void DeleteProduct()
                {
                    Console.WriteLine("Введите код товара, который хотите удалить:");
                    string input = Console.ReadLine();

                    int codeToDelete;
                    bool isNumber = int.TryParse (input, out codeToDelete);

                    if (isNumber == false)
                    {

                        Console.WriteLine("Код должен быть числом!");
                        return;
                    }
                    bool found = false;

                    for (int i = 0; i < products.Count(); i++)
                    {
                        if (products[i].code == codeToDelete)
                        {
                            string deletedName = products[i].name;
                            products.RemoveAt(i);
                            Console.WriteLine($"Товар {deletedName} с кодом {codeToDelete} успешно удален.");
                            found = true;
                            break;
                        }
                    }
                    if (found == false)
                    {
                        Console.WriteLine("Товар с таким кодом не найден!");
                    }
                }
                void OrderDelivery()
                {
                    Console.WriteLine("Введите код для поставки:");
                    string inputCode = Console.ReadLine();
                    int codeToSupply;
                    bool isCodeValid = int.TryParse(inputCode, out codeToSupply);

                    if (isCodeValid == false)
                    {
                        Console.WriteLine("Код должен быть числом!");
                        return;
                    }
                    Product foundProduct = null;

                    for (int i = 0; i < products.Count(); i++)
                    {
                        if (products[i].code == codeToSupply)
                        {
                            foundProduct = products[i];
                            break;
                        }
                    }

                    if (foundProduct == null)
                    {
                        Console.WriteLine("Товар с таким кодом не найден");
                        return;
                    }
                    Console.WriteLine($"Текущее кол-во - {foundProduct.name}: {foundProduct.quantity}. Сколько добавить?");
                    string inputQuantity = Console.ReadLine();
                    int addQuantity;
                    bool isQuantityValid = int.TryParse(inputQuantity, out addQuantity);
                    if (isQuantityValid == false || addQuantity <= 0)
                    {
                        Console.WriteLine("Кол-во поставки должно быть больше 0!");
                        return;
                    }
                    foundProduct.quantity += addQuantity;
                    foundProduct.isThere = true;
                    Console.WriteLine($"Поставка принята! Теперь на складе {foundProduct.name}: {foundProduct.quantity} шт.");
                }
                void SellProduct()
                {
                    Console.WriteLine("Введите код товара для продажи:");
                    string inputCode = Console.ReadLine();
                    int codeToSell;
                    bool isCodeValid = int.TryParse(inputCode, out codeToSell);

                    if (isCodeValid == false)
                    {
                        Console.WriteLine("Код должен быть числом!");
                        return;
                    }
                    Product foundProduct = null;

                    for (int i = 0; i < products.Count(); i++)
                    {
                        if (products[i].code == codeToSell)
                        {
                            foundProduct = products[i];
                            break;
                        }
                    }

                    if (foundProduct == null)
                    {
                        Console.WriteLine("Товар с таким кодом не найден");
                        return;
                    }
                    Console.WriteLine($"В наличии: {foundProduct.quantity}. Сколько продать?");
                    string inputQuantity = Console.ReadLine();

                    int sellQuantity;
                    bool isQuantityValid = int.TryParse(inputQuantity, out sellQuantity);
                    if (isQuantityValid == false || sellQuantity <= 0)
                    {
                        Console.WriteLine("Кол-во должно быть числом больше нуля");
                        return;
                    }
                    if (sellQuantity > foundProduct.quantity)
                    {
                        Console.WriteLine($"Нельзя продать больше чем есть в наличии (всего {foundProduct.quantity})");
                        return;
                    }
                    foundProduct.quantity -= sellQuantity;
                    foundProduct.isThere = foundProduct.quantity > 0;
                    Console.WriteLine($"Продажа успешна! Осталось на складе '{foundProduct.name}': {foundProduct.quantity} шт.");
                }
                void SearchProduct()
                {
                    Console.WriteLine("Введите код, часть названия или номер категории (1-5) для поиска: ");
                    string input = Console.ReadLine().Trim();

                    bool foundSomething = false;

                    Console.WriteLine("Результаты поиска:");

                    for (int i = 0; i < products.Count; i++)
                    {
                        Product currentProduct = products[i];
                        bool isMatchCode = currentProduct.code.ToString() == input;
                        bool isMatchName = currentProduct.name.Contains(input);
                        bool isMatchCategory = ((int)currentProduct.category).ToString() == input;
                        if (isMatchCode || isMatchName || isMatchCategory)
                        {
                            Console.WriteLine($"Код: {currentProduct.code}, название: {currentProduct.name}, цена: {currentProduct.cost}, кол-во: {currentProduct.quantity}, категория: {currentProduct.category}");
                            foundSomething = true;
                        }
                    }
                    if (foundSomething == false)
                    {
                        Console.WriteLine("Ничего не найдено.");
                    }
                }
            }
        }
    }
}
