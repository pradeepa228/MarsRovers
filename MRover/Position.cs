using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;

namespace MRover
{
    public class Position
    {

        public int X { get; set; }
        public int Y { get; set; }
        public char Direction { get; set; }




        public Position(int x, int y, char roverDirection)
        {
            if (x < 0 || y < 0)
            {
                throw new ArgumentException("Position can not have negative values.");
            }
            else if (!Enum.IsDefined(typeof(Directions), char.ToString(roverDirection)))
            {

                throw new ArgumentException("Position can not have an invalid direction.");
            }
            else
            {
                X = x;
                Y = y;
                Direction = roverDirection;
            }
        }

    }
}