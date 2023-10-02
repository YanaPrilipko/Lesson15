using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lesson15
{
    class FileProduct
    {
        private string _productsFile; //приватні поля прийнятописати через _
        private Product[] _product;

        public FileProduct(string file)
        {
            _productsFile = file;
            _product = new Product[0];
        }

        public void AddProduct(Product newProduct)
        {
            Array.Resize(ref _product, _product.Length + 1); //ref аргумент передається по ссилці
            _product[^1] = newProduct;
        }

        public bool SaveToFile()
        {
            try
            {
                string[] lines = new string[_product.Length];
                for (int i = 0; i < lines.Length; i++)
                {
                    lines[i] = $"{_product[i].id},{_product[i].Name},{_product[i].Quantity},{_product[i].Price}";
                }
                File.WriteAllLines(_productsFile, lines);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static FileProduct ReadProductFile(string fileName)
        {
            string[] lines = ReadDatabaseAllTextProduct(fileName);

            return new FileProduct(fileName)
            {
                _product = ConvertStringsToProduct(lines),
            };
        }

        private static string[] ReadDatabaseAllTextProduct(string file)
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

        private static Product[] ConvertStringsToProduct(string[] records)
        {
            var product = new Product[records.Length];
            for (int i = 0; i < records.Length; ++i)
            {
                string[] array = records[i].Split(',');
                if (array.Length != 1)
                {
                    product[i] = new Product(int.Parse(array[0]),array[1], int.Parse(array[2]), decimal.Parse(array[3]));
                }
            }
            return product;
        }

    }

}
