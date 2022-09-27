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
            var strRoverName = "";

            if (CurrentPosition.Direction == 'N')
            {
                CurrentPosition.Y += 1;

                strRoverName = CheckCollisionwithOtherRovers(Rover.RoverPositionInfo, CurrentPosition);
                if (strRoverName != "")
                {
                    CurrentPosition.Y -= 1;
                    throw new ArgumentException("Collision - Cant move further. Rover" + strRoverName + " is there");

                }

            }
            else if (CurrentPosition.Direction == 'E')
            {
                CurrentPosition.X += 1;
                strRoverName = CheckCollisionwithOtherRovers(Rover.RoverPositionInfo, CurrentPosition);
                if (strRoverName != "")
                {
                    CurrentPosition.X -= 1;
                    throw new ArgumentException("Collision - Cant move further. Rover" + strRoverName + " is there");
                }

            }
            else if (CurrentPosition.Direction == 'S')
            {
                CurrentPosition.Y -= 1;
                strRoverName = CheckCollisionwithOtherRovers(Rover.RoverPositionInfo, CurrentPosition);
                if (strRoverName != "")
                {
                    CurrentPosition.Y += 1;
                    throw new ArgumentException("Collision - Cant move further. Rover" + strRoverName + " is there");
                }
            }
            else if (CurrentPosition.Direction == 'W')
            {
                CurrentPosition.X -= 1;
                strRoverName = CheckCollisionwithOtherRovers(Rover.RoverPositionInfo, CurrentPosition);
                if (strRoverName != "")
                {
                    CurrentPosition.X += 1;
                    throw new ArgumentException("Collision - Cant move further. Rover" + strRoverName + " is there");
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
