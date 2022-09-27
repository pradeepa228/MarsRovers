using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRover
{
    public class Control
    {
        public Position RoverPosition { get => rover.CurrentPosition; }
        private Plateau plateau;
        private Rover rover;
        public Control()
        {
        }

        public string MoveRover(string moveInput, Rover rover)
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
