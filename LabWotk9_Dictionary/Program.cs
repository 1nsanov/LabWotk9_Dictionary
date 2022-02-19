using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWotk9_Dictionary
{
    class Program
    {
        private static Random rnd = new Random();
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            var listProducts = new List<Product>();
            for (int i = 1; i <= 7; i++)
            {
                var name = "Product" + i;
                var dateProduction = new DateTime(2022, 1, 25).AddDays(rnd.Next(-5, 5));
                var dateExpiration = rnd.Next(3, 10);
                var price = rnd.Next(10, 50);
                listProducts.Add(new Product(name, dateProduction, dateExpiration, price));
            }

            Console.WriteLine("All info");
            OutputList(listProducts);

            var dictionatyProduct = new Dictionary<string, Product>();
            foreach (var item in listProducts)
            {
                dictionatyProduct.Add(item.Name, item);
            }


            Console.WriteLine("Output Task");
            var tempHashSet = new HashSet<int>();
            foreach (var item in dictionatyProduct)
            {
                tempHashSet.Add(item.Value.DaysExpiration);
            }
            foreach (var value in tempHashSet)
            {
                var count = 0;
                foreach (var item in dictionatyProduct)
                {
                    if (value == item.Value.DaysExpiration)
                    {
                        count++;
                    }
                }
                Console.WriteLine($"Товаров с ср. годн. {value} - {count}");
            }

            Console.WriteLine("Введите желаемый срок годности.");
            var days = int.Parse(Console.ReadLine());
            Console.WriteLine($"Товары со сроком годности = {days}");
            OutputList(dictionatyProduct.Values.Where(p => p.DaysExpiration == days));


            Console.ReadLine();
        }

        private static void OutputList(IEnumerable<Product> list)
        {
            Console.WriteLine();
            if (list.Count() > 0)
            {
                Console.WriteLine("__________________________________________________________________");
                foreach (var item in list)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("__________________________________________________________________");
            }
            else
            {
                Console.WriteLine("Список пуст.");
            }
            Console.WriteLine();
        }
    }
}
