using NUnit.Framework;
using System;

namespace LokiTests.BasicMovement
{
    [TestFixture]
    public class Vector2DTest
    {
        private Vector2D u;
        private Vector2D v;

        [SetUp]
        public void Setup()
        {
            u = new Vector2D();
            v = new Vector2D();
        }

        [Test]
        public void DefaultConstructor_Test()
        {
            u = new Vector2D();
            Assert.True(u.X == 0 && u.Y == 0, $"X: {u.X}, Y: {u.Y}");
        }

        [Test]
        public void ParameterizedConstructor_Test()
        {
            u = new Vector2D(1, 10);
            Assert.True(u.X == 1 && u.Y == 10, $"X: {u.X}, Y: {u.Y}");
        }

        [Test]
        public void OperatorPlus_Test()
        {
            u = new Vector2D(15, 23);
            v = new Vector2D(8, 43);
            Vector2D result = u + v;
            Assert.True(result.X == 23 && result.Y == 66, $"X: {u.X}, Y: {v.Y}");
        }

        [Test]
        public void OperatorMinus_Test()
        {
            u = new Vector2D(15, 23);
            v = new Vector2D(8, 43);
            Vector2D result = u - v;
            Assert.True(result.X == 7 && result.Y == -20, $"X: {u.X}, Y: {v.Y}");
        }

        [Test]
        public void OperatorMultiply_Test()
        {
            u = new Vector2D(15, 23);
            v = new Vector2D(8, 43);
            Vector2D result = u * v;
            Assert.True(result.X == 120 && result.Y == 989, $"X: {u.X}, Y: {v.Y}");
        }

        [Test]
        public void OperatorDivide_Test()
        {
            u = new Vector2D(10, 10);
            v = new Vector2D(5, 20);
            Vector2D result = u / v;
            Assert.True(result.X == 2 && result.Y == 0.5, $"X: {u.X}, Y: {v.Y}");
        }

        [Test]
        public void Zero_Test()
        {
            u = new Vector2D(1, 1);
            u.Zero();
            Assert.True(u.X == 0 && u.Y == 0, $"X: {u.X}, Y: {v.Y}");
        }

        [TestCase(0)]
        [TestCase(double.Epsilon)]
        [TestCase(0.1)]
        public void IsZero_Test(double val)
        {
            u = new Vector2D(val, 0);
            bool result = u.IsZero();
            if (val != 0.1)
            {
                Assert.True(result);
            } else
            {
                Assert.False(result);
            }
        }


        [TestCase(2,3)]
        [TestCase(5,-3)]
        [TestCase(-9,-3)]
        [TestCase(0,0)]
        public void Length_Test(int val1, int val2)
        {
            u = new Vector2D(val1, val2);
            double actual = u.Length();
            double expected = Math.Sqrt(val1 * val1 + val2 * val2);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(2, 3)]
        [TestCase(5, -3)]
        [TestCase(-9, -3)]
        [TestCase(0, 0)]
        public void LengthSq_Test(int val1, int val2)
        {
            u = new Vector2D(val1, val2);
            double actual = u.LengthSq();
            double expected = val1 * val1 + val2 * val2;
            Assert.AreEqual(expected, actual);
        }
    }
}
