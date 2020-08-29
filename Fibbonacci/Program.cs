using System;
using System.Collections.Generic;

namespace Fibbonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            var fibonacciCalculate = new List<int> { 1, 1 };

            Console.WriteLine("Entre com a posição do número de fibonacci desejado: ");
            int fibonacciPosition = int.Parse(Console.ReadLine());

            while (fibonacciCalculate.Count < fibonacciPosition)
            {
                var fstPrevNumber = fibonacciCalculate[fibonacciCalculate.Count - 1];
                var sndPrevNumber = fibonacciCalculate[fibonacciCalculate.Count - 2];

                fibonacciCalculate.Add(fstPrevNumber + sndPrevNumber);
            }

            foreach(var item in fibonacciCalculate)
            {
                Console.WriteLine(item);
            }
        }
    }
}
