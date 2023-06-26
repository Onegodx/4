using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using ConsoleApp14;

class zodiak
{
    public zodiak(string? firstName, string? lastName, string? zodiac, int id, int[] birthDate)
    {
        FirstName = firstName;
        LastName = lastName;
        Zodiac = zodiac;
        Id = id;
        BirthDate = birthDate;
    }

    public string? FirstName { get; }
    public string? LastName { get; }
    public string? Zodiac { get; }
    public int Id { get; }
    public int ID { get; private set; }
    public int[] BirthDate { get; }

    static void Main(string[] args)
    {
        zodiak[] znaks = new zodiak[8];

        // Ввод данных с клавиатуры
        for (int i = 0; i < 8; i++)
        {
            Console.WriteLine("Введите информацию о человеке номер {0}", i + 1);
            Console.Write("Фамилия: ");
            string lastName = Console.ReadLine();
            Console.Write("Имя: ");
            string firstName = Console.ReadLine();
            Console.Write("Знак Зодиака: ");
            string zodiac = Console.ReadLine();
            Console.Write("Идентификационный номер: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Дата рождения (дд.мм.гггг): ");
            string[] birthDateStr = Console.ReadLine().Split('.');
            int[] birthDate = new int[3];
            for (int j = 0; j < 3; j++)
            {
                birthDate[j] = int.Parse(birthDateStr[j]);
            }
            znaks[i] = new zodiak(firstName, lastName, zodiac, id, birthDate);
        }

        // Сортировка по дате рождения
        Array.Sort(znaks);

        // Вывод информации о человеке по фамилии
        Console.Write("Введите фамилию для поиска: ");
        string searchLastName = Console.ReadLine();
        bool found = false;
        foreach (zodiak z in znaks)
        {
            if (z.LastName == searchLastName)
            {
                Console.WriteLine("Информация о человеке:");
                Console.WriteLine("Фамилия: {0}", z.LastName);
                Console.WriteLine("Имя: {0}", z.FirstName);
                Console.WriteLine("Знак Зодиака: {0}", z.Zodiac);
                Console.WriteLine("Идентификационный номер: {0}", z.ID);
                Console.WriteLine("Дата рождения: {0:d}", new DateTime(z.BirthDate[2], z.BirthDate[1], z.BirthDate[0]));
                found = true;
                break;
            }
        }
        if (!found)
        {
            Console.WriteLine("Человек с такой фамилией не найден");
        }

        // Сортировка по Фамилии, Имени
        Array.Sort(znaks, new zodiak.NameComparer());

        Console.ReadLine();
    }
}