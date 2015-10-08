namespace Calculator.Core
{
    public class Bootstrap
    {
        public ICalculatorService ResolveCalculatorService()
        {
            return new CalculatorService(new FileWrapper(), new FileParser(),
                new CruncherAutomator(new NumberCruncher()));
        }
    }
}