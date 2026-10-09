using System;
using System.Collections.Generic;
using System.Globalization;
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

            books.Add(new Books(nextID++, "Худеющий", "Стивен Кинг", Genre.Thriller, 1984, 800));
            books.Add(new Books(nextID++, "Алиса в старне чудес", "Льюис Кэрролл", Genre.Fantasy, 1865, 500));
            books.Add(new Books(nextID++, "Оно", "Стивен Кинг", Genre.Horror, 1986, 750));
            books.Add(new Books(nextID++, "Дракула", "Брэм Стокер", Genre.Horror, 1897, 650));
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
                    case "2":
                        RemoveBook();
                        break;
                    case "3":
                        FindBook();
                        break;
                    case "4":
                        SortBooks();
                        break;
                    //case "5":
                    //    ShowMinMax();
                    //    break;
                    //case "6":
                    //    GroupByAuthor();
                    //    break;
                    case "7":
                        ShowAll();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Неверный ввод. Нажмите Enter.");
                        Console.ReadLine();
                        break;
                }
                void AddBook()
                {
                    Console.WriteLine("Введите данные о книге по шаблону:");
                    Console.WriteLine("Название; Автор; Жанр, Год выпуска; Цена");
                    Console.WriteLine("Категории: 1 - Фэнтэзи, 2 - Детектив, 3 - Хоррор, 4 - Слэшер, 5 - Историческая, 6 - Триллер.");
                    string book = Console.ReadLine();
                    string[] parts = book.Split(';');
                    if (parts.Length != 5)
                    {
                        Console.WriteLine("Неправильный формат ввода! Напишите информацию по шаблону!");
                        Console.ReadLine();
                        return;
                    }
                    else
                    {
                        string name = parts[0].Trim();
                        if (name.Length == 0)
                        {
                            Console.WriteLine("Строка не может быть пустой!");
                            return;
                        }

                        string author = parts[1].Trim();
                        if (author.Length == 0)
                        {
                            Console.WriteLine("Автор не может быть пустым!");
                            return;
                        }

                        int genrenum = Convert.ToInt32(parts[2].Trim());
                        if (genrenum < 1 || genrenum > 6)
                        {
                            Console.WriteLine("Категория должна быть в диапазоне от 1 до 6!");
                            return;
                        }
                        Genre genre = (Genre)genrenum;

                        uint year = Convert.ToUInt32(parts[3].Trim());
                        if (year <= 0 || year > 2026)
                        {
                            Console.WriteLine("Год должен быть в диапазоне от 1 до 2026.");
                            Console.ReadLine();
                            return;
                        }

                        uint cost = Convert.ToUInt32(parts[4].Trim());
                        if (cost <= 0)
                        {
                            Console.WriteLine("Цена не может быть отрицательной и не может равняться нулю!");
                            return;
                        }
                        Books newBook = new Books(nextID, name, author, genre, year, cost);
                        books.Add(newBook);
                        nextID++;
                    }
                }
                void RemoveBook()
                {
                    Console.WriteLine("Введите ID кинги, которую хотите удалить:");
                    string input = Console.ReadLine();

                    if (!int.TryParse(input, out int IDToRemove))
                    {
                        Console.WriteLine("Ошибка: ID должен быть числом!");
                        Console.WriteLine("Нажмите Enter");
                        return;
                    }

                    bool isFound = false;

                    for (int i = 0;  i < books.Count; i++)
                    {
                        if (books[i].ID == IDToRemove)
                        {
                            Console.WriteLine($"Книга '{books[i].name}', ID - {IDToRemove} успешно удалена!");
                            books.RemoveAt(i);

                            isFound = true;
                            break;
                        }
                    }
                    if (!isFound)
                    {
                        Console.WriteLine($"Книга с ID {IDToRemove} не найдена.");
                    }
                    Console.WriteLine("Нажмите Enter, чтобы вернуться в меню.");
                    Console.ReadLine();
                }
                void FindBook()
                {
                    Console.Clear();
                    Console.WriteLine("Поиск книги:");
                    Console.WriteLine("1. Поиск по названию");
                    Console.WriteLine("2. Поиск по автору");
                    Console.WriteLine("3. Поиск по жанру");
                    Console.WriteLine("0. Назад в меню");
                    string choice1 = Console.ReadLine();

                    int foundCount = 0;

                    switch (choice1)
                    {
                        case "1":
                            Console.Write("Введите часть или полное название книги:");
                            string searchName = Console.ReadLine().Trim().ToLower();

                            Console.WriteLine("Результаты поиска:");
                            for (int i = 0; i < books.Count; i++)
                            {
                                if (books[i].name.ToLower().Contains(searchName))
                                {
                                    books[i].ShowInfo();
                                    foundCount++;
                                }
                            }
                            break;
                        case "2":
                            Console.Write("Введите часть или полное имя автора:");
                            string searchAuthor = Console.ReadLine().Trim().ToLower();

                            Console.WriteLine("Результаты поиска:");
                            for (int i = 0; i < books.Count; i++)
                            {
                                if (books[i].author.ToLower().Contains(searchAuthor))
                                {
                                    books[i].ShowInfo();
                                    foundCount++;
                                }
                            }
                            break;
                        case "3":
                            Console.WriteLine("Категории: 1 - Fantasy, 2 - Detective, 3 - Horror, 4 - Slasher, 5 - Historic, 6 - Thriller.");
                            Console.Write("Введите номер категории:");
                            string genreInput = Console.ReadLine();

                            if (!int.TryParse(genreInput, out int genreNum) || genreNum < 1 || genreNum > 6)
                            {
                                Console.WriteLine("Ошибка: нужно ввести число от 1 до 6!");
                                Console.WriteLine("Нажмите Enter");
                                Console.ReadLine();
                                return;
                            }

                            Genre searchGenre = (Genre)genreNum;

                            Console.WriteLine("Резульатаы поиска:");
                            for (int i = 0; i < books.Count; i++)
                            {
                                if (books[i].Genre == searchGenre)
                                {
                                    books[i].ShowInfo();
                                    foundCount++;
                                }
                            }
                            break;

                        case "0":
                            return;

                        default:
                            Console.WriteLine("Неверный ввод!");
                            Console.WriteLine("Нажмите Enter");
                            Console.ReadLine();
                            return;
                    }

                    if (foundCount == 0)
                    {
                        Console.WriteLine("Книги по вашему запросу не найдены.");
                    }
                    else
                    {
                        Console.WriteLine($"Найдено книг: {foundCount}");
                    }

                    Console.WriteLine("Нажмите Enter, чтобы вернуться в меню");
                    Console.ReadLine();
                }
                void SortBooks()
                {
                    Console.Clear();
                    Console.WriteLine("Сортировка книг:");
                    Console.WriteLine("1. Сортировать по названию");
                    Console.WriteLine("2. Сортировать по году");
                    Console.WriteLine("0. Назад в меню");
                    string choice2 = Console.ReadLine();

                    switch (choice2)
                    {
                        case "1":
                            Console.Write("Выберите направление:");
                            Console.WriteLine("1. По возрастанию (А -> Я)");
                            Console.WriteLine("2. По убыванию (Я -> А)");
                            string dir1 = Console.ReadLine();

                            if (dir1 == "1")
                            {
                                books = books.OrderBy(b => b.name).ToList();
                                Console.WriteLine("Книги отсортированы по названию (А -> Я).");
                            }
                            else if (dir1 == "2")
                            {
                                books = books.OrderByDescending(b => b.name).ToList();
                                Console.WriteLine("Книги отсортированы по названию (Я -> А).");
                            }
                            else
                            {
                                Console.WriteLine("Неверный ввод!");
                                Console.ReadLine();
                                return;
                            }
                            break;
                        case "2":
                            Console.Write("Выберите направление:");
                            Console.WriteLine("1. По возрастанию (сначала старые)");
                            Console.WriteLine("2. По убыванию (сначала новые)");
                            string dir2 = Console.ReadLine();

                            if (dir2 == "1")
                            {
                                books = books.OrderBy(b => b.year).ToList();
                                Console.WriteLine("Книги отсортированы по году (сначала старые).");
                            }
                            else if (dir2 == "2")
                            {
                                books = books.OrderByDescending(b => b.year).ToList();
                                Console.WriteLine("Книги отсортированы по году (сначала новые).");
                            }
                            else
                            {
                                Console.WriteLine("Неверный ввод!");
                                Console.ReadLine();
                                return;
                            }
                            break;
                        case "0":
                            return;

                        default:
                            Console.WriteLine("Неверный ввод!");
                            Console.WriteLine("Нажмите Enter");
                            Console.ReadLine();
                            return;
                    }
                    Console.WriteLine("Результат:");
                    foreach (Books book in books)
                    {
                        book.ShowInfo();
                    }

                    Console.WriteLine("Нажмите Enter, чтобы вернуться в меню");
                    Console.ReadLine();
                }
                void ShowAll()
                {
                    if (books.Count == 0 )
                    {
                        Console.WriteLine("Список книг пуст.");
                    }
                    else
                    {
                        Console.WriteLine("Список всех книг:");
                        foreach (Books book in books)
                        {
                            book.ShowInfo();
                        }
                    }
                    Console.WriteLine("Нажмите Enter, чтобы вернуться в меню.");
                    Console.ReadLine();
                }
            }
        }
    }
}