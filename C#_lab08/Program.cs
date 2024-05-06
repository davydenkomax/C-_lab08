using System;

namespace project
{
    enum Genre
    {
        adventure,
        detective,
        drama,
        fantasy,
        history,
        legent,
        novel
    }
    class Book
    {
        
        private string name;
        private string author;
        private int yearOfPublishing;
        private Genre genre;
        public DateTime date;

        public Book(string name, string author, int yearOfPublishing, Genre genre, DateTime date)
        {
            this.name = name;
            this.author = author;
            this.yearOfPublishing = yearOfPublishing;
            this.genre = genre;
            this.date = date;
        }

        public Book()
        {
            this.name = "Колобок";
            this.author = "Толстой A.Н";
            this.yearOfPublishing = 1873;
            this.genre = Genre.adventure;
            this.date = new DateTime(1873, 1, 1);
        }

        public void inputData()
        {
            Console.Write("Введите название книги: ");

            string name = Console.ReadLine();
            if (name == "") Console.WriteLine($"Присвоено значение по умолчанию: {this.name}");
            else this.name = name;

            Console.Write("Введите имя автора: ");

            string author = Console.ReadLine();
            if (author == "") Console.WriteLine($"Присвоено значение по умолчанию: {this.author}");
            else this.author = author;

            Genre[] genres = (Genre[])Enum.GetValues(typeof(Genre));
            int i = 1, menu;

            Console.WriteLine("Выберите жанр из списка: ");
            foreach (Genre genre in genres)
            {
                Console.WriteLine($"{i} - {genre}");
                i++;
            }

            Console.Write("Ввод: ");
            if (!int.TryParse(Console.ReadLine(), out menu) || menu > 7 || menu < 1)
            {
                Console.WriteLine("Неправильный ввод данных");
                Console.WriteLine($"Присвоено значение по умолчанию: {this.genre}");
            }

            switch (menu)
            {
                case 1: this.genre = Genre.adventure; break;
                case 2: this.genre = Genre.detective; break;
                case 3: this.genre = Genre.drama; break;
                case 4: this.genre = Genre.fantasy; break;
                case 5: this.genre = Genre.history; break;
                case 6: this.genre = Genre.legent; break;
                case 7: this.genre = Genre.novel; break;
            }

            Console.Write("Введите год издания книги: ");

            int year;
            if (!int.TryParse(Console.ReadLine(), out year) || year > 2024 || year <= 0)
            {
                Console.WriteLine("Неправильный ввод данных");
                year = 1873;   
                Console.WriteLine($"Присвоено значение по умолчанию: {this.yearOfPublishing}");
            }
            else this.yearOfPublishing = year;

            Console.Write("Введите месяц издания книги: ");

            int month;
            if (!int.TryParse(Console.ReadLine(), out month) || month > 12 || month <= 0)
            {
                Console.WriteLine("Неправильный ввод данных");
                month = 1;
                Console.WriteLine($"Присвоено значение по умолчанию: {month}");
            }

            Console.Write("Введите день издания книги: ");

            int day;
            if (!int.TryParse(Console.ReadLine(), out day) || day > 31 || day <= 0)
            {
                Console.WriteLine("Неправильный ввод данных");
                day = 1;
                Console.WriteLine($"Присвоено значение по умолчанию: {day}");
            }

            this.date = new DateTime(year, month, day);

            Console.WriteLine();
        }

        public void outputData()
        {
            Console.WriteLine($"Книга {this.name}\nавтор {this.author}\nдата издания: {this.date.ToLongDateString()}\nЖанр {this.genre}");
        }

        public int getAgeOfBook()
        {
            return 2024 - this.yearOfPublishing;
        }

        public int getCountOfDays()
        {
            DateTime now = DateTime.Now;
            DateTime dateOfPublishing = new DateTime(this.yearOfPublishing, 1, 1);

            TimeSpan pastTime = now - dateOfPublishing;

            return pastTime.Days;
        }

        public bool findBooks(int keyGenre)
        {
            Genre[] genres = (Genre[])Enum.GetValues(typeof(Genre));
            return this.genre == genres[keyGenre];
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {

            Console.Write("Введите количество книг: ");
            int count;
            if (!int.TryParse(Console.ReadLine(), out count))
            {
                Console.WriteLine("Неправильный ввод данных");
                return;
            }

            Book[] books = new Book[count];

            for (int i = 0; i < count; i++) books[i] = new Book();

            for (int i = 0; i < count; i++)
            {
                books[i].inputData();
            }

            Console.WriteLine("Введите жанр для посика объектов: ");

            Genre[] genres = (Genre[])Enum.GetValues(typeof(Genre));
            int j = 1, keyGenre;

            foreach (Genre genre in genres)
            {
                Console.WriteLine($"{j} - {genre}");
                j++;
            }

            Console.Write("Ввод: ");
            if (!int.TryParse(Console.ReadLine(), out keyGenre) || keyGenre > 7 || keyGenre < 1)
            {
                Console.WriteLine("Неправильный ввод данных");
                return;
            }
            Console.WriteLine();

            bool flag = false;
            keyGenre--;
            for (int i = 0; i < count; i++)
            {
                if (books[i].findBooks(keyGenre)) {
                    books[i].outputData();
                    Console.WriteLine();
                    flag = true;
                }
            }
            if (!flag)
            {
                Console.WriteLine("Ничего не нашли(");
            }
            Console.WriteLine();

            Array.Sort(books, (x, y) => x.date.CompareTo(y.date));
            
            Console.WriteLine("Сортировка объектов по дате: ");
            for (int i = 0; i < count; i++) 
            {
                books[i].outputData();
                Console.WriteLine();
            }

        }
    }
}