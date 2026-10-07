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
                author = author;
                Genre = Genre;
                year = year;
                price = price;
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
        }
    }
}
