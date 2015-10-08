using System;
using System.Globalization;

namespace Calculator.Core
{
    public class CruncherAutomator : ICruncherAutomator
    {
        private readonly NumberCruncher _cruncher;
        private object _result;

        public CruncherAutomator(NumberCruncher cruncher)
        {
            if (cruncher == null)
                throw new ArgumentNullException(nameof(cruncher));

            _cruncher = cruncher;
        }

        public ICruncherAutomator Process(ParserResult result)
        {
            _result = typeof (NumberCruncher)
                .GetMethod(ToTitleCase(result.Command))
                .Invoke(_cruncher, new object[] {result.Value});

            return this;
        }

        private static string ToTitleCase(string commandName)
        {
            return CultureInfo.InvariantCulture.TextInfo.ToTitleCase(commandName.ToLowerInvariant());
        }

        public decimal GetResult()
        {
            try
            {
                return (decimal) _result;
            }
            catch (InvalidCastException exception)
            {
                throw new InvalidCastException(
                    "The resulting value cannot be cast to decimal, did you forget to call APPLY on the end of the input?",
                    exception);
            }
        }
    }
}