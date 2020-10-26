using Cubes;
using NUnit.Framework;
using System;

namespace Cube.NUnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void Operator_isInside_ReturnsTrue()
        {
            var cube = new Cubes.Cube(new Point(0, 0, 0), 2);
            var point = new Point(1, 1, 1);

            var result = Operators.IsInside(cube, point);

            Assert.IsTrue(result);
        }

        [Test]
        public void Operator_isInside_ReturnsFalse()
        {
            var cube = new Cubes.Cube(new Point(0, 0, 0), 1);
            var point = new Point(2, 2, 2);

            var result = Operators.IsInside(cube, point);

            Assert.IsFalse(result);
        }

        [Test]
        public void I3dObject_Volume_NonNegative()
        {
            bool failed = false;

            for (int i = 0; i < 100; i++)
            {
                var object1 = new Cubes.Cube(new Point(new Random().NextDouble(), new Random().NextDouble(), new Random().NextDouble()), new Random().NextDouble());
                if(object1.Volume() < 0) { failed = true; break; }
            }

            Assert.IsFalse(failed);
        }

        [Test]
        public void I3dObject_minDimension_maxDimension()
        {
            bool failed = false;

            for (int i = 0; i < 100; i++)
            {
                var object1 = new Cubes.Cube(new Point(new Random().NextDouble(), new Random().NextDouble(), new Random().NextDouble()), new Random().NextDouble());
                if (object1.MinDimension(Dimension.Axis.x) > object1.MaxDimension(Dimension.Axis.x)) { failed = true; break; }
                if (object1.MinDimension(Dimension.Axis.y) > object1.MaxDimension(Dimension.Axis.y)) { failed = true; break; }
                if (object1.MinDimension(Dimension.Axis.z) > object1.MaxDimension(Dimension.Axis.z)) { failed = true; break; }
            }

            Assert.IsFalse(failed);
        }

        [Test]
        public void Operator_cubeIntersec_ReturnsNull()
        {
            var cubes = new Cubes.Cube[2]
                {
                    new Cubes.Cube(new Point ( 1, 1, 1 ), 1),
                    new Cubes.Cube(new Point ( -1, -1, -1 ), 1)
                }; 

            var result = Operators.CubeIntersec(cubes[0], cubes[1]);

            Assert.IsNull(result);
        }

        [Test]
        public void Operator_cubeIntersec_ReturnsBoxWithVolume()
        {
            var cubes = new Cubes.Cube[2]
                {
                    new Cubes.Cube(new Point ( 1, 1, 1 ), 4),
                    new Cubes.Cube(new Point ( -1, -1, -1 ), 3)
                };

            var result = Operators.CubeIntersec(cubes[0], cubes[1]);

            Assert.GreaterOrEqual(result.Volume(), 0);
        }

    }
}