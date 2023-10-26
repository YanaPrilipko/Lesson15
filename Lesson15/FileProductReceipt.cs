using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson15
{
    public class FileProductReceipt : FileDataStorage<ProductReceipt>
    {
        public FileProductReceipt(string fileName) : base(fileName) { }

        public override bool SaveToFile(string fileName)
        {
            try
            {
                string[] lines = new string[_data.Length];
                for (int i = 0; i < lines.Length; i++)
                {
                    lines[i] = $"{_data[i].ReceiptId},{_data[i].ProductId}";
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
