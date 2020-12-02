using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TeachMeSkills.DotNet.BL.Tests
{
    public class HelperTests
    {
        [Fact]
        public void Helper_GetNumbers_ReturnTuple()
        {
            // Arrange
            var helper = new Helper();

            // Act
            var result = helper.GetRandomNumbers();

            // Assert
            Assert.IsType<double>(result.a);
            Assert.IsType<double>(result.b);
        }
    }
}
