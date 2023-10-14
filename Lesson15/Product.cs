using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson15
{
    public record Product(Guid Id, string Name, decimal Price)
    {
        public override string ToString() => $"{Id}, {Name}, {Price}";
    }
}
