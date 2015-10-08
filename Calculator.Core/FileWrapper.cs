using System;
using System.IO;

namespace Calculator.Core
{
    public class FileWrapper : IFile
    {
        public string[] ReadAllLines(string path)
        {
            if (path == null)
                throw new ArgumentNullException(nameof(path));

            return File.ReadAllLines(path);
        }
    }
}