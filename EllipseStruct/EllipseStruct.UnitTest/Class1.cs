using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using EllipseStruct;

namespace EllipseStruct.UnitTest
{
    [TestFixture]
    public class EllipseTests
    {
        private const double Tolerance = 1e-13;

        [Test]
        public void Constructor_ValidInput_PropertiesSet()
        {
            var e = new Ellipse(6.2, 3.21);
            Assert.That(e.A, Is.EqualTo(6.2));
            Assert.That(e.B, Is.EqualTo(3.21));
        }

        [TestCase(0, 2)]
        [TestCase(2, 0)]
        [TestCase(-2, 1)]
        [TestCase(1, -1)]
        public void Constructor_InvalidSemiAxes_ThrowsArgumentException(double a, double b)
        {
            Assert.That(() => new Ellipse(a, b), Throws.ArgumentException);
        }

        [TestCase(5, 3, ExpectedResult = Math.PI * 15)]
        [TestCase(3.5, 2.0, ExpectedResult = Math.PI * 7.0)]
        public double AreaTest(double a, double b)
        {
            var e = new Ellipse(a, b);
            return e.Area;
        }

        [TestCase(5, 3)]
        [TestCase(3, 5)]
        [TestCase(7.4, 7.4)]
        public void EccentricityTest(double a, double b)
        {
            var e = new Ellipse(a, b);
            double expected = a >= b
                ? Math.Sqrt(1 - (b * b) / (a * a))
                : Math.Sqrt(1 - (a * a) / (b * b));
            Assert.That(e.Eccentricity, Is.EqualTo(expected).Within(Tolerance));
        }

        [Test]
        public void ToString_ReturnsExpectedString()
        {
            var e = new Ellipse(6.2, 3.21);
            var str = e.ToString();
            Assert.That(str, Is.EqualTo("Эллипс с полуосями a = 6,2 и b = 3,21"));
        }

        [Test]
        public void Equals_SameValues_ReturnsTrue()
        {
            var e1 = new Ellipse(3, 5);
            var e2 = new Ellipse(3.0, 5.0);
            Assert.That(e1 == e2, Is.True);
        }

        [Test]
        public void Equals_DifferentValues_ReturnsFalse()
        {
            var e1 = new Ellipse(3, 5);
            var e2 = new Ellipse(5, 3);
            Assert.That(e1 != e2, Is.True);
        }

        [Test]
        public void Equals_WrongType_ThrowsException()
        {
            var e = new Ellipse(3, 5);
            object obj = new object();
            Assert.That(() => e.Equals(obj), Throws.ArgumentException);
        }

        [Test]
        public void GetHashCode_SameValues_SameHash()
        {
            var e1 = new Ellipse(3, 5);
            var e2 = new Ellipse(3, 5);
            Assert.That(e1.GetHashCode(), Is.EqualTo(e2.GetHashCode()));
        }

        [Test]
        public void Operator_MultiplyByPositiveNumber_ScalesEllipse()
        {
            var e = new Ellipse(2, 3);
            var result = 2.0 * e;
            Assert.That(result.A, Is.EqualTo(4.0).Within(Tolerance));
            Assert.That(result.B, Is.EqualTo(6.0).Within(Tolerance));
        }

        [Test]
        public void Operator_MultiplyByZeroOrNegative_Throws()
        {
            var e = new Ellipse(2, 3);
            Assert.That(() => 0 * e, Throws.ArgumentException);
            Assert.That(() => (-2.0) * e, Throws.ArgumentException);
        }
    }
}




