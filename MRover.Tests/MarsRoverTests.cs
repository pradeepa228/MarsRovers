using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FluentAssertions;

namespace MRover.Tests
{
    public class MarsRoverTests
    {
        private Plateau plateau1;
        private Rover rover1;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Check_Rover_Is_Placed_In_A_Valid_Position_On_The_Plateau()
        {
            plateau1 = new Plateau(5, 5);
            rover1 = new Rover(plateau1);
            rover1.checkRoverPosition(new Position(1, 1, 'N'));
            rover1.CurrentPosition.X.Should().Be(1);
            rover1.CurrentPosition.Y.Should().Be(1);
            rover1.CurrentPosition.Direction.Should().Be('N');
        }
        
    }
}
