namespace TestLIB.Tests
{
    [TestFixture]
    public class Tests
    {
        [TestCase(3, 9 * Math.PI)]
        [TestCase(2.5, 6.25 * Math.PI)]
        [TestCase(0, 0)]
        [TestCase(-6, 36 * Math.PI)]
        public void TestCircleWithoutName(double a, double expectedResult)
        {
            Assert.That(ShapesAreaCalculator.Calculate(a), Is.EqualTo(expectedResult));
        }

        [TestCase(4, "circ", 0)]
        [TestCase(0, "circle", 0)]
        [TestCase(-7, "none", 49 * Math.PI)]
        public void TestCircleWithName(double a, string b, double expectedResult)
        {
            Assert.That(ShapesAreaCalculator.Calculate(a, b), Is.EqualTo(expectedResult));
        }

        [TestCase(3, 4, 5, 6)]
        [TestCase(1, 4, 6, 0)]
        [TestCase(-5, -5, 8, 12)]
        public void TestTriangleWithoutName(double a, double b, double c, double expectedResult)
        {
            Assert.That(ShapesAreaCalculator.Calculate(a, b, c), Is.EqualTo(expectedResult));
        }

        [TestCase(3, 4, 5, 6, "none")]
        [TestCase(-5, -5, 8, 12, "triangle")]
        [TestCase(1, 4, 6, 0, "triangle")]
        [TestCase(3, 4, 5, 0, "nope")]
        public void TestTriangleWithName(double a, double b, double c, double expectedResult, string d)
        {
            Assert.That(ShapesAreaCalculator.Calculate(a, b, c, d), Is.EqualTo(expectedResult));
        }

        [TestCase(3, 4,5, new object[] {6, "rectangular"}, "triangle", "yes")]
        [TestCase(1, 1.3, 1.3, new object[] { 0.6, "not rectangular" }, "triangle", "yes")]
        [TestCase(-5, -5, 8, new object[] { 12, "not rectangular" }, "triangle", "yes")]
        [TestCase(1, 4, 6, new object[0], "triangle", "yes")]
        [TestCase(3, 4, 5, new object[0], "circle", "yes")]
        [TestCase(3, 4, 5, new object[0], "triangle", "xd")]
        public void TestTriangleAndSquareness(double a, double b, double c, object expectedResult, string d, string e)
        {
            Assert.That(ShapesAreaCalculator.Calculate(a,b,c,d,e), Is.EqualTo(expectedResult));
        }    
    }
}