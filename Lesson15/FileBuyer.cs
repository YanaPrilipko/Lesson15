using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lesson15
{
    public class FileBuyer : FileDataStorage<Buyer>
    {
        public FileBuyer(string fileName) : base(fileName) { }

        public override bool SaveToFile(string fileName)
        {
            try
            {
                string[] lines = new string[_data.Length];
                for (int i = 0; i < lines.Length; i++)
                {
                    lines[i] = $"{_data[i].Id},{_data[i].Name},{_data[i].Phone}";
                }
                File.WriteAllLines(fileName, lines);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}