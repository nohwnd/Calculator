using System.IO;
using Xunit;

namespace Calculator.Core.Tests
{
    public class FileWrapperIntegrationTests
    {
        [Theory]
        [AutoMoqData]
        public void LoadsInputFromAGivenFile(FileWrapper wrapper)
        {
            string inputPath = null;
            try
            {
                // -- Setup
                var expected = new[] {"multiply 9", "apply 5"};

                inputPath = Path.GetTempFileName();
                File.WriteAllLines(inputPath, expected);

                // -- Arrange

                // -- Act
                var actual = wrapper.ReadAllLines(inputPath);

                // -- Assert
                Assert.Equal(expected.Length, actual.Length);
                Assert.Equal(expected[0], actual[0]);
                Assert.Equal(expected[1], actual[1]);
            }
            finally
            {
                // -- Teardown
                if (File.Exists(inputPath))
                    File.Delete(inputPath);
            }
        }
    }
}