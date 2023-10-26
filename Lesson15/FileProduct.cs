using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lesson15
{
    public class FileProduct : FileDataStorage<Product>
    {
        public FileProduct(string fileName) : base(fileName) { }

        public override bool SaveToFile(string fileName)
        {
            try
            {
                string[] lines = new string[_data.Length];
                for (int i = 0; i < lines.Length; i++)
                {
                    lines[i] = $"{_data[i].Id},{_data[i].Name},{_data[i].Price}";
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
