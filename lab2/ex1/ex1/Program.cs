using System;

namespace TaxiIntegrator
{
    interface ITaxiService
    {
        void OrderTaxi(string startAddress, string endAddress, string? orderTime = null);
    }

    class Uklon : ITaxiService
    {
        public void OrderTaxi(string startAddress, string endAddress, string orderTime)
        {
            Console.WriteLine($"Uklon taxi ordered from \"{startAddress}\" to \"{endAddress}\"");
        }
    }

    class Bolt : ITaxiService
    {
        public void OrderTaxi(string startAddress, string endAddress, string orderTime)
        {
            Console.WriteLine($"Bolt taxi start point set: \"{startAddress}\"");
            Console.WriteLine($"Bolt taxi end point set: \"{endAddress}\"");
        }
    }

    class Uber : ITaxiService
    {
        public void OrderTaxi(string startAddress, string endAddress, string orderTime)
        {
            Console.WriteLine($"Uber taxi ordered from \"{startAddress}\" to \"{endAddress}\" at {orderTime}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("taxi(uklon, bolt, uber): ");
            string taxi = Console.ReadLine();

            if (taxi == "uklon")
            {
                ITaxiService uklon = new Uklon();

                Console.Write("start address: ");
                string startAddress = Console.ReadLine();
                Console.Write("end address: ");
                string endAddress = Console.ReadLine();

                uklon.OrderTaxi(startAddress, endAddress);
            }

            else if(taxi == "bolt")
            {
                ITaxiService bolt = new Bolt();

                Console.Write("start address: ");
                string startAddress = Console.ReadLine();
                Console.Write("end address: ");
                string endAddress = Console.ReadLine();

                bolt.OrderTaxi(startAddress, endAddress);
            }

            else
            {
                ITaxiService uber = new Uber();

                Console.Write("start address: ");
                string startAddress = Console.ReadLine();
                Console.Write("end address: ");
                string endAddress = Console.ReadLine();

                Console.Write("orderTime(type: hour:minutes day.month.year): ");
                string orderTime = Console.ReadLine();

                uber.OrderTaxi(startAddress, endAddress, orderTime);
            }
        }
    }
}