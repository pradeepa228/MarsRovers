using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MRover
{
    public class Rover
    {
        private PlateauDimensions plateaudimensions;
        public Position CurrentPosition { get; private set; }

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
        
        
        public void moveRover(Position position)
        {

        }
    }
}
