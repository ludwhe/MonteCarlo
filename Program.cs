using System;
using System.Linq;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Models;

namespace MonteCarlo
{
    public static class Program
    {
        private const int ROUNDS = 10000;

        public static void Main(string[] args)
        {
            var bag = new ConcurrentBag<bool>();

            Console.WriteLine("Welcome to the Monte-Carlo simulator.");
            Parallel.For(0, ROUNDS, _ => bag.Add(new Game().Round()));

            Console.WriteLine($"House wins: {bag.Sum(r => r ? 1 : 0)} out of {ROUNDS}.");
        }
    }
}
