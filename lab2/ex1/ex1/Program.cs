using System;

namespace TaxiIntegrator
{
    // Target interface
    interface ITaxiService
    {
        void OrderTaxi(string startAddress, string endAddress);
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
        public void Order(string startAddress, string endAddress, DateTime date)
        {
            Console.WriteLine($"Uber taxi ordered from \"{startAddress}\" to \"{endAddress}\" at {date.ToString()}");
        }
    }

    // Adapters
    class UklonAdapter : ITaxiService
    {
        private readonly UklonService _uklon = new UklonService();

        public void OrderTaxi(string startAddress, string endAddress)
        {
            _uklon.Order(endAddress, startAddress);
        }
    }

    class BoltAdapter : ITaxiService
    {
        private readonly BoltService _bolt = new BoltService();

        public void OrderTaxi(string startAddress, string endAddress)
        {
            _bolt.SetStartPoint(startAddress);
            _bolt.SetEndPoint(endAddress);
        }
    }

    class UberAdapter : ITaxiService
    {
        private readonly UberService _uber = new UberService();

        public void OrderTaxi(string startAddress, string endAddress)
        {
            _uber.Order(startAddress, endAddress, DateTime.Now);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("taxi(uklon, bolt, uber): ");
            string taxi = Console.ReadLine();

            Console.Write("start address: ");
            string startAddress = Console.ReadLine();
            Console.Write("end address: ");
            string endAddress = Console.ReadLine();

            ITaxiService taxiService;

            if (taxi == "uklon")
            {
                taxiService = new UklonAdapter();
            }

            else if(taxi == "bolt")
            {
                taxiService = new BoltAdapter();
            }

            else
            {
                taxiService = new UberAdapter();
            }

            taxiService.OrderTaxi(startAddress, endAddress);
        }
    }
}