using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Миньков Владимир вариант 15 

public static class NoteHelper
{
    public static NOTE[] InputNotes(int count)
    {
        NOTE[] notes = new NOTE[count];
        for (int i = 0; i < count; i++)
        {
            notes[i] = new NOTE();
            Console.WriteLine($"Введите данные записи {i + 1}:");
            Console.Write("Введите фамилию: ");
            notes[i].LastName = Console.ReadLine();
            Console.Write("Введите имя: ");
            notes[i].FirstName = Console.ReadLine();
            Console.Write("Введите номер телефона: ");
            notes[i].PhoneNumber = Console.ReadLine();
        }
        Array.Sort(notes);
        return notes;
    }

    public static void OutputNotes(NOTE[] notes)
    {
        Console.WriteLine("Список записей:");
        foreach (var note in notes)
        {
            Console.WriteLine(note);
        }
    }

    public static NOTE FindNoteByLastName(NOTE[] notes, string lastName)
    {
        foreach (var note in notes)
        {
            if (note.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase))
            {
                return (NOTE)note.Clone();
            }
        }
        return null;
    }

    public static void SearchNoteByLastName(NOTE[] notes)
    {
        Console.Write("Введите фамилию для поиска: ");
        string lastName = Console.ReadLine();
        NOTE note = FindNoteByLastName(notes, lastName);
        if (note != null)
        {
            Console.WriteLine($"Найдена запись: {note}");
        }
        else
        {
            Console.WriteLine($"Запись с фамилией {lastName} не найдена.");
        }
    }
}
public class ZNAK<T> : ICloneable, IComparable<ZNAK<T>>
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string Zodiac { get; set; }
    public T IdentificationNumber { get; set; }
    public int[] Birthday { get; set; }

    public object Clone()
    {
        return new ZNAK<T>
        {
            LastName = this.LastName,
            FirstName = this.FirstName,
            Zodiac = this.Zodiac,
            IdentificationNumber = this.IdentificationNumber,
            Birthday = (int[])this.Birthday.Clone()
        };
    }

    public int CompareTo(ZNAK<T> other)
    {
        int result = 0;
        for (int i = 0; i < Birthday.Length; i++)
        {
            result = Birthday[i].CompareTo(other.Birthday[i]);
            if (result != 0) break;
        }
        return result;
    }

    public override string ToString()
    {
        return $"{LastName} {FirstName} - {string.Join(".", Birthday)} ({Zodiac})";
    }
}

public static class ZnakHelper
{
    public static ZNAK<T>[] InputZnaks<T>(int count)
    {
        ZNAK<T>[] znaks = new ZNAK<T>[count];
        for (int i = 0; i < count; i++)
        {
            znaks[i] = new ZNAK<T>();
            Console.WriteLine($"Введите данные записи {i + 1}:");
            Console.Write("Введите фамилию: ");
            znaks[i].LastName = Console.ReadLine();
            Console.Write("Введите имя: ");
            znaks[i].FirstName = Console.ReadLine();
            Console.Write("Введите знак зодиака: ");
            znaks[i].Zodiac = Console.ReadLine();
            Console.Write("Введите идентификационный номер: ");
            znaks[i].IdentificationNumber = (T)(object)Console.ReadLine();
            znaks[i].Birthday = new int[3];
            Console.WriteLine("Введите дату рождения:");
            Console.Write("День: ");
            znaks[i].Birthday[0] = int.Parse(Console.ReadLine());
            Console.Write("Месяц: ");
            znaks[i].Birthday[1] = int.Parse(Console.ReadLine());
            Console.Write("Год: ");
            znaks[i].Birthday[2] = int.Parse(Console.ReadLine());
        }
        Array.Sort(znaks);
        return znaks;
    }

    public static void OutputZnaks<T>(ZNAK<T>[] znaks)
    {
        Console.WriteLine("Список записей:");
        foreach (var znak in znaks)
        {
            Console.WriteLine(znak);
        }
    }

    public static ZNAK<T> FindZnakByLastName<T>(ZNAK<T>[] znaks, string lastName)
    {
        foreach (var znak in znaks)
        {
            if (znak.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase))
            {
                return (ZNAK<T>)znak.Clone();
            }
        }
        return null;
    }

    public static void SearchZnakByLastName<T>(ZNAK<T>[] znaks)
    {
        Console.Write("Введите фамилию для поиска: ");
        string lastName = Console.ReadLine();
        ZNAK<T> znak = FindZnakByLastName(znaks, lastName);
        if (znak != null)
        {
            Console.WriteLine($"Найдена запись: {znak}");
        }
        else
        {
            Console.WriteLine($"Запись с фамилией {lastName} не найдена.");
        }
    }
}
