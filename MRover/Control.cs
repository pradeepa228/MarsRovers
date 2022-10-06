using System;
using System.Collections;
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

        public string MoveRover(string moveInput, Rover rover, Plateau plateau)
        {
            string roverPosition = "";
            char[] movements = moveInput.ToCharArray();

            foreach (char oneCommand in movements)
            {
                if (Enum.IsDefined(typeof(Commands), char.ToString(oneCommand)))
                {
                    if (oneCommand == 'L')
                    {
                        SpinLeft(rover);
                    }
                    else if (oneCommand == 'R')
                    {
                        SpinRight(rover);
                    }
                    else if (oneCommand == 'M')
                    {
                        MoveCommand(rover, plateau);
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

        public void SpinRight(Rover rover)
        {
            switch (rover.CurrentPosition.Direction)
            {
                case 'N':
                    rover.CurrentPosition.Direction = 'E';
                    break;
                case 'E':
                    rover.CurrentPosition.Direction = 'S';
                    break;
                case 'S':
                    rover.CurrentPosition.Direction = 'W';
                    break;
                case 'W':
                    rover.CurrentPosition.Direction = 'N';
                    break;
            }
        }

        public void SpinLeft(Rover rover)
        {
            switch (rover.CurrentPosition.Direction)
            {
                case 'N':
                    rover.CurrentPosition.Direction = 'W';
                    break;
                case 'E':
                    rover.CurrentPosition.Direction = 'N';
                    break;
                case 'S':
                    rover.CurrentPosition.Direction = 'E';
                    break;
                case 'W':
                    rover.CurrentPosition.Direction = 'S';
                    break;
            }
        }


        public void MoveCommand(Rover rover, Plateau plateau)
        {
            var strRoverName = "";

            if (rover.CurrentPosition.Direction == 'N')
            {
                rover.CurrentPosition.Y += 1;

                strRoverName = CheckCollisionwithOtherRovers(Rover.RoverPositionInfo, rover.CurrentPosition);
                if (strRoverName != "")
                {
                    rover.CurrentPosition.Y -= 1;
                    throw new ArgumentException("Collision - Cant move further. Rover" + strRoverName + " is there");
                }
                if(rover.CurrentPosition.Y > plateau.Y)
                {
                    rover.CurrentPosition.Y -= 1;
                    throw new ArgumentException("Rover can't move beyond this point because of plateau size");
                }

            }
            else if (rover.CurrentPosition.Direction == 'E')
            {
                rover.CurrentPosition.X += 1;
                strRoverName = CheckCollisionwithOtherRovers(Rover.RoverPositionInfo, rover.CurrentPosition);
                if (strRoverName != "")
                {
                    rover.CurrentPosition.X -= 1;
                    throw new ArgumentException("Collision - Cant move further. Rover" + strRoverName + " is there");
                }
                if (rover.CurrentPosition.X > plateau.X)
                {
                    rover.CurrentPosition.X -= 1;
                    throw new ArgumentException("Rover can't move beyond this point because of plateau size");
                }

            }
            else if (rover.CurrentPosition.Direction == 'S')
            {
                rover.CurrentPosition.Y -= 1;
                strRoverName = CheckCollisionwithOtherRovers(Rover.RoverPositionInfo, rover.CurrentPosition);
                if (strRoverName != "")
                {
                    rover.CurrentPosition.Y += 1;
                    throw new ArgumentException("Collision - Cant move further. Rover" + strRoverName + " is there");
                }
                if (rover.CurrentPosition.Y > plateau.Y)
                {
                    rover.CurrentPosition.Y += 1;
                    throw new ArgumentException("Rover can't move beyond this point because of plateau size");
                }
            }
            else if (rover.CurrentPosition.Direction == 'W')
            {
                rover.CurrentPosition.X -= 1;
                strRoverName = CheckCollisionwithOtherRovers(Rover.RoverPositionInfo, rover.CurrentPosition);
                if (strRoverName != "")
                {
                    rover.CurrentPosition.X += 1;
                    throw new ArgumentException("Collision - Cant move further. Rover" + strRoverName + " is there");
                }
                if (rover.CurrentPosition.X > plateau.X)
                {
                    rover.CurrentPosition.X -= 1;
                    throw new ArgumentException("Rover can't move beyond this point because of plateau size");
                }
            }
        }

        public string CheckCollisionwithOtherRovers(Hashtable RoverPositionInfo, Position CurrentPosition)
        {
            string strCurrentPoint = CurrentPosition.X.ToString() + CurrentPosition.Y.ToString();

            foreach (DictionaryEntry eachPosition in RoverPositionInfo)
            {
                if (eachPosition.Key.ToString() != CurrentPosition.RoverNumber.ToString())
                {
                    if (eachPosition.Value.ToString() == strCurrentPoint)
                    {
                        return eachPosition.Key.ToString();
                    }
                }
            }
            return "";
        }
    }
}
