using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Euclid
{
    public class Segment
    {
        public Point A;
        public Point B;

        public Segment(Point a, Point b)
        {
            A = a;
            B = b;
        }
        public double Length =>
            Math.Sqrt((A.X - B.X) * (A.X - B.X) + 
                (A.Y - B.Y) * (A.Y - B.Y));

        public bool IsContain(Point p) =>
            Math.Abs((p.X - A.X) * (B.Y - p.Y) -
                (p.Y - A.X) * (B.X - p.X)) < geometry.EPSILON && (p.X - A.X) * (B.X - p.X) +
            (p.Y - A.Y) * (B.Y - p.Y) > geometry.EPSILON; 

            }
        }
   
