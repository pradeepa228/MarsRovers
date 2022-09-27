# MarsRovers
Classes : Plateau, Rover, Position, Controller

Added logic for Plateau dimension - Ensure Plateau doesnt have negative values

Added logic for Rover : Rover position should be within plateau dimension. Direction would be North, South, West, East. 
                        Added Exception for negative Values, and invalid Direction.
                        It has the logic of moving the rover.

Controller will have the logic to check plateau dimension, rover positio and a call to move rover.

Added Enum for Directions and Movements separately.
Added Logic for Collision. Added Rover position with rover number in Hash Table and While MOving, checked the ROver current position with Hash table and throw exception it matches

