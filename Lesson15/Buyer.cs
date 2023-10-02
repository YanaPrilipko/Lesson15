using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson15
{
    public record Buyer(int Id,string Name, string Phone)
    {
        public override string ToString() => $"{Id}, {Name}, {Phone}";
    }
}
