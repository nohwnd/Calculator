using Moq;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Idioms;
using Ploeh.AutoFixture.Xunit2;
using Xunit;

namespace Calculator.Core.Tests
{
    public class CalculatorServiceTests
    {
        [Theory]
        [AutoMoqData]
        public void ImplementsICalculatorService(CalculatorService service)
        {
            // -- Arrange

            // -- Act

            // -- Assert
            Assert.IsAssignableFrom<ICalculatorService>(service);
        }

        [Theory]
        [AutoMoqData]
        public void HasGuardedConstructor(Fixture fixture)
        {
            // -- Arrange

            // -- Act


            // -- Assert
            var assertion = new GuardClauseAssertion(fixture);
            assertion.Verify(typeof(CalculatorService).GetConstructors());
        }

        [Theory]
        //do not forget we are running the math sequentially (without precedence) 
        // (((3*4)-5)/2)+8 = 11.5
        [InlineAutoMoqData(new[] {"MULTIPLY 4", "SUBTRACT 5", "DIVIDE 2", "ADD 8", "APPLY 3"}, 11.5)]
        // (((7*(-3))-9)/ 12)+(-1) = -3.5
        [InlineAutoMoqData(new[] {"MULTIPLY -3", "SUBTRACT 9", "DIVIDE 12", "ADD -1", "APPLY 7"}, -3.5)]
        public void CalculatesASimpleEquation(
            string[] input,
            decimal expected,
            [Frozen] Mock<IFile> fileMock,
            [Frozen(Matching.ImplementedInterfaces)] FileParser parser,
            [Frozen(Matching.ImplementedInterfaces)] CruncherAutomator cruncher,
            CalculatorService calculator)
        {
            // -- Arrange
            fileMock.Setup(m => m.ReadAllLines(It.IsAny<string>())).Returns(input);

            // -- Act
            var actual = calculator.Process(@"C:\fakePath.input");

            // -- Assert
            Assert.Equal(expected, actual);
        }
    }
}