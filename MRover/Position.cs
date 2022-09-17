using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MRover
{
    public class Position
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public char Direction { get; private set; }

        private const string directionToMove = "N|E|S|W";

        public Position(int x, int y, char direction)
        {
            if (x < 0 || y < 0 || !Regex.IsMatch(direction.ToString(), directionToMove))
            {
                throw new ArgumentException("Position can not have negative values or invalid direction.");
            }
            else
            {
                X = x;
                Y = y;
                Direction = direction;
            }
        }
    }
    }