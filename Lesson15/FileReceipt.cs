using Lesson15;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lesson15
{
    class FileReceipt
    {
        private string _receiptFile; 
        private Receipt[] _receipt;

        public FileReceipt(string file)
        {
            _receiptFile = file;
            _receipt = new Receipt[0];
        }

        public void AddReceipt(Receipt newReceipt)
        {
            Array.Resize(ref _receipt, _receipt.Length + 1); 
            _receipt[^1] = newReceipt;
        }
        public Receipt[] GetAllReceipt() => _receipt;

        public bool SaveToFile()
        {
            try
            {
                string[] lines = new string[_receipt.Length];
                for (int i = 0; i < lines.Length; i++)
                {
                    if(_receipt[i] != null)
                    {
                        lines[i] = $"{_receipt[i].Id},{_receipt[i].Date},{_receipt[i].BuyerId},{_receipt[i].Quantity},{_receipt[i].TotalAmount}";
                    }
                    
                }
                File.WriteAllLines(_receiptFile, lines);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static FileReceipt ReadReceiptFile(string fileName)
        {
            string[] lines = ReadDatabaseAllTextReceipt(fileName);

            return new FileReceipt(fileName)
            {
                _receipt = ConvertStringsToReceipt(lines),
            };
        }

        private static string[] ReadDatabaseAllTextReceipt(string file)
        {
            try
            {
                return File.ReadAllLines(file);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new string[0];
            }
        }

        private static Receipt[] ConvertStringsToReceipt(string[] records)
        {
            var receipt = new Receipt[records.Length];

            for (int i = 0; i < records.Length; ++i)
            {
                string[] array = records[i].Split(',');
                if (array.Length != 1)
                {
                    receipt[i] = new Receipt(Guid.Parse(array[0]), DateTime.Parse(array[1]), Guid.Parse(array[2]), int.Parse(array[3]), decimal.Parse(array[4]));
                }
            }
            return receipt;
        }
}
}


