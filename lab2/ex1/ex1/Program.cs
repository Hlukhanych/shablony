using System;

namespace TaxiIntegrator
{
    // Target interface
    interface ITaxiService
    {
        void OrderTaxi(string startAddress, string endAddress, string? orderTime = null);
    }

    // Adaptee classes
    class UklonService
    {
        public void Order(string endAddress, string startAddress)
        {
            Console.WriteLine($"Uklon taxi ordered from \"{startAddress}\" to \"{endAddress}\"");
        }
    }

    class BoltService
    {
        public void SetStartPoint(string address)
        {
            Console.WriteLine($"Bolt taxi start point set: \"{address}\"");
        }

        public void SetEndPoint(string address)
        {
            Console.WriteLine($"Bolt taxi end point set: \"{address}\"");
        }
    }

    class UberService
    {
        public void Order(string startAddress, string endAddress, string orderTime)
        {
            Console.WriteLine($"Uber taxi ordered from \"{startAddress}\" to \"{endAddress}\" at {orderTime}");
        }
    }

    // Adapters
    class UklonAdapter : ITaxiService
    {
        private readonly UklonService _uklon = new UklonService();

        public void OrderTaxi(string startAddress, string endAddress, string? orderTime = null)
        {
            _uklon.Order(endAddress, startAddress);
        }
    }

    class BoltAdapter : ITaxiService
    {
        private readonly BoltService _bolt = new BoltService();

        public void OrderTaxi(string startAddress, string endAddress, string? orderTime = null)
        {
            _bolt.SetStartPoint(startAddress);
            _bolt.SetEndPoint(endAddress);
        }
    }

    class UberAdapter : ITaxiService
    {
        private readonly UberService _uber = new UberService();

        public void OrderTaxi(string startAddress, string endAddress, string? orderTime = null)
        {
            _uber.Order(startAddress, endAddress, orderTime);
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
                ITaxiService uklon = new UklonAdapter();

                Console.Write("start address: ");
                string startAddress = Console.ReadLine();
                Console.Write("end address: ");
                string endAddress = Console.ReadLine();

                uklon.OrderTaxi(startAddress, endAddress);
            }

            else if(taxi == "bolt")
            {
                ITaxiService bolt = new BoltAdapter();

                Console.Write("start address: ");
                string startAddress = Console.ReadLine();
                Console.Write("end address: ");
                string endAddress = Console.ReadLine();

                bolt.OrderTaxi(startAddress, endAddress);
            }

            else
            {
                ITaxiService uber = new UberAdapter();

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