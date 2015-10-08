namespace Calculator.Core
{
    public interface IFile
    {
        string[] ReadAllLines(string path);
    }
}