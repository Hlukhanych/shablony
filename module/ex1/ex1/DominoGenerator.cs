using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex1
{
    public class Domino
    {
        public int Value1 { get; }
        public int Value2 { get; }

        public Domino(int value1, int value2)
        {
            Value1 = value1;
            Value2 = value2;
        }

        public override string ToString() => $"[{Value1}|{Value2}]";
    }
    public class DominoGenerator
    {
        private static DominoGenerator _instance;
        private List<Domino> _availableDominos;
        private Random _random = new Random();

        private DominoGenerator()
        {
            ResetAvailableDominos();
        }

        public static DominoGenerator Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DominoGenerator();
                }
                return _instance;
            }
        }

        public List<Domino> GenerateUniqueRandomDominos(int count)
        {
            if (count > _availableDominos.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(count), $"Максимальна кількість доступних доміно - {_availableDominos.Count}.");
            }

            var selectedDominos = _availableDominos.OrderBy(d => _random.Next()).Take(count).ToList();
            _availableDominos = _availableDominos.Except(selectedDominos).ToList();

            return selectedDominos;
        }

        public void ResetAvailableDominos()
        {
            _availableDominos = new List<Domino>();

            for (int i = 0; i <= 6; i++)
            {
                for (int j = i; j <= 6; j++)
                {
                    _availableDominos.Add(new Domino(i, j));
                }
            }
        }
    }
}
