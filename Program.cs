using System;
using Lab11_Serialization;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Lab13_Serialization_Binary
{
    class Program
    {
        static void Main(string[] args)
        {
            var customer = new Customer(1, "Billy", "NR362345");
            var customer2 = new Customer(2, "Mary", "BA662345");
            var customers = new List<Customer> { customer, customer2 };

            //formatter: allow us to serialize to Binary
            var formatter = new BinaryFormatter();
            //stream to file
            using (var stream = new FileStream("data.bin", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(stream, customers);
            }

            //deserialize
            var customersFromJSONBinary = new List<Customer>();
            using (var reader = File.OpenRead("data.bin"))
            {
                // Deserialize Customer and print
                customersFromJSONBinary = formatter.Deserialize(reader) as List<Customer>;
            }
            customersFromJSONBinary.ForEach(c => Console.WriteLine($"{c.CustomerID,-10}{c.CustomerName}"));
        }
    }
}
