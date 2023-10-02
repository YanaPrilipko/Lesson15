
using Lesson15;
using System;
using System.Diagnostics;

namespace Lesson15
{
    internal class Program
    {
        static FileProduct _product;
        static FileBuyer _buyer;
        static FileReceipt _receipt;

        static void Main(string[] args)
        {
            _product = FileProduct.ReadProductFile(args.Length == 0 ? "products.txt" : args[0]);
            _buyer = FileBuyer.ReadBuyerFile(args.Length == 0 ? "buyer.txt" : args[0]);
            _receipt = FileReceipt.ReadReceiptFile(args.Length == 0 ? "receipts.txt" : args[0]);

            while (true)
            {
                UserInteraction();
            }
        }

        static Buyer ReadBuyerConsole()
        {
            Console.WriteLine("Enter the buyer's id:");
            int id  =int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the buyer's name:");
            string buyerName = Console.ReadLine();
            Console.WriteLine("Enter your phone number:");
            string buyerPhone = Console.ReadLine();
            return new Buyer (id, buyerName, buyerPhone);
        }

        static Product ReadProductConsole()
        {
            Console.WriteLine("Enter the buyer's id:");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the product name:");
            string productName = Console.ReadLine();
            Console.WriteLine("Enter the price of the product:");
            decimal productPrice = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter the quantityof the product:");
            int productQuantity = int.Parse(Console.ReadLine());

            return new Product(id,productName, productQuantity, productPrice);
        }

        static Receipt ReadReceiptConsole()
        {
            Console.WriteLine("Enter new Date");
            DateTime date = DateTime.Parse(Console.ReadLine(), System.Globalization.CultureInfo.GetCultureInfo("uk-UA"));

            Console.WriteLine("Select a buyer:");

            var all = _buyer.GetAllBuyers();
            for (int i = 0; i < all.Length; ++i)
            {
                Console.WriteLine($"{i + 1}: {all[i]}");
            }

            string buyer = Console.ReadLine();
            Console.WriteLine("Select a product:");
            string product = Console.ReadLine();
            decimal totalAmount = decimal.Parse(Console.ReadLine());
            return new Receipt( date, buyer, product, totalAmount);
        }

        static void UserInteraction()
        {
            Console.WriteLine("Select an action:");
            Console.WriteLine("1. Add a product");
            Console.WriteLine("2. Register a customer");
            Console.WriteLine("3. Make a sale");
            Console.WriteLine("4. Receipts");
            Console.Write("Enter a choice: ");

            uint input = 0;
            bool tryAgain = true;
            while (tryAgain)
            {
                try
                {
                    input = uint.Parse(Console.ReadLine());
                    tryAgain = false;
                }
                catch (FormatException)
                {
                    Console.Write("You`ve entered a wrong choice,please try again ");
                }
                catch (OverflowException)
                {
                    Console.Write("You suck at math a positive namber ");
                }
                catch (SystemException)
                {
                    Console.Write("Sorry,some sestem happened ");
                }
            }
            switch (input)
            {
                case 1:
                    _product.AddProduct(ReadProductConsole());
                    _product.SaveToFile();
                    break;
                case 2:
                    _buyer.AddBuyer(ReadBuyerConsole());
                    _buyer.SaveToFile();
                    break;
                case 3:
                    _receipt.AddReceipt(ReadReceiptConsole());
                    _receipt.SaveToFile();
                    break;
                case 4:
                    //ReceiptsPrint();
                    return;
                default:
                    Console.WriteLine("No such operation.");
                    break;
            }

        }
    }
}


