namespace Calculator.Core
{
    public interface ICruncherAutomator
    {
        ICruncherAutomator Process(ParserResult result);
        decimal GetResult();
    }
}