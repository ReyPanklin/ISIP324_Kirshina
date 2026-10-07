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
        }
    }
}
