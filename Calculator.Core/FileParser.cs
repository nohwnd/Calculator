using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Calculator.Core
{
    public class FileParser : IFileParser
    {
        public IEnumerable<ParserResult> ParseAllLines(IEnumerable<string> lines)
        {
            return lines.Select(ParseLine);
        }

        public ParserResult ParseLine(string line)
        {
            if (string.IsNullOrWhiteSpace(line))
                throw new ArgumentException("The line cannot be empty.", nameof(line));

            var group = Regex.Split(line.Trim(), @"\s+");

            return new ParserResult(group[0].ToUpperInvariant(), decimal.Parse(group[1], CultureInfo.CurrentUICulture));
        }
    }
}