using System;
using Calculator.Core;

namespace Calculator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Provide path to input file and press Enter. Press Control + C to exit.");
            while (true)
            {
                try
                {
                    Console.Write("> ");
                    var path = Console.ReadLine();

                    Console.WriteLine(new Bootstrap().ResolveCalculatorService().Process(path));
                }
                catch (Exception exception)
                {
                    WriteError(exception);
                }
            }
        }

        private static void WriteError(Exception exception)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(exception.Message);
            Console.ResetColor();
        }
    }
}