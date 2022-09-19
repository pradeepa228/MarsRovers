using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MRover
{
    public class Rover
    {
        private PlateauDimensions plateaudimensions;
        public Position CurrentPosition { get; set; }

        public Rover(PlateauDimensions plateaudimensions)
        {
            this.plateaudimensions = plateaudimensions;
        }
        
        public void checkRoverPosition(Position position)
        {
            if ((position.X > plateaudimensions.X) || (position.Y > plateaudimensions.Y))
            {
                throw new ArgumentException("Rover can not be placed outside the Plateau dimension.");
            }
            else
            {
                CurrentPosition = position;
            }
        }
        
        
        public void SpinRight()
        {
           switch (CurrentPosition.Direction)
            {
                case 'N':
                    CurrentPosition.Direction = 'E';
                    break;
                case 'E':
                    CurrentPosition.Direction = 'S';
                    break;
                case 'S':
                    CurrentPosition.Direction = 'W';
                    break;  
                case 'W':
                    CurrentPosition.Direction = 'N';
                    break;
            }   
        }

        public void SpinLeft()
        {
            switch (CurrentPosition.Direction)
            {
                case 'N':
                    CurrentPosition.Direction = 'W';
                    break;
                case 'E':
                    CurrentPosition.Direction = 'N';
                    break;
                case 'S':
                    CurrentPosition.Direction = 'E';
                    break;
                case 'W':
                    CurrentPosition.Direction = 'S';
                    break;
            }
        }


        public void MoveCommand()
        {
            if (CurrentPosition.Direction == 'N')
            {
                CurrentPosition.Y = CurrentPosition.Y + 1;
            }
            else if (CurrentPosition.Direction == 'E')
            {
                CurrentPosition.X = CurrentPosition.X + 1;
            }
            else if (CurrentPosition.Direction == 'S')
            {
                CurrentPosition.Y = CurrentPosition.Y - 1;
            }
            else
            {
                CurrentPosition.X = CurrentPosition.X - 1;
            }

        }

    }
}
