using System;
using System.Collections.Generic;
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
                    //case "2":
                    // DeleteProduct();
                    // break;
                    //case "3":
                    // OrderDelivery();
                    // break;
                    //case "4":
                    // SellProdcut();
                    // break;
                    //case "5":
                    // SearchProduct();
                    // break;
                    //case "0":
                    // return;
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
            }
        }
    }
}
