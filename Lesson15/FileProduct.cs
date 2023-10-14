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
        private string _productsFile; 
        private Product[] _product;

        public FileProduct(string file)
        {
            _productsFile = file;
            _product = new Product[0];
        }

        public void AddProduct(Product newProduct)
        {
            Array.Resize(ref _product, _product.Length + 1); 
            _product[^1] = newProduct;
        }

        public bool SaveToFileProduct()
        {
            try
            {
                string[] lines = new string[_product.Length];

                for (int i = 0; i < lines.Length; i++)
                {
                    lines[i] = $"{_product[i].Id},{_product[i].Name},{_product[i].Price}";
                }
                File.WriteAllLines(@"D:\Рoзробка С#\Lesson15\Lesson15\Lesson15\bin\Debug\net6.0\products.txt", lines);

                return true;
            }
            catch
            {
                return false;
            }
        }


        public Product[] GetAllProduct() => _product;

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
                    product[i] = new Product(Guid.Parse(array[0]), array[1], decimal.Parse(array[2]));
                }
            }
            return product;
        }

    }

}
