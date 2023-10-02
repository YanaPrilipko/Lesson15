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
        private string _receiptFile; //приватні поля прийнятописати через _
        private Receipt[] _receipt;
        private Buyer [] _buyer;

        public FileReceipt(string file)
        {
            _receiptFile = file;
            _receipt = new Receipt[0];
        }

        public void AddReceipt(Receipt newReceipt)
        {
            int contactIndex = GetBuyerIndexByName(name);

            Array.Resize(ref _receipt, _receipt.Length + 1); //ref аргумент передається по ссилці
            _receipt[^1] = newReceipt;

        }

        private int GetBuyerIndexByName(string searchQuery)
        {
            for (int i = 0; i < _buyer.Length; ++i)
            {
                if (_buyer[i].Name.Contains(searchQuery, StringComparison.OrdinalIgnoreCase) ||
                    _buyer[i].Phone.Contains(searchQuery, StringComparison.OrdinalIgnoreCase))
                {
                    return i;
                }
            }
            return -1;
        }

        public bool SaveToFile()
        {
            try
            {
                string[] lines = new string[_receipt.Length];
                for (int i = 0; i < lines.Length; i++)
                {
                    lines[i] = $"{_receipt[i].Date},{_receipt[i].Buyer},{_receipt[i].Product},{_receipt[i].TotalAmount}";
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
                    receipt[i] = new Receipt(int.Parse(array[0]), DateTime.Parse(array[0]), array[1], array[2], array[3], array[4], decimal.Parse(array[5]));
                }
            }
            return receipt;
        }
    }
}
