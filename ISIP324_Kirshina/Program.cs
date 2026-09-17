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
            Drinks,
            Bakery,
            FastFood,
            HomeSupplies,
            Food
        }
        public class Product
        {
            public int code;
            public string name;
            public double cost;
            public int quantity;
            public bool isThere;
            public Category category;

            public Products(string name, double cost, int quantity, Category category)
            {
                this.name = name;
                this.cost = cost;
                this.quantity = quantity;
                this.category = category;
                this.isThere = isThere;
            }
            static void Main(string[] args)
            {
                List <Product> products = new List<Product>();
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
                        string input = Console.ReadLine();
                        string[] parts = input.Split(';');
                        if (parts.Length == 3)
                        {
                            products = parts[0].Trim();

                        }
                        else
                        {

                        }
                    }
                }
            }
        }
    }
}
