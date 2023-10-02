
/*class Program
{
    static void Main(string[] args)
    {
        Shop shop = new Shop();
        shop.Run();
    }
}

class Shop
{
    private string productsFile = "products.txt";
    private string customersFile = "customers.txt";
    private string receiptsFile = "receipts.txt";

    private Product[] products = new Product[100];
    private int productCount = 0;

    private Customer[] customers = new Customer[100];
    private int customerCount = 0;

    private Receipt[] receipts = new Receipt[100];
    private int receiptCount = 0;

    public void Run()
    {
        LoadData(productsFile, products, ref productCount);
        LoadData(customersFile, customers, ref customerCount);

        while (true)
        {
            Console.WriteLine("Select an action:");
            Console.WriteLine("1. Add a product");
            Console.WriteLine("2. Register a customer");
            Console.WriteLine("3. Make a sale");
            Console.WriteLine("4. Receipts");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddProduct();
                    break;

                case "2":
                    RegisterCustomer();
                    break;

                case "3":
                    MakeSale();
                    break;

                case "4":
                    PrintReceipts();
                    return;

                default:
                    Console.WriteLine("Неправильний вибір. Спробуйте ще раз.");
                    break;
            }
        }
    }

    private void AddProduct()
    {
        Console.WriteLine("Введіть назву продукту:");
        string productName = Console.ReadLine();
        Console.WriteLine("Введіть ціну продукту:");
        decimal productPrice = decimal.Parse(Console.ReadLine());

        products[productCount] = new Product { Name = productName, Price = productPrice, Quantity = 0 };
        productCount++;

        SaveData(productsFile, products, productCount);
    }

    private void RegisterCustomer()
    {
        Console.WriteLine("Введіть ім'я покупця:");
        string customerName = Console.ReadLine();

        customers[customerCount] = new Customer { Name = customerName };
        customerCount++;

        SaveData(customersFile, customers, customerCount);
    }

    private void MakeSale()
    {
        Console.WriteLine("Оберіть покупця за номером:");
        for (int i = 0; i < customerCount; i++)
        {
            Console.WriteLine($"{i + 1}. {customers[i].Name}");
        }
        int customerIndex = int.Parse(Console.ReadLine()) - 1;

        if (customerIndex >= 0 && customerIndex < customerCount)
        {
            Console.WriteLine("Оберіть продукт за номером:");
            for (int i = 0; i < productCount; i++)
            {
                Console.WriteLine($"{i + 1}. {products[i].Name} - {products[i].Price}");
            }
            int productIndex = int.Parse(Console.ReadLine()) - 1;

            if (productIndex >= 0 && productIndex < productCount)
            {
                Console.WriteLine("Введіть кількість:");
                int quantitySold = int.Parse(Console.ReadLine());

                if (products[productIndex].Quantity + quantitySold >= 0)
                {
                    products[productIndex].Quantity += quantitySold;
                    decimal total = products[productIndex].Price * quantitySold;

                    receipts[receiptCount] = new Receipt
                    {
                        CustomerName = customers[customerIndex].Name,
                        ProductName = products[productIndex].Name,
                        Quantity = quantitySold,
                        Total = total
                    };

                    receiptCount++;
                    SaveReceipts();

                }
                else
                {
                    Console.WriteLine("Недостатньо товару на складі.");
                }
            }
            else
            {
                Console.WriteLine("Неправильний номер продукту.");
            }
        }
        else
        {
            Console.WriteLine("Неправильний номер покупця.");
        }
    }

    private void LoadData(string fileName, object[] array, ref int count)
    {
        if (File.Exists(fileName))
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                string line;
                int i = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (array[i] is Product)
                    {
                        Product product = new Product
                        {
                            Name = parts[0],
                            Price = decimal.Parse(parts[1]),
                            Quantity = int.Parse(parts[2])
                        };
                        array[i] = product;
                    }
                    else if (array[i] is Customer)
                    {
                        Customer customer = new Customer
                        {
                            Name = parts[0]
                        };
                        array[i] = customer;
                    }
                    i++;
                }
                count = i;
            }
        }
    }

    private void SaveData(string fileName, object[] array, int count)
    {
        using (StreamWriter sw = new StreamWriter(fileName))
        {
            for (int i = 0; i < count; i++)
            {
                string line = "";
                if (array[i] is Product)
                {
                    Product product = (Product)array[i];
                    line = $"{product.Name},{product.Price},{product.Quantity}";
                }
                else if (array[i] is Customer)
                {
                    Customer customer = (Customer)array[i];
                    line = $"{customer.Name}";
                }
                sw.WriteLine(line);
            }
        }
    }

    private void SaveReceipts()
    {
        using (StreamWriter sw = new StreamWriter(receiptsFile))
        {
            for (int i = 0; i < receiptCount; i++)
            {
                sw.WriteLine($"Покупець: {receipts[i].CustomerName}");
                sw.WriteLine($"Товар: {receipts[i].ProductName}");
                sw.WriteLine($"Кількість: {receipts[i].Quantity}");
                sw.WriteLine($"Загальна сума: {receipts[i].Total}");
                sw.WriteLine();
            }
        }
    }

    private void PrintReceipts()
    {
        using (StreamReader sr = new StreamReader(receiptsFile))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
    }
}*/


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
                    //Receipts();
                    return;
                default:
                    Console.WriteLine("No such operation.");
                    break;
            }

        }
    }
}


