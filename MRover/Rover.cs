using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace MRover
{
    public class Rover
    {
        private Plateau plateau;
        public Position CurrentPosition { get; set; }
        public int RoverNumber { get; set; }

        public static Hashtable RoverPositionInfo = new Hashtable();

        public Rover(Position position)
        {
            CurrentPosition = position;
        }


        public void ValidateRoverPosition(Plateau plateau, Position position)
        {
            if (plateau is null)
            {
                throw new NullReferenceException("Rover can not be created without a Plateau.");
            }

            if ((position.X > plateau.X) || (position.Y > plateau.Y))
            {
                throw new ArgumentException("Rover can not be placed outside the Plateau dimension.");
            }
            else
            {
                CurrentPosition = position;
                if (Rover.RoverPositionInfo.ContainsKey(position.RoverNumber))
                {
                    Rover.RoverPositionInfo[position.RoverNumber] = position.X.ToString() + position.Y.ToString();
                }
                else
                {
                    Rover.RoverPositionInfo.Add(position.RoverNumber, position.X.ToString() + position.Y.ToString());
                }

            }
        }




    }
}
