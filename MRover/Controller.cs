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
        public Position RoverPosition { get => rover.CurrentPosition; }
        private Plateau plateau;
        private Rover rover;
        public Commands Commands;
        public Directions Direction;

        private string stringInput;
        private static string command;
        private static string[] modifiedInput;
        private const char linesDelimeter = '\n';
        private const char parametersDelimeter = ' ';
        int lengthOfInputs = 0;
        string outputString;
        string finalRoverPosition = "";
        string[] plateauDimension;

        public string MissionControl(string stringInput)
        {
            //Splitting the input by lines
            SplitInputByLines(stringInput);
            //Set Plateau
            plateauDimension = SetPlateauInput(modifiedInput[0]);

            //Set Rover and move the Rover as per commands
            lengthOfInputs = modifiedInput.Length;

            for (int iteration = 1; iteration < modifiedInput.Length; iteration++)
            {
                if (iteration % 2 != 0)
                {
                    SetRoverPosition(plateauDimension, modifiedInput[iteration]);
                }
                else
                {
                    outputString = MoveRover(modifiedInput[iteration]);
                    finalRoverPosition = string.Concat(finalRoverPosition, outputString, linesDelimeter);

                }
            }
            return finalRoverPosition;
        }



        public void SplitInputByLines(string stringInput)
        {
            var splitString = stringInput.Split(linesDelimeter);

            if (splitString.Length % 2 != 1)
            {                 
                throw new ArgumentException("Incorrect format of input");
            }

            modifiedInput = splitString;
        }


        public static string[] SetPlateauInput(string modifiedInput)
        {
            string[] splitString = modifiedInput.Split(' ');

            var plateau = new Plateau(Convert.ToInt32(splitString[0]), Convert.ToInt32(splitString[1]));
            return splitString;
        }

        public void SetRoverPosition(string[] plateauDimension, string roverInput)
        {
            var roverPosition = roverInput.Split(' ');
            int plateauDimensionX = Convert.ToInt32(plateauDimension[0]);
            int plateauDimensionY = Convert.ToInt32(plateauDimension[1]);
            int roverXposition = Convert.ToInt32(roverPosition[0]);
            int roverYposition = Convert.ToInt32(roverPosition[1]);
            char roverDirection = Convert.ToChar(roverPosition[2]);

            rover = new Rover(new Position(roverXposition, roverYposition, roverDirection));
            rover.ValidateRoverPosition(new Plateau(plateauDimensionX, plateauDimensionY), new Position(roverXposition, roverYposition, roverDirection));
        }

        public string MoveRover(string moveInput)
        {
            string roverPosition = "";
            char[] movements = moveInput.ToCharArray();

            foreach (char oneCommand in movements)
            {
                if (Enum.IsDefined(typeof(Commands), char.ToString(oneCommand)))
                {
                    if (oneCommand == 'L')
                    {
                        rover.SpinLeft();
                    }
                    else if (oneCommand == 'R')
                    {
                        rover.SpinRight();
                    }
                    else if (oneCommand == 'M')
                    {
                        rover.MoveCommand();
                    }
                }
                else
                {
                    throw new ArgumentException("Incorrect Move inputs.Valid Inputs are L or M or R");
                }
            }
            roverPosition = string.Concat(rover.CurrentPosition.X, " ", rover.CurrentPosition.Y, " ", rover.CurrentPosition.Direction);
            return roverPosition;
        }
    }
}
