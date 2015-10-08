using System;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Idioms;
using Ploeh.AutoFixture.Xunit2;
using Xunit;

namespace Calculator.Core.Tests
{
    public class CruncherAutomatorTests
    {
        [Theory]
        [AutoMoqData]
        public void HasGuardedConstructor(Fixture fixture)
        {
            // -- Arrange

            // -- Act


            // -- Assert
            var assertion = new GuardClauseAssertion(fixture);
            assertion.Verify(typeof (CruncherAutomator).GetConstructors());
        }

        [Theory]
        //do not forget we are running the math sequentially (without precedence) 
        // (((3*4)-5)/2)+8 = 11.5
        [InlineAutoData(3, 4, 5, 2, 8, 11.5)]
        // (((7*(-3))-9)/ 12)+(-1) = -3.5
        [InlineAutoData(7, -3, 9, 12, -1, -3.5)]
        public void CalculatesASimpleEquation(
            int applyValue,
            int multiplyValue,
            int subtractValue,
            int divideValue,
            int addValue,
            decimal expected,
            CruncherAutomator automator)
        {
            // -- Arrange

            // -- Act
            var actual = automator.Process(new ParserResult("MULTIPLY", multiplyValue))
                .Process(new ParserResult("SUBTRACT", subtractValue))
                .Process(new ParserResult("DIVIDE", divideValue))
                .Process(new ParserResult("ADD", addValue))
                .Process(new ParserResult("APPLY", applyValue))
                .GetResult();

            // -- Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [AutoMoqData]
        public void ImplementsICruncherAutomator(CruncherAutomator cruncher)
        {
            // -- Arrange

            // -- Act

            // -- Assert
            Assert.IsAssignableFrom<ICruncherAutomator>(cruncher);
        }

        [Theory]
        [AutoMoqData]
        public void GetResultThrowsInvalidCastExceptionWhenApplyIsNotCalled(CruncherAutomator automator)
        {
            // -- Arrange

            // -- Act
            var automator2 = automator.Process(new ParserResult("MULTIPLY", 4))
                .Process(new ParserResult("SUBTRACT", 5))
                .Process(new ParserResult("DIVIDE", 2))
                .Process(new ParserResult("ADD", 8));


            // -- Assert
            Assert.ThrowsAny<InvalidCastException>(() => automator2.GetResult());
        }
    }
}