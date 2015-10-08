using System;

namespace Calculator.Core
{
    public class CalculatorService : ICalculatorService
    {
        private readonly ICruncherAutomator _automator;
        private readonly IFile _file;
        private readonly IFileParser _parser;

        public CalculatorService(IFile file, IFileParser parser, ICruncherAutomator automator)
        {
            if (file == null)
                throw new ArgumentNullException(nameof(file));
            if (parser == null)
                throw new ArgumentNullException(nameof(parser));
            if (automator == null)
                throw new ArgumentNullException(nameof(automator));

            _file = file;
            _parser = parser;
            _automator = automator;
        }

        public decimal Process(string path)
        {
            var lines = _file.ReadAllLines(path);
            var parsedLines = _parser.ParseAllLines(lines);
            foreach (var line in parsedLines)
            {
                _automator.Process(line);
            }
            return _automator.GetResult();
        }
    }
}