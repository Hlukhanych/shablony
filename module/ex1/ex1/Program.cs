//  Singletone
// Цей шаблон забезпечує, що клас має тільки один екземпляр, і надає точку доступу до цього екземпляру.

using ex1;
using System;

namespace module
{
    class Program
    {
        static void Main(string[] args)
        {
            var generator = DominoGenerator.Instance;

            var dominos = generator.GenerateUniqueRandomDominos(10);

            foreach (var domino in dominos)
            {
                Console.WriteLine(domino);
            }
        }
    }
}