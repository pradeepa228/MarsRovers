using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MRover
{
    public class Rover
    {
        private Plateau plateau;
        public Position CurrentPosition { get; private set; }

        public Rover(Plateau plateau)
        {
            this.plateau = plateau;
        }
        
        public void checkRoverPosition(Position position)
        {
            if ((position.X > plateau.X) || (position.Y > plateau.Y))
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
