using System;
using System.Collections.Generic;
using System.Linq;
using Ploeh.AutoFixture.Xunit2;
using Xunit;

namespace Calculator.Core.Tests
{
    public class FileParserTests
    {
        [Theory]
        //simple
        [InlineAutoData("ADD 1", "ADD", 1)]
        [InlineAutoData("SUBTRACT 2", "SUBTRACT", 2)]
        [InlineAutoData("MULTIPLY 3", "MULTIPLY", 3)]
        [InlineAutoData("DIVIDE 4", "DIVIDE", 4)]
        [InlineAutoData("APPLY 5", "APPLY", 5)]

        //case sensitivity
        [InlineAutoData("AdD 1", "ADD", 1)]
        [InlineAutoData("SubTract 2", "SUBTRACT", 2)]
        [InlineAutoData("MultiPLY 3", "MULTIPLY", 3)]
        [InlineAutoData("DIvidE 4", "DIVIDE", 4)]
        [InlineAutoData("APPLy 5", "APPLY", 5)]

        //number formats
        [InlineAutoData("ADD -1", "ADD", -1)]
        [InlineAutoData("SUBTRACT -2", "SUBTRACT", -2)]
        [InlineAutoData("MULTIPLY 0.3", "MULTIPLY", 0.3)]
        [InlineAutoData("DIVIDE 0", "DIVIDE", 0)]
        [InlineAutoData("APPLY -5", "APPLY", -5)]

        //spacing
        [InlineAutoData("   ADD 1", "ADD", 1)]
        [InlineAutoData("SUBTRACT 2   ", "SUBTRACT", 2)]
        [InlineAutoData("   MULTIPLY 3   ", "MULTIPLY", 3)]
        [InlineAutoData("DIVIDE     4", "DIVIDE", 4)]
        [InlineAutoData("  APPLY    5   ", "APPLY", 5)]
        public void ParsesInputCorrectly(
            string line,
            string command,
            decimal value,
            FileParser parser)
        {
            // -- Arrange

            // -- Act
            var actual = parser.ParseLine(line);

            // -- Assert
            Assert.Equal(command, actual.Command);
            Assert.Equal(value, actual.Value);
        }

        [Theory]
        [AutoMoqData]
        public void ParsesInputAllLinesCorrectly(FileParser parser)
        {
            // -- Arrange
            var expected = new List<ParserResult>
            {
                new ParserResult("DIVIDE", 4),
                new ParserResult("APPLY", 5)
            };

            // -- Act
            var actual = parser.ParseAllLines(new[] {"DIVIDE 4", "APPLY 5"});

            // -- Assert
            Assert.Equal(expected.Count, actual.Count());
        }

        [Theory]
        [AutoMoqData]
        public void ImplementsIFileParser(FileParser parser)
        {
            // -- Arrange

            // -- Act

            // -- Assert
            Assert.IsAssignableFrom<IFileParser>(parser);
        }


        [Theory]
        [AutoMoqData]
        public void FailsFastOnNullInput(FileParser parser)
        {
            // -- Arrange

            // -- Act

            // -- Assert
            Assert.ThrowsAny<ArgumentException>(() => parser.ParseLine(null));
        }
    }
}