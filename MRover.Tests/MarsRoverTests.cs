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
         public void Check_Rover_Is_Placed_In_A_Valid_Position_On_The_Plateau()
         {
             plateau1 = new Plateau(5, 5);
             rover1 = new Rover(new Position(1, 1, 'N')); 
             rover1.CurrentPosition.X.Should().Be(1);
             rover1.CurrentPosition.Y.Should().Be(1);
             rover1.CurrentPosition.Direction.Should().Be('N');
         }
       
        [Test]
        public void Check_Rover_Is_Placed_In_A_Valid_Direction_On_The_Plateau()
        {
            plateau1 = new Plateau(5, 5);
            rover1 = new Rover(new Position(1,1,'E'));
            rover1.CurrentPosition.X.Should().Be(1);
            rover1.CurrentPosition.Y.Should().Be(1);
            rover1.CurrentPosition.Direction.Should().Be('E');
        }

        [Test]
        public void Check_Rover_Is_Moved_In_Right_Direction()
        {
            plateau1 = new Plateau(5, 5);
            rover1 = new Rover(new Position(1,1,'W'));
            rover1.SpinRight();
            rover1.CurrentPosition.X.Should().Be(1);
            rover1.CurrentPosition.Y.Should().Be(1);
            rover1.CurrentPosition.Direction.Should().Be('N');
        }

        [Test]
        public void Check_Rover_Is_Moved_In_Left_Direction()
        {
            plateau1 = new Plateau(5, 5);
            rover1 = new Rover(new Position(1, 1, 'W'));
            rover1.SpinLeft();
            rover1.CurrentPosition.X.Should().Be(1);
            rover1.CurrentPosition.Y.Should().Be(1);
            rover1.CurrentPosition.Direction.Should().Be('S');
        }
        
       [Test]
       public void Check_Rover_Is_Moved_In_A_Forward_Direction_Of_North()
       {
           plateau1 = new Plateau(5, 5);
           rover1 = new Rover(new Position(1, 1, 'N'));
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
       
     [TestCase("5 4\n3 3 E\n R", 3, 3, 'S')]
     public void Check_Rover_Is_Moved_As_Per_Command_Test3(string inputString, int XCo, int YCo, char dimension)
     {

         string output = controller1.MissionControl(inputString);

         controller1.RoverPosition.X.Should().Be(XCo);
         controller1.RoverPosition.Y.Should().Be(YCo);
         controller1.RoverPosition.Direction.Should().Be(dimension);
     }

     [TestCase("5 5\n1 2 N\nLMLMLMLMM", 1, 3, 'N')]
     public void Check_Rover_Is_Moved_As_Per_Commands(string inputString, int XCo, int YCo, char dimension)
     {
         string output = controller1.MissionControl(inputString);
         
         controller1.RoverPosition.X.Should().Be(XCo);
         controller1.RoverPosition.Y.Should().Be(YCo);
         controller1.RoverPosition.Direction.Should().Be(dimension);
     }

     [TestCase("5 5\n3 3 E\nMMRMMRMRRM", 5, 1, 'E')]
     public void Check_Rover_Is_Moved_As_Per_Commands2(string inputString, int XCo, int YCo, char dimension)
     {
         string output = controller1.MissionControl(inputString);
         
         controller1.RoverPosition.X.Should().Be(XCo);
         controller1.RoverPosition.Y.Should().Be(YCo);
         controller1.RoverPosition.Direction.Should().Be(dimension);
     }
     
        [TestCase("5 5\n3 3 E\nMMRMMRMRRM\n1 1 N\nR", 5, 1, 'E',1,1,'E')]
        public void Check_2_Rovers_Are_Moved_As_Per_Commands(string inputString, int XCo1, int YCo1, char dimension1, int XCo2, int YCo2, char dimension2)
        {       

            string output =  controller1.MissionControl(inputString);
            Console.WriteLine("output:" + output);
            
            string expectedResult = XCo1 + " " + YCo1 + " " + dimension1 + "\n"+ XCo2 + " " + YCo2 +" "+ dimension2+"\n";
            Console.WriteLine("expecetd:" + expectedResult); 
            output.Should().Be(expectedResult);
         
        }

        [TestCase("5 5\n1 2 N\nLMLMLMLMM\n3 3 E\nMMRMMRMRRM", 1, 3, 'N', 5, 1, 'E')]
        public void Check_2_Rovers_Are_Moved_As_Per_Command2(string inputString, int XCo1, int YCo1, char dimension1, int XCo2, int YCo2, char dimension2)
        {
            string output = controller1.MissionControl(inputString);
            Console.WriteLine("output:" + output);

            string expectedResult = XCo1 + " " + YCo1 + " " + dimension1 + "\n" + XCo2 + " " + YCo2 + " " + dimension2 + "\n";
            Console.WriteLine("expecetd:" + expectedResult);
            output.Should().Be(expectedResult);
        }

        [TestCase("5 5\n1 2 N\nLMLMLMLMM\n3 3 E\nMMRMMRMRRM\n3 3 S\nR", 1, 3, 'N', 5, 1, 'E',3,3,'W')]
        public void Check_2_Rovers_Are_Moved_As_Per_Command3(string inputString, int XCo1, int YCo1, char dimension1, int XCo2, int YCo2, char dimension2, int XCo3, int YCo3, char dimension3)
        {
            string output = controller1.MissionControl(inputString);
            Console.WriteLine("output:" + output);

            string expectedResult = XCo1 + " " + YCo1 + " " + dimension1 + "\n" + XCo2 + " " + YCo2 + " " + dimension2 + "\n"+ XCo3 + " " + YCo3 + " " + dimension3 + "\n";
            Console.WriteLine("expecetd:" + expectedResult);
            output.Should().Be(expectedResult);
        }
    }
}
