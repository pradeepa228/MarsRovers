using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace MRover.Tests
{
    public class ValidateRoverTests
    {
        private Plateau plateau1;
        private Rover rover1;

        public void Setup()
        {

        }

        [Test]
        public void Throws_Exception_If_Rover_Is_Placed_In_A_InValid_Position_On_The_Plateau()
        {
            plateau1 = new Plateau(5, 5);
            var ex = Assert.Throws<ArgumentException>(() => new Rover(new Position(-1, 1, 'E', 1)));
            Assert.That(ex.Message, Is.EqualTo("Position can not have negative values."));
        }

        [Test]
        public void Throws_Exception_When_Rover_Has_Invalid_Direction()
        {
            plateau1 = new Plateau(5, 5);
            var ex = Assert.Throws<ArgumentException>(() => new Rover(new Position(1, 1, 'P', 1)));
            Assert.That(ex.Message, Is.EqualTo("Position can not have an invalid direction."));
        }
        [Test]
        public void Throws_Exception_When_Rover_Is_Placed_Outside_The_Plateau()
        {
            plateau1 = new Plateau(5, 5);
            rover1 = new Rover(new Position(1, 6, 'E', 1));
            var ex = Assert.Throws<ArgumentException>(() => rover1.ValidateRoverPosition(new Plateau(5, 5), new Position(1, 6, 'E', 1)));
            Assert.That(ex.Message, Is.EqualTo("Rover can not be placed outside the Plateau dimension."));
        }
        [Test]
        public void Check_Rover_Is_Placed_In_Right_Direction_And_Right_Position()
        {
            rover1 = new Rover(new Position(1, 1, 'S', 1));
            rover1.ValidateRoverPosition(new Plateau(5, 5), new Position(1, 1, 'S', 1));
            rover1.CurrentPosition.X.Should().Be(1);
            rover1.CurrentPosition.Y.Should().Be(1);
            rover1.CurrentPosition.Direction.Should().Be('S');
        }
    }
}
