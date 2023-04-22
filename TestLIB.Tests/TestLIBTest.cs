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

        [Test]
        public void TestTriangleAndSquareness()
        {
            var expectedResultCaseOne = (6, "rectangular");
            var expectedResultCaseTwo = (0.6, "not rectangular");
            var expectedResultCaseThree = (12, "not rectangular");
            (double,string) expectedResultCaseFour = (0, null);
            (double, string) expectedResultCaseFive = (0, null);
            (double, string) expectedResultCaseSix = (0, null);
            Assert.That(expectedResultCaseOne, Is.EqualTo(ShapesAreaCalculator.Calculate(3, 4,5, "triangle", "yes")));
            Assert.That(expectedResultCaseTwo, Is.EqualTo(ShapesAreaCalculator.Calculate(1, 1.3, 1.3,  "triangle", "yes")));
            Assert.That(expectedResultCaseThree, Is.EqualTo(ShapesAreaCalculator.Calculate(-5, -5, 8, "triangle", "yes")));
            Assert.That(expectedResultCaseFour, Is.EqualTo(ShapesAreaCalculator.Calculate(1, 4, 6, "triangle", "yes")));
            Assert.That(expectedResultCaseFive, Is.EqualTo(ShapesAreaCalculator.Calculate(3, 4, 5, "circle", "yes")));
            Assert.That(expectedResultCaseSix, Is.EqualTo(ShapesAreaCalculator.Calculate(3, 4, 5, "triangle", "xd")));
        }
    }
}