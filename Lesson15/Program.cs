
using Lesson15;
using System;
using System.Diagnostics;
using System.Xml.Linq;

namespace Lesson15
{
    internal class Program
    {
        static FileProduct _product;
        static FileBuyer _buyer;
        static FileReceipt _receipt;
        static FileProductReceipt _productReceipt;


        static void Main(string[] args)
        {
            _buyer = new FileBuyer(args.Length == 0 ? "buyer.txt" : args[0]);
            _product = new FileProduct(args.Length == 0 ? "products.txt" : args[0]);
            _receipt = new FileReceipt(args.Length == 0 ? "receipts.txt" : args[0]);
            _productReceipt = new FileProductReceipt(args.Length == 0 ? "product_receipt.txt" : args[0]);

            while (true)
            {
                UserInteraction();
            }
        }

        static Buyer ReadBuyerConsole()
        {
            Guid id = Guid.NewGuid();
            Console.WriteLine("Enter the buyer's name:");
            string buyerName = Console.ReadLine();
            Console.WriteLine("Enter your phone number:");
            string buyerPhone = Console.ReadLine();
            return new Buyer (id, buyerName, buyerPhone);
        }

        static Product ReadProductConsole()
        {
            Guid id = Guid.NewGuid();
            Console.WriteLine("Enter the product name:");
            string productName = Console.ReadLine();
            Console.WriteLine("Enter the price of the product:");
            decimal productPrice = decimal.Parse(Console.ReadLine());
            return new Product(id, productName, productPrice);
        }


        static Receipt ReadReceiptConsole()
        {
            Guid id = Guid.NewGuid();
            DateTime date = DateTime.Now;
            Console.WriteLine("Select a buyer:");

            var all = _buyer.GetAllData();
            for (int i = 0; i < all.Length; ++i)
            {
                Console.WriteLine($"{i + 1}: {all[i]}");
            }
            int buyerIndex = int.Parse(Console.ReadLine());
            var buyerId = all[buyerIndex - 1].Id;

            return new Receipt(id, date, buyerId, 1, 4);
        }

        static ProductReceipt ReadFileProductReceiptConsole(Receipt receipt)
        {
            Guid receiptId = receipt.Id;

            Console.WriteLine("Select a product:");
            var products = _product.GetAllData();
            for (int i = 0; i < products.Length; ++i)
            {
                Console.WriteLine($"{i + 1}: {products[i]}");
            }

            int productIndex = int.Parse(Console.ReadLine());
            var productId = products[productIndex - 1].Id;

            return new ProductReceipt(receiptId, productId);
        }


        static void ReceiptsPrint()
        {
            var receiptData = _receipt.GetAllData();
            var buyerData = _buyer.GetAllData();
            var productData = _product.GetAllData();
            var productReceiptData = _productReceipt.GetAllData();

            foreach (var receipt in receiptData)
            {
                var buyer = buyerData.FirstOrDefault(b => b.Id == receipt.BuyerId);
                Console.WriteLine("Receipt = " + receipt.Id + " Date = " + receipt.Date + " Buyer = " + buyer.Name);

                var productReceipts = productReceiptData.Where(pr => pr.ReceiptId == receipt.Id);

                foreach (var productReceipt in productReceipts)
                {
                    var product = productData.FirstOrDefault(p => p.Id == productReceipt.ProductId);
                    Console.WriteLine('\n' + "Product name = " + product.Name);
                }
            }
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
                    _product.AddData(ReadProductConsole());
                    _product.SaveToFile(_product._fileName);
                    break;
                case 2:
                    _buyer.AddData(ReadBuyerConsole());
                    _buyer.SaveToFile(_buyer._fileName);
                    break;
                case 3:
                    var receipt = ReadReceiptConsole();
                    _receipt.AddData(receipt);
                    _receipt.SaveToFile(_receipt._fileName);

                    string continueAdding = "";
                    do
                    {
                        var productReceipt = ReadFileProductReceiptConsole(receipt);
                        _productReceipt.AddData(productReceipt);
                        _productReceipt.SaveToFile(_productReceipt._fileName);

                        Console.WriteLine("Would you like to add more items to the console? (yes/no)");
                        continueAdding = Console.ReadLine();

                    } while (continueAdding.ToLower() == "yes");

                    break;
                case 4:
                    ReceiptsPrint();

                    break;
                default:
                    Console.WriteLine("No such operation.");
                    break;
            }

        }
    }
}

