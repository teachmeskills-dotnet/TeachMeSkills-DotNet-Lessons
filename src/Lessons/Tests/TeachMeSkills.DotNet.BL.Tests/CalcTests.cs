using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TeachMeSkills.DotNet.BL.Tests
{
    public class CalcTests
    {
        private readonly Calc _calc;
        private readonly Mock<Helper> _mockHelper;

        public CalcTests()
        {
            _mockHelper = new Mock<Helper>();
            _calc = new Calc(_mockHelper.Object);
        }

        [Fact]
        public void Sum_TakePositiveNumbers_ReturnSum()
        {
            // Arrange
            var expected = 3;
            _mockHelper.Setup(mock => mock.GetRandomNumbers())
                .Returns((1, 2));

            // Act
            var actual = _calc.Sum();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Divide_TakePositiveNumbers_ReturnResult()
        {
            // Arrange
            var expected = 0.5;
            _mockHelper.Setup(mock => mock.GetRandomNumbers())
                .Returns((1, 2));

            // Act
            var actual = _calc.Divide();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Divide_TakeNumbers_ThrowException()
        {
            // Arrange
            _mockHelper.Setup(mock => mock.GetRandomNumbers())
                .Returns((1, 0));

            // Act

            // Assert
            Assert.Throws<DivideByZeroException>(() => _calc.Divide());
        }
    }
}
