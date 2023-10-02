using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson15
{
    class FileBuyer
    {
        private string _buyerFile; //приватні поля прийнятописати через _
        private Buyer[] _buyer;

        public FileBuyer(string file)
        {
            _buyerFile = file;
            _buyer = new Buyer[0];
        }

        public void AddBuyer(Buyer newBuyer)
        {
            Array.Resize(ref _buyer, _buyer.Length + 1); //ref аргумент передається по ссилці
            _buyer[^1] = newBuyer;
           
        }
        public Buyer[] GetAllBuyers() => _buyer;

        public bool SaveToFile()
        {
            try
            {
                string[] lines = new string[_buyer.Length];
                for (int i = 0; i < lines.Length; i++)
                {
                    lines[i] = $"{_buyer[i].Id},{_buyer[i].Name},{_buyer[i].Phone}";
                }
                File.WriteAllLines(_buyerFile, lines);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static FileBuyer ReadBuyerFile(string fileName)
        {
            string[] lines = ReadDatabaseAllTextBuyer(fileName);

            return new FileBuyer(fileName)
            {
                _buyer = ConvertStringsToBuyer(lines),
            };
        }

        private static string[] ReadDatabaseAllTextBuyer(string file)
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

        private static Buyer[] ConvertStringsToBuyer(string[] records)
        {
            var buyer = new Buyer[records.Length];
            for (int i = 0; i < records.Length; ++i)
            {
                string[] array = records[i].Split(',');
                if (array.Length != 1)
                {
                    buyer[i] = new Buyer(int.Parse(array[0]) ,array[1], array[2]);
                }
            }
            return buyer;
        }
    }
}
