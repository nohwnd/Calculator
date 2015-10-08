using System;

namespace Calculator.Core
{
    public class ParserResult
    {
        public ParserResult(string command, decimal value)
        {
            if (string.IsNullOrWhiteSpace(command))
                throw new ArgumentException("The command cannot be empty.", nameof(command));

            Command = command;
            Value = value;
        }

        public string Command { get; }
        public decimal Value { get; }
    }
}