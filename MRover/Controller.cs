using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRover
{
    public class Controller
    {
        public Position RoverPosition { get => rover.CurrentPosition; }
        private PlateauDimensions plateau;
        private Rover rover;

        public Controller()
        {

        }
        public void CheckPlateau(string plateauInput)
        {
            var modifiedInput =  Array.ConvertAll(plateauInput.Trim().Split(' '),x => Convert.ToInt32(x));
            Console.WriteLine("input after conversion:", modifiedInput);

           
            if (modifiedInput[0] < 0 || modifiedInput[1] < 0)
            {
                throw new ArgumentException("Plateau can not be created with negative values.");
            }
            plateau = new PlateauDimensions(modifiedInput[0], modifiedInput[1]);
         }

        public void AddRover(string roverInput)
        {
            var roverPosition = roverInput.Split(' ');
            Console.WriteLine("X: " + Convert.ToInt32(roverPosition[0]));
            Console.WriteLine("Y: " + Convert.ToInt32(roverPosition[1]));
            Console.WriteLine("Direction: " + Convert.ToChar(roverPosition[2]));
            rover = new Rover(new Position(Convert.ToInt32(roverPosition[0]), Convert.ToInt32(roverPosition[1]), Convert.ToChar(roverPosition[2])));

        }

        public void MoveRover(string moveInput)
        {
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
        }
        
    }
}
