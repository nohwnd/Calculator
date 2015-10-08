using Ploeh.AutoFixture.Xunit2;
using Xunit;

namespace Calculator.Core.Tests
{
    public class NumberCruncherTests
    {
        [Theory]
        [InlineAutoData(0)]
        [InlineAutoData(1)]
        [InlineAutoData(2)]
        [InlineAutoData(10)]
        [InlineAutoData(-1)]
        public void ApplyOperationReturnsTheSameValue(
            int expected,
            NumberCruncher calculator)
        {
            // -- Arrange

            // -- Act
            var actual = calculator.Apply(expected);

            // -- Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineAutoData(0, 0)]
        [InlineAutoData(1, 1)]
        [InlineAutoData(2, 2)]
        [InlineAutoData(10, 10)]
        [InlineAutoData(-1, -1)]
        public void AddOperationReturnsCorrectResultWhenAppliedToZero(
            int value,
            int expected,
            NumberCruncher calculator)
        {
            // -- Arrange

            // -- Act
            var actual = calculator.Add(value).Apply(0);

            // -- Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineAutoData(0, 0)]
        [InlineAutoData(1, -1)]
        [InlineAutoData(2, -2)]
        [InlineAutoData(10, -10)]
        [InlineAutoData(-1, 1)]
        public void SubtractOperationReturnsCorrectResultWhenAppliedToZero(
            int value,
            int expected,
            NumberCruncher calculator)
        {
            // -- Arrange

            // -- Act
            var actual = calculator.Subtract(value).Apply(0);

            // -- Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineAutoData(0, 0)]
        [InlineAutoData(1, 2)]
        [InlineAutoData(2, 4)]
        [InlineAutoData(10, 20)]
        [InlineAutoData(-1, -2)]
        public void MultiplyOperationReturnsCorrectResultWhenAppliedToTwo(
            int value,
            int expected,
            NumberCruncher calculator)
        {
            // -- Arrange

            // -- Act
            var actual = calculator.Multiply(value).Apply(2);

            // -- Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineAutoData(1, 2)]
        [InlineAutoData(2, 1)]
        [InlineAutoData(10, 0.2)]
        [InlineAutoData(-1, -2)]
        public void DivideOperationReturnsCorrectResultWhenAppliedToTwo(
            int value,
            decimal expected,
            NumberCruncher calculator)
        {
            // -- Arrange

            // -- Act
            var actual = calculator.Divide(value).Apply(2);

            // -- Assert
            Assert.Equal(expected, actual);
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
            NumberCruncher calculator)
        {
            // -- Arrange

            // -- Act
            var actual = calculator
                .Multiply(multiplyValue)
                .Subtract(subtractValue)
                .Divide(divideValue)
                .Add(addValue)
                .Apply(applyValue);

            // -- Assert

            Assert.Equal(expected, actual);
        }

        public void ImplementsINumberCruncher(NumberCruncher cruncher)
        {
            // -- Arrange

            // -- Act
            
        // -- Assert
        Assert.IsAssignableFrom<INumberCruncher>(cruncher);
        }
}
}