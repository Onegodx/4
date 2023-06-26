using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class NOTE : ICloneable, IComparable<NOTE>
//Миньков владимир 22исп21 15 вариант
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string PhoneNumber { get; set; }

    public object Clone()
    {
        return new NOTE
        {
            LastName = this.LastName,
            FirstName = this.FirstName,
            PhoneNumber = this.PhoneNumber
        };
    }

    public int CompareTo(NOTE other)
    {
        return this.PhoneNumber.Substring(0, 3).CompareTo(other.PhoneNumber.Substring(0, 3));
    }

    public override string ToString()
    {
        return $"{LastName} {FirstName} - {PhoneNumber}";
    }
}
