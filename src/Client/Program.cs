using System;
using BullsAndCows;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game(Console.Out, Console.In);
            game.StartGuessNumber();
        }
    }
}