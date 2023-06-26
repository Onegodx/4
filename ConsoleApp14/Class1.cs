using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
     class zodiak
    {
        public class zodiak_1 : ICloneable, IComparable<zodiak_1>
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Zodiac { get; set; }
            public int ID { get; set; }
            public int[] BirthDate { get; set; }

            // Конструктор класса
            public zodiak_1(string firstName, string lastName, string zodiac, int id, int[] birthDate)
            {
                FirstName = firstName;
                LastName = lastName;
                Zodiac = zodiac;
                ID = id;
                BirthDate = birthDate;
            }

            // Реализация интерфейса ICloneable
            public object Clone()
            {
                return new zodiak_1(FirstName, LastName, Zodiac, ID, BirthDate);
            }

            // Реализация интерфейса IComparable
            public int CompareTo(zodiak_1 other)
            {
                DateTime thisBirthDate = new DateTime(BirthDate[2], BirthDate[1], BirthDate[0]);
                DateTime otherBirthDate = new DateTime(other.BirthDate[2], other.BirthDate[1], other.BirthDate[0]);
                return thisBirthDate.CompareTo(otherBirthDate);
            }

            // Класс для сортировки по Фамилии, Имени
            public class NameComparer : IComparer<zodiak_1>
            {
                public int Compare(zodiak_1 x, zodiak_1 y)
                {
                    int comp = x.LastName.CompareTo(y.LastName);
                    if (comp == 0)
                    {
                        return x.FirstName.CompareTo(y.FirstName);
                    }
                    return comp;
                }
            }
        }
    }
}
