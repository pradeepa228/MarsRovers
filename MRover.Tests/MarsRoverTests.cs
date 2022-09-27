using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace MRover.Tests
{
    public class MarsRoverTests
    {
        private Plateau plateau1;
        private Rover rover1;
        private Rover rover2;
        private Control control1;

        [SetUp]
        public void Setup()
        {
            control1 = new Control();
        }
        
        
        [Test]
        public void Set_Plateau_For_The_rover_To_Move()
        {
            plateau1 = new Plateau(5, 5);
            plateau1.X.Should().Be(5);
            plateau1.Y.Should().Be(5);
        }
        
        [Test]
        public void Throws_exception_If_Plateau_Has_Negative_value()
        {
            plateau1 = new Plateau(5, 5);
            var ex = Assert.Throws<ArgumentException>(() => new Plateau(-5, 5));
            Assert.That(ex.Message, Is.EqualTo("Plateau can not be created with negative values."));
        }
        
        [Test]
        public void Throws_Exception_If_Rover_Is_Placed_In_A_InValid_Position_On_The_Plateau()
        {
            plateau1 = new Plateau(5, 5);
            var ex = Assert.Throws<ArgumentException>(() => new Rover(new Position(-1, 1, 'E',1)));
            Assert.That(ex.Message, Is.EqualTo("Position can not have negative values."));
        }
        
        [Test]
        public void Throws_Exception_When_Rover_Has_Invalid_Direction()
        {
            plateau1 = new Plateau(5, 5);
            var ex = Assert.Throws<ArgumentException>(() => new Rover(new Position(1, 1, 'P',1)));
            Assert.That(ex.Message, Is.EqualTo("Position can not have an invalid direction."));
        }
        [Test]
        public void Throws_Exception_When_Rover_Is_Placed_Outside_The_Plateau()
        {
            plateau1 = new Plateau(5, 5);
            rover1 = new Rover(new Position(1, 6, 'E',1));
            var ex = Assert.Throws<ArgumentException>(() => rover1.ValidateRoverPosition(new Plateau(5, 5), new Position(1, 6, 'E' ,1)));
            Assert.That(ex.Message, Is.EqualTo("Rover can not be placed outside the Plateau dimension."));
        }
        
        [Test]
        public void Check_Rover_Is_Placed_In_Right_Direction()
        {
            rover1 = new Rover(new Position(1, 1, 'S',1));
            rover1.ValidateRoverPosition(new Plateau(5, 5), new Position(1, 1, 'S',1));
            rover1.CurrentPosition.X.Should().Be(1);
            rover1.CurrentPosition.Y.Should().Be(1);
            rover1.CurrentPosition.Direction.Should().Be('S');
        }
        
        [Test]
        public void Check_Rover_Is_Moved_In_Right_Direction()
        {
            rover1 = new Rover(new Position(1, 1, 'W', 1));
            rover1.ValidateRoverPosition(new Plateau(5, 5), new Position(1, 1, 'W',1));
            rover1.SpinRight();
            rover1.CurrentPosition.X.Should().Be(1);
            rover1.CurrentPosition.Y.Should().Be(1);
            rover1.CurrentPosition.Direction.Should().Be('N');
        }

        
        [Test]
        public void Check_Rover_Is_Moved_In_Left_Direction()
        {
            rover1 = new Rover(new Position(1, 1, 'W', 1));
            rover1.ValidateRoverPosition(new Plateau(5, 5), new Position(1, 1, 'W',1));
            rover1.SpinLeft();
            rover1.CurrentPosition.X.Should().Be(1);
            rover1.CurrentPosition.Y.Should().Be(1);
            rover1.CurrentPosition.Direction.Should().Be('S');
        }

        [Test]
        public void Check_Rover_Is_Moved_In_A_Forward_Direction_Of_North()
        {
            rover1 = new Rover(new Position(1, 1, 'N', 1));
            rover1.ValidateRoverPosition(new Plateau(5, 5), new Position(1, 1, 'N',1));
            rover1.MoveCommand();
            rover1.CurrentPosition.X.Should().Be(1);
            rover1.CurrentPosition.Y.Should().Be(2);
            rover1.CurrentPosition.Direction.Should().Be('N');
        }

        [Test]
        public void Check_Rover_Is_Moved_In_A_Forward_Direction_Of_South()
        {
            plateau1 = new Plateau(5, 5);
            rover1 = new Rover(new Position(1, 1, 'S',1));
            rover1.ValidateRoverPosition(new Plateau(5, 5), new Position(1, 1, 'S',1));
            rover1.MoveCommand();
            rover1.CurrentPosition.X.Should().Be(1);
            rover1.CurrentPosition.Y.Should().Be(0);
            rover1.CurrentPosition.Direction.Should().Be('S');
        }
        
        [Test]
        public void Check_Rover_Is_Moved_In_A_Forward_Direction_Of_East()
        {
            plateau1 = new Plateau(5, 5);
            rover1 = new Rover(new Position(1, 1, 'E',1));
            rover1.ValidateRoverPosition(new Plateau(5, 5), new Position(1, 1, 'E',1));
            rover1.MoveCommand();
            rover1.CurrentPosition.X.Should().Be(2);
            rover1.CurrentPosition.Y.Should().Be(1);
            rover1.CurrentPosition.Direction.Should().Be('E');
        }

        [Test]
        public void Check_Rover_Is_Moved_In_A_Forward_Direction_Of_West()
        {
            plateau1 = new Plateau(5, 5);
            rover1 = new Rover(new Position(1, 1, 'W',1));
            rover1.ValidateRoverPosition(new Plateau(5, 5), new Position(1, 1, 'W',1));
            rover1.MoveCommand();
            rover1.CurrentPosition.X.Should().Be(0);
            rover1.CurrentPosition.Y.Should().Be(1);
            rover1.CurrentPosition.Direction.Should().Be('W');
        }
        
        [Test]
        public void Check_Rover_Is_Spinning_Right_And_Moving_Forward()
        {
            plateau1 = new Plateau(5, 5);
            rover1 = new Rover(new Position(1, 1, 'N',1));
            rover1.ValidateRoverPosition(new Plateau(5, 5), new Position(1, 1, 'N',1));
            rover1.SpinRight();
            rover1.MoveCommand();
            rover1.CurrentPosition.X.Should().Be(2);
            rover1.CurrentPosition.Y.Should().Be(1);
            rover1.CurrentPosition.Direction.Should().Be('E');
        }

        [Test]
        public void Check_Rover_Is_Spinning_Left_And_Moving_Forward()
        {
            plateau1 = new Plateau(5, 5);
            rover1 = new Rover(new Position(2, 2, 'N',1));
            rover1.ValidateRoverPosition(new Plateau(5, 5), new Position(2, 2, 'N',1));
            rover1.SpinLeft();
            rover1.MoveCommand();
            rover1.CurrentPosition.X.Should().Be(1);
            rover1.CurrentPosition.Y.Should().Be(2);
            rover1.CurrentPosition.Direction.Should().Be('W');
        }

        [Test]
        public void Check_Rover_Is_Spinning_Left__Right_And_Moving_Forward()
        {
            plateau1 = new Plateau(5, 5);
            rover1 = new Rover(new Position(1, 2, 'N',1));
            rover1.ValidateRoverPosition(new Plateau(5, 5), new Position(1, 2, 'N',1));
            rover1.SpinLeft();
            rover1.MoveCommand();
            rover1.SpinLeft();
            rover1.MoveCommand();
            rover1.SpinLeft();
            rover1.MoveCommand();
            rover1.SpinLeft();
            rover1.MoveCommand();
            rover1.MoveCommand();
            rover1.CurrentPosition.X.Should().Be(1);
            rover1.CurrentPosition.Y.Should().Be(3);
            rover1.CurrentPosition.Direction.Should().Be('N');
        }
        
        [Test]
        public void Check_Rover_Is_Spinning_Left__Right_And_Moving_Forward2()
        {
            plateau1 = new Plateau(5, 5);
            rover1 = new Rover(new Position(3, 3, 'E',1));
            rover1.ValidateRoverPosition(new Plateau(5, 5), new Position(3, 3, 'E',1));
            rover1.MoveCommand();
            rover1.MoveCommand();
            rover1.SpinRight();
            rover1.MoveCommand();
            rover1.MoveCommand();
            rover1.SpinRight();
            rover1.MoveCommand();
            rover1.SpinRight();
            rover1.SpinRight();
            rover1.MoveCommand();
            rover1.CurrentPosition.X.Should().Be(5);
            rover1.CurrentPosition.Y.Should().Be(1);
            rover1.CurrentPosition.Direction.Should().Be('E');
        }
       
        
        [Test]
        public void Check_Rover_Is_Moved()
        {
            
            plateau1 = new Plateau(5, 5);
            rover1 = new Rover(new Position(3, 3, 'E', 1));
            rover1.ValidateRoverPosition(new Plateau(5, 5), new Position(3, 3, 'E', 1));
            string output = control1.MoveRover("LMR", rover1);
            rover1.CurrentPosition.X.Should().Be(3);
          rover1.CurrentPosition.Y.Should().Be(4);
          rover1.CurrentPosition.Direction.Should().Be('E');
            output.Should().Be("3 4 E");

        } 
        [Test]
        public void Check_2_Rovers_In_Case_Of_Collision()
        {
            plateau1 = new Plateau(5, 5);
            rover1 = new Rover(new Position(1, 1, 'N', 1));
            rover2 = new Rover(new Position(1,2, 'E', 2));
            rover1.ValidateRoverPosition(new Plateau(5, 5), new Position(1, 1, 'N', 1));
            rover2.ValidateRoverPosition(new Plateau(5, 5), new Position(1, 2, 'E', 2));
            var ex = Assert.Throws<ArgumentException>(() => control1.MoveRover("M", rover1));
            Assert.That(ex.Message, Is.EqualTo("Collision - Cant move further. Rover2 is there"));
            
        }

        

     
        [Test]
         public void Check_2Rovers_Without_Collision()
         {
            plateau1 = new Plateau(5, 5);
            rover1 = new Rover(new Position(1, 2, 'N', 1));
            rover2 = new Rover(new Position(3,3, 'E', 2));
            rover1.ValidateRoverPosition(new Plateau(5, 5), new Position(1, 2, 'N', 1));
            rover2.ValidateRoverPosition(new Plateau(5, 5), new Position(3,3, 'E', 2));
            string output1 = control1.MoveRover("LMLMLMLMM",rover1);
            string output2 = control1.MoveRover("MMRMMRMRRM",rover2);
            string expectedResult1 = "1 3 N";
            string expectedResult2 = "5 1 E";
            output1.Should().Be(expectedResult1);
            output2.Should().Be(expectedResult2);
            
        }
       
    }
}
