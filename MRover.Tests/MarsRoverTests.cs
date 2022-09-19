﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FluentAssertions;

namespace MRover.Tests
{
    public class MarsRoverTests
    {
        private PlateauDimensions plateau1;
        private Rover rover1;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Check_Rover_Is_Placed_In_A_Valid_Position_On_The_Plateau()
        {
            plateau1 = new PlateauDimensions(5, 5);
            rover1 = new Rover(plateau1);
            rover1.checkRoverPosition(new Position(1, 1, 'N'));
            rover1.CurrentPosition.X.Should().Be(1);
            rover1.CurrentPosition.Y.Should().Be(1);
            rover1.CurrentPosition.Direction.Should().Be('N');
        }

        [Test]
        public void Check_Rover_Is_Placed_In_A_Valid_Direction_On_The_Plateau()
        {
            plateau1 = new PlateauDimensions(5, 5);
            rover1 = new Rover(plateau1);
            rover1.checkRoverPosition(new Position(1, 1, 'E'));
            rover1.CurrentPosition.X.Should().Be(1);
            rover1.CurrentPosition.Y.Should().Be(1);
            rover1.CurrentPosition.Direction.Should().Be('E');
        }

        [Test]
        public void Check_if_It_Throws_Error_When_Placed_In_A_InValid_Position()
        {
            plateau1 = new PlateauDimensions(5, 5);
            rover1 = new Rover(plateau1);
            rover1.checkRoverPosition(new Position(1, 1, 'N'));
            rover1.CurrentPosition.X.Should().Be(1);
            rover1.CurrentPosition.Y.Should().Be(1);
            rover1.CurrentPosition.Direction.Should().Be('N');
        }

        [Test]
        public void Check_Rover_Is_Moved_In_Right_Direction()
        {
            plateau1 = new PlateauDimensions(5, 5);
            rover1 = new Rover(plateau1);
            rover1.checkRoverPosition(new Position(1, 1, 'W'));
            rover1.SpinRight();
            rover1.CurrentPosition.X.Should().Be(1);
            rover1.CurrentPosition.Y.Should().Be(1);
            rover1.CurrentPosition.Direction.Should().Be('N');
        }

        [Test]
        public void Check_Rover_Is_Moved_In_Left_Direction()
        {
            plateau1 = new PlateauDimensions(5, 5);
            rover1 = new Rover(plateau1);
            rover1.checkRoverPosition(new Position(1, 1, 'W'));
            rover1.SpinLeft();
            rover1.CurrentPosition.X.Should().Be(1);
            rover1.CurrentPosition.Y.Should().Be(1);
            rover1.CurrentPosition.Direction.Should().Be('S');
        }


        [Test]
        public void Check_Rover_Is_Moved_In_A_Forward_Direction_Of_North()
        {
            plateau1 = new PlateauDimensions(5, 5);
            rover1 = new Rover(plateau1);
            rover1.checkRoverPosition(new Position(1, 1, 'N'));
            rover1.MoveCommand();
            rover1.CurrentPosition.X.Should().Be(1);
            rover1.CurrentPosition.Y.Should().Be(2);
            rover1.CurrentPosition.Direction.Should().Be('N');
        }

        [Test]
        public void Check_Rover_Is_Moved_In_A_Forward_Direction_Of_South()
        {
            plateau1 = new PlateauDimensions(5, 5);
            rover1 = new Rover(plateau1);
            rover1.checkRoverPosition(new Position(1, 1, 'S'));
            rover1.MoveCommand();
            rover1.CurrentPosition.X.Should().Be(1);
            rover1.CurrentPosition.Y.Should().Be(0);
            rover1.CurrentPosition.Direction.Should().Be('S');
        }

        [Test]
        public void Check_Rover_Is_Moved_In_A_Forward_Direction_Of_East()
        {
            plateau1 = new PlateauDimensions(5, 5);
            rover1 = new Rover(plateau1);
            rover1.checkRoverPosition(new Position(1, 1, 'E'));
            rover1.MoveCommand();
            rover1.CurrentPosition.X.Should().Be(2);
            rover1.CurrentPosition.Y.Should().Be(1);
            rover1.CurrentPosition.Direction.Should().Be('E');
        }

        [Test]
        public void Check_Rover_Is_Moved_In_A_Forward_Direction_Of_West()
        {
            plateau1 = new PlateauDimensions(5, 5);
            rover1 = new Rover(plateau1);
            rover1.checkRoverPosition(new Position(1, 1, 'W'));
            rover1.MoveCommand();
            rover1.CurrentPosition.X.Should().Be(0);
            rover1.CurrentPosition.Y.Should().Be(1);
            rover1.CurrentPosition.Direction.Should().Be('W');
        }
    }
}
