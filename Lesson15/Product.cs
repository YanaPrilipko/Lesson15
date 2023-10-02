using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson15
{
    public record Product(int Id,string Name, int Quantity, decimal Price)
    {
        public override string ToString() => $"{Id}, {Name}, {Quantity}, {Price}";
    }
}
