using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EllipseStruct
{
    public struct Ellipse
    {
        private const double Tolerance = 1e-13;

        public double A { get; }
        public double B { get; }

        public double Eccentricity
        {
            get
            {
                if (A >= B)
                    return Math.Sqrt(1 - (B * B) / (A * A));
                else
                    return Math.Sqrt(1 - (A * A) / (B * B));
            }
        }

        public double Area => Math.PI * A * B;

        public Ellipse(double a, double b)
        {
            if (a <= 0 || b <= 0)
                throw new ArgumentException("Полуоси должны быть положительными");

            A = a;
            B = b;
        }

        public override string ToString() => $"Эллипс с полуосями a = {A} и b = {B}";

        public override bool Equals(object obj)
        {
            if (obj is Ellipse other)
                return Math.Abs(A - other.A) < Tolerance && Math.Abs(B - other.B) < Tolerance;

            throw new ArgumentException("Объект не является эллипсом");
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                const int p = 23;
                hash = hash * p + A.GetHashCode();
                hash = hash * p + B.GetHashCode();
                return hash;
            }
        }

        public static bool operator ==(Ellipse x, Ellipse y) => x.Equals(y);
        public static bool operator !=(Ellipse x, Ellipse y) => !x.Equals(y);

        public static Ellipse operator *(double k, Ellipse e)
        {
            if (k <= 0)
                throw new ArgumentException("Коэффициент должен быть положительным");
            return new Ellipse(k * e.A, k * e.B);
        }

        public static Ellipse operator *(Ellipse e, double k) => k * e;
    }
}

    

