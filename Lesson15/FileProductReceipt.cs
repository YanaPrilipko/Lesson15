using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson15
{
    class FileProductReceipt
    {
       // private string _productReceiptFile;
        private ProductReceipt[] _productReceipt;

        public FileProductReceipt(string file)
        {
          //  _productReceiptFile = file;
            _productReceipt = new ProductReceipt[0];
        }

        public void AddProductReceipt(ProductReceipt newProductReceipt)
        {
            Array.Resize(ref _productReceipt, _productReceipt.Length + 1);
            _productReceipt[^1] = newProductReceipt;
        }


        public bool SaveToFile()
        {
            try
            {
                string[] lines = new string[_productReceipt.Length];
                for (int i = 0; i < lines.Length; i++)
                {
                    if (_productReceipt[i] != null)
                    {
                        lines[i] = $"{_productReceipt[i].ReceiptId},{_productReceipt[i].ProductId}";
                    }
                }
                File.WriteAllLines(@"D:\Рoзробка С#\Lesson15\Lesson15\Lesson15\bin\Debug\net6.0\product_receipt.txt", lines);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static FileProductReceipt ReadProductReceiptFile(string fileName)
        {
            string[] lines = ReadDatabaseAllTextReceipt(fileName);

            return new FileProductReceipt(fileName)
            {
                _productReceipt = ConvertStringsToReceipt(lines),
            };
        }
        public ProductReceipt[] GetAllProductReceipt() => _productReceipt;
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

        private static ProductReceipt[] ConvertStringsToReceipt(string[] records)
        {
            var receipt = new ProductReceipt[records.Length];
            for (int i = 0; i < records.Length; ++i)
            {
                string[] array = records[i].Split(',');
                if (array.Length != 1)
                {
                    receipt[i] = new ProductReceipt(Guid.Parse(array[0]), Guid.Parse(array[1]));
                }
            }
            return receipt;
        }

    }
}
