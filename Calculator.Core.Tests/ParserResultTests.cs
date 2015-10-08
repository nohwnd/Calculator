using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Idioms;
using Xunit;

namespace Calculator.Core.Tests
{
    public class ParserResultTests
    {
        [Theory]
        [AutoMoqData]
        public void HasGuardedConstructor(Fixture fixture)
        {
            // -- Arrange

            // -- Act

            // -- Assert
            var assertion = new GuardClauseAssertion(fixture);
            assertion.Verify(typeof (CalculatorService).GetConstructors());
        }
    }
}