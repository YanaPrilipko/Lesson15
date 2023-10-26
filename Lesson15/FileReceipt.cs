using Lesson15;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lesson15
{
    public class FileReceipt : FileDataStorage<Receipt>
    {
        public FileReceipt(string fileName) : base(fileName) { }

        public override bool SaveToFile(string fileName)
        {
            try
            {
                string[] lines = new string[_data.Length];
                for (int i = 0; i < lines.Length; i++)
                {
                    lines[i] = $"{_data[i].Id},{_data[i].Date},{_data[i].BuyerId},{_data[i].Quantity},{_data[i].TotalAmount}";
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


