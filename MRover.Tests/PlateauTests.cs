using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace MRover.Tests
{
    public class PlateauTests
    {
        private Plateau plateau1;

        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void Set_Plateau_For_The_rover_To_Move()
        {
            plateau1 = new Plateau(5, 5);
            plateau1.X.Should().Be(5);
            plateau1.Y.Should().Be(5);
        }

        [Test]
        public void Throws_exception_If_Plateau_Has_Negative_value()
        {
            var ex = Assert.Throws<ArgumentException>(() => new Plateau(-5, 5));
            Assert.That(ex.Message, Is.EqualTo("Plateau can not be created with negative values."));
        }
    }
}
