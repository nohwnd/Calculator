using System.Collections.Generic;

namespace Calculator.Core
{
    public interface IFileParser
    {
        IEnumerable<ParserResult> ParseAllLines(IEnumerable<string> lines);
    }
}