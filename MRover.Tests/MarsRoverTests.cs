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
        private Controller controller1;

        [SetUp]
        public void Setup()
        {
            controller1 = new Controller();
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
            var ex = Assert.Throws<ArgumentException>(() => new Rover(new Position(-1, 1, 'E')));
            Assert.That(ex.Message, Is.EqualTo("Position can not have negative values."));
        }
        [Test]
        public void Throws_Exception_When_Rover_Has_Invalid_Direction()
        {
            plateau1 = new Plateau(5, 5);
            var ex = Assert.Throws<ArgumentException>(() => new Rover(new Position(1, 1, 'P')));
            Assert.That(ex.Message, Is.EqualTo("Position can not have an invalid direction."));
        }
        [Test]
        public void Throws_Exception_When_Rover_Is_Placed_Outside_The_Plateau()
        {
            plateau1 = new Plateau(5, 5);
            rover1 = new Rover(new Position(1, 6, 'E'));
            var ex = Assert.Throws<ArgumentException>(() => rover1.ValidateRoverPosition(new Plateau(5, 5), new Position(1, 6, 'E')));
            Assert.That(ex.Message, Is.EqualTo("Rover can not be placed outside the Plateau dimension."));
        }

        [Test]
        public void Check_Rover_Is_Placed_In_Right_Direction()
        {
            rover1.ValidateRoverPosition(new Plateau(5, 5), new Position(1, 1, 'S'));
            rover1.CurrentPosition.X.Should().Be(1);
            rover1.CurrentPosition.Y.Should().Be(1);
            rover1.CurrentPosition.Direction.Should().Be('S');
        }

        [Test]
        public void Check_Rover_Is_Moved_In_Right_Direction()
        {
            rover1.ValidateRoverPosition(new Plateau(5, 5), new Position(1, 1, 'W'));
            rover1.SpinRight();
            rover1.CurrentPosition.X.Should().Be(1);
            rover1.CurrentPosition.Y.Should().Be(1);
            rover1.CurrentPosition.Direction.Should().Be('N');
        }


        [Test]
        public void Check_Rover_Is_Moved_In_Left_Direction()
        {      
            rover1.ValidateRoverPosition(new Plateau(5, 5), new Position(1, 1, 'W'));
            rover1.SpinLeft();
            rover1.CurrentPosition.X.Should().Be(1);
            rover1.CurrentPosition.Y.Should().Be(1);
            rover1.CurrentPosition.Direction.Should().Be('S');
        }

        [Test]
        public void Check_Rover_Is_Moved_In_A_Forward_Direction_Of_North()
        {
            rover1.ValidateRoverPosition(new Plateau(5, 5), new Position(1, 1, 'N'));
            rover1.MoveCommand();
            rover1.CurrentPosition.X.Should().Be(1);
            rover1.CurrentPosition.Y.Should().Be(2);
            rover1.CurrentPosition.Direction.Should().Be('N');
        }

        [Test]
        public void Check_Rover_Is_Moved_In_A_Forward_Direction_Of_South()
        {
            plateau1 = new Plateau(5, 5);
            rover1 = new Rover(new Position(1, 1, 'S'));
            rover1.ValidateRoverPosition(new Plateau(5, 5), new Position(1, 1, 'S'));
            rover1.MoveCommand();
            rover1.CurrentPosition.X.Should().Be(1);
            rover1.CurrentPosition.Y.Should().Be(0);
            rover1.CurrentPosition.Direction.Should().Be('S');
        }

        [Test]
        public void Check_Rover_Is_Moved_In_A_Forward_Direction_Of_East()
        {
            plateau1 = new Plateau(5, 5);
            rover1 = new Rover(new Position(1, 1, 'E'));
            rover1.ValidateRoverPosition(new Plateau(5, 5), new Position(1, 1, 'E'));
            rover1.MoveCommand();
            rover1.CurrentPosition.X.Should().Be(2);
            rover1.CurrentPosition.Y.Should().Be(1);
            rover1.CurrentPosition.Direction.Should().Be('E');
        }

        [Test]
        public void Check_Rover_Is_Moved_In_A_Forward_Direction_Of_West()
        {
            plateau1 = new Plateau(5, 5);
            rover1 = new Rover(new Position(1, 1, 'W'));
            rover1.ValidateRoverPosition(new Plateau(5, 5), new Position(1, 1, 'W'));
            rover1.MoveCommand();
            rover1.CurrentPosition.X.Should().Be(0);
            rover1.CurrentPosition.Y.Should().Be(1);
            rover1.CurrentPosition.Direction.Should().Be('W');
        }

        [Test]
        public void Check_Rover_Is_Spinning_Right_And_Moving_Forward()
        {
            plateau1 = new Plateau(5, 5);
            rover1 = new Rover(new Position(1, 1, 'N'));
            rover1.ValidateRoverPosition(new Plateau(5, 5), new Position(1, 1, 'N'));
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
            rover1 = new Rover(new Position(2, 2, 'N'));
            rover1.ValidateRoverPosition(new Plateau(5, 5), new Position(2, 2, 'N'));
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
            rover1 = new Rover(new Position(1, 2, 'N'));
            rover1.ValidateRoverPosition(new Plateau(5, 5), new Position(1, 2, 'N'));
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
            rover1 = new Rover(new Position(3, 3, 'E'));
            rover1.ValidateRoverPosition(new Plateau(5, 5), new Position(3, 3, 'E'));
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
        [TestCase("-1 4\n1 3 E\n R", 3, 3, 'S')]
        public void Throws_Exception_when_Plateau_Has_Negative_Position(string inputString, int XCo, int YCo, char dimension)
        {

            var ex = Assert.Throws<ArgumentException>(() => controller1.MissionControl(inputString));
            Assert.That(ex.Message, Is.EqualTo("Plateau can not be created with negative values."));


        }
        [TestCase("5 4\n-1 3 E\n R", 3, 3, 'S')]
        public void Throws_Exception_when_Rover_Has_Negative_Position(string inputString, int XCo, int YCo, char dimension)
        {

            var ex = Assert.Throws<ArgumentException>(() => controller1.MissionControl(inputString));
            Assert.That(ex.Message, Is.EqualTo("Position can not have negative values."));


        }
        [TestCase("5 4\n6 3 E\n R", 3, 3, 'S')]
        public void Throws_Exception_when_Rover_Is_Placed_outside_Plateau(string inputString, int XCo, int YCo, char dimension)
        {

            var ex = Assert.Throws<ArgumentException>(() => controller1.MissionControl(inputString));
            Assert.That(ex.Message, Is.EqualTo("Rover can not be placed outside the Plateau dimension."));


        }

        [TestCase("5 4\n3 3 E\n P")]
        public void Throws_Exception_InCaseOf_Invalid_Movement(string inputString)
        {
            var ex = Assert.Throws<ArgumentException>(() => controller1.MissionControl(inputString));
            Assert.That(ex.Message, Is.EqualTo("Incorrect Move inputs.Valid Inputs are L or M or R"));
        }

        [TestCase("5 5\n1 2 N\nLMLMLMLMM", 1, 3, 'N')]
        [TestCase("5 5\n3 3 E\nMMRMMRMRRM", 5, 1, 'E')]
        public void Check_Rover_Is_Moved_As_Per_Commands(string inputString, int XCo, int YCo, char dimension)
        {
            string output = controller1.MissionControl(inputString);

            controller1.RoverPosition.X.Should().Be(XCo);
            controller1.RoverPosition.Y.Should().Be(YCo);
            controller1.RoverPosition.Direction.Should().Be(dimension);
        }


        [TestCase("5 5\n1 2 N\nLMLMLMLMM\n3 3 E\nMMRMMRMRRM", 1, 3, 'N', 5, 1, 'E')]
        public void Check_2_Rovers_Are_Moved_As_Per_Command2(string inputString, int XCo1, int YCo1, char dimension1, int XCo2, int YCo2, char dimension2)
        {
            string output = controller1.MissionControl(inputString);
            string expectedResult = XCo1 + " " + YCo1 + " " + dimension1 + "\n" + XCo2 + " " + YCo2 + " " + dimension2 + "\n";
            output.Should().Be(expectedResult);
        }

        [TestCase("5 5\n1 2 N\nLMLMLMLMM\n3 3 E\nMMRMMRMRRM\n3 3 S\nR", 1, 3, 'N', 5, 1, 'E', 3, 3, 'W')]
        public void Check_2_Rovers_Are_Moved_As_Per_Command3(string inputString, int XCo1, int YCo1, char dimension1, int XCo2, int YCo2, char dimension2, int XCo3, int YCo3, char dimension3)
        {
            string output = controller1.MissionControl(inputString);
            string expectedResult = XCo1 + " " + YCo1 + " " + dimension1 + "\n" + XCo2 + " " + YCo2 + " " + dimension2 + "\n" + XCo3 + " " + YCo3 + " " + dimension3 + "\n";
            output.Should().Be(expectedResult);
        }
    }
}
