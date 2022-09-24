using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace MRover
{
    public class Controller
    {
        private string stringInput;
        public Position RoverPosition { get => rover.CurrentPosition; }
        private Plateau plateau;
        private Rover rover;
        
        private static string currentDirection;
        private static string command;

        private static string[] modifiedInput;
        private const char linesDelimeter = '\n';
        private const char parametersDelimeter = ' ';
        /// <summary>
        /// expectedNumberOfInputLines will have plateau dimension, rover position, move commands
        /// </summary>
        private const int expectedNumberOfInputInALine = 3;
        int lengthOfInputs = 0;
        string outputString;
        string finalRoverPosition="";


        public Controller()
        {
            this.stringInput = stringInput;
        }
        public string MissionControl(string stringInput)
        {
            SplitInputByLines(stringInput);
            SetPlateauInput(modifiedInput[0]);
            lengthOfInputs = modifiedInput.Length;
            Console.WriteLine("Length" + modifiedInput.Length);
            for (int iteration = 1; iteration < modifiedInput.Length; iteration++)
            {
                if (iteration % 2 != 0)
                {
                    Console.WriteLine("Odd number");
                    SetRoverPosition(modifiedInput[iteration]);
                }
                else
                {
                    Console.WriteLine("Even number");
                    outputString = MoveRover(modifiedInput[iteration]);
                    finalRoverPosition = string.Concat(finalRoverPosition, outputString, linesDelimeter);
                    Console.WriteLine("Concatenation" + finalRoverPosition);
                }
            }
            return finalRoverPosition;
        }
    
           

        public void SplitInputByLines(string stringInput)
        {
            var splitString = stringInput.Split(linesDelimeter);
            
            if (splitString.Length %2 != 1)
            {
                Console.WriteLine("Incorrect format of input");
                //   throw new Incorrect Input FormatException();
            }

            modifiedInput = splitString;
        }


         public static void SetPlateauInput(string modifiedInput)
         {
            var splitString = modifiedInput.Split(' ');
            
            var plateau = new Plateau(Convert.ToInt32(splitString[0]), Convert.ToInt32(splitString[1])); 
         }

         public void SetRoverPosition(string roverInput)
        {
            var roverPosition = roverInput.Split(' ');

            rover = new Rover(new Position(Convert.ToInt32(roverPosition[0]), Convert.ToInt32(roverPosition[1]), Convert.ToChar(roverPosition[2])));

        }

        public string MoveRover(string moveInput)
        {
            string roverPosition ="";
            char[] movements = moveInput.ToCharArray();

            foreach ( char command in movements)
            {
                if (command == 'L')
                {
                    rover.SpinLeft();
                }
                else if (command == 'R')
                {
                    rover.SpinRight();
                }
                else if (command == 'M')
                {
                    rover.MoveCommand();
                }
            }
            roverPosition = string.Concat(rover.CurrentPosition.X," " ,rover.CurrentPosition.Y," ", rover.CurrentPosition.Direction);
            return roverPosition;
        }    
    }
}
