using System;
using Xunit;

namespace Calculator.Core.Tests
{
    public class FileWrapperTests
    {
        [Theory]
        [AutoMoqData]
        public void ImplementsIFile(FileWrapper wrapper)
        {
            // -- Arrange

            // -- Act

            // -- Assert
            Assert.IsAssignableFrom<IFile>(wrapper);
        }

        [Theory]
        [AutoMoqData]
        public void FailsFastOnNullInput(FileWrapper wrapper)
        {
            // -- Arrange

            // -- Act

            // -- Assert
            Assert.ThrowsAny<ArgumentNullException>(() => wrapper.ReadAllLines(null));
        }
    }
}