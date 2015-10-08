using Xunit;

namespace Calculator.Core.Tests
{
    public class BootstrapTests
    {
        [Theory]
        [AutoMoqData]
        public void BuildsTheAppCorrectly(Bootstrap bootstrapper)
        {
            // -- Arrange

            // -- Act
            var actual = bootstrapper.ResolveCalculatorService();

            // -- Assert
            Assert.IsAssignableFrom<ICalculatorService>(actual);
        }
    }
}