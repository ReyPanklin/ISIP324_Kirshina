using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ISIP324_Kirshina
{
    internal class Program
    {
        public enum Genre
        {
            Fantasy = 1,
            Detective = 2,
            Horror = 3,
            Slasher = 4,
            Historic = 5,
            Thriller = 6
        }
        class Books
        {
            public int ID;
            public string name;
            public string author;
            public Genre Genre;
            public uint year;
            public uint price;

            public Books(int ID, string name, string author, Genre Genre, uint year, uint price)
            {
                this.ID = ID;
                this.name = name;
                this.author = author;
                this.Genre = Genre;
                this.year = year;
                this.price = price;
            }

            public void ShowInfo()
            {
                Console.WriteLine($"ID: {ID}");
                Console.WriteLine($"Название: {name}");
                Console.WriteLine($"Автор: {author}");
                Console.WriteLine($"Жанр: {Genre}");
                Console.WriteLine($"Год: {year}");
                Console.WriteLine($"Цена: {price}");
                Console.WriteLine("------------------");
            }
        }
        static void Main(string[] args)

        {
            int nextID = 1;
            List<Books> books = new List<Books>();

            books.Add(new Books(nextID++, "Гарри Поттер", "Дж. Роулинг", Genre.Fantasy, 1997, 800));
            books.Add(new Books(nextID++, "Убийство в Восточном экспрессе", "Агата Кристи", Genre.Detective, 1934, 500));
            books.Add(new Books(nextID++, "Оно", "Стивен Кинг", Genre.Horror, 1986, 750));
            books.Add(new Books(nextID++, "Девушка с татуировкой дракона", "С. Ларссон", Genre.Thriller, 2005, 650));
            books.Add(new Books(nextID++, "Война и мир", "Л. Толстой", Genre.Historic, 1869, 1200));

            while (true)
            {
                Console.Clear();
                Console.WriteLine("МЕНЮ");
                Console.WriteLine("1. Добавить книгу");
                Console.WriteLine("2. Удалить книгу по ID");
                Console.WriteLine("3. Найти книгу");
                Console.WriteLine("4. Отсортировать книги");
                Console.WriteLine("5. Самая дорогая и дешевая книга");
                Console.WriteLine("6. Количество книг по авторам");
                Console.WriteLine("7. Показать все книги");
                Console.WriteLine("0. Выход");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddBook();
                        break;
                    //case "2":
                    //    RemoveBook();
                    //    break;
                    //case "3":
                    //    FindBook();
                    //    break;
                    //case "4":
                    //    SortBooks();
                    //    break;
                    //case "5":
                    //    ShowMinMax();
                    //    break;
                    //case "6":
                    //    GroupByAuthor();
                    //    break;
                    //case "7":
                    //    ShowAll();
                    //    break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Неверный ввод. Нажмите Enter.");
                        Console.ReadLine();
                        break;
                }
                //void AddBook()
                //{
                //    Console.WriteLine("Введите двнные о книге по шаблону:");
                //    Console.WriteLine("Название; Автор; Жанр, Год выпуска; Цена");
                //    string book = Console.ReadLine();
                //    string[] parts = book.Split(';');
                //    if (parts.Length != 5)
                //    {
                //        Console.WriteLine("Неправильный формат ввода! Напишите информацию по шаблону!");
                //        Console.ReadLine();
                //        return;
                //    }
                    
                //}
                //void RemoveBook()
                //{

                //}
            }
        }
    }
}