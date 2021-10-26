using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loki.AutonomousMovingAgents
{
    class Vector2D
    {
        public double x { get; set; }
        public double y { get; set; }

        public Vector2D()
        {
            x = 0; y = 0;
        }

        public Vector2D(double x, double y)
        {
            this.x = x; this.y = y;
        }

        // Sets X and Y to be zero
        public void Zero()
        {
            x = 0; y = 0;
        }

        // Returns true if both X and Y are zero
        public bool isZero()
        {
            return (x * x + y * y) < double.MinValue;
        }


        // Returns the length of the vector
        public double length()
        {
            return Math.Sqrt(x * x + y * y);
        }

        // Returns the length of the vector squared
        public double lengthSq()
        {
            return (x * x + y * y);
        } 

        // Returns the dot product of two vectors
        public double dot(Vector2D v2)
        {
            return x * v2.x + y * v2.y;
        }

        // Returns sign of the vector
        // positive if v2 is clockwise this vector
        // negative if v2 is anticlockwise (Y pointing down and X pointing right)
        // Clockwise is determined by the rotation of the unit circle???
        public int sign(Vector2D v2)
        {
            return y * v2.x > x * v2.y ? 1 : -1;
        }

        // Returns a vector perpendicular to this vector (+90 deg)
        public Vector2D perp()
        {
            return new Vector2D(-y, x);
        }

        // Calculates the distance between this vector and another
        public double distanceTo(Vector2D v2)
        {
            double yDistance = v2.y - y;
            double xDistance = v2.x - x;
            return Math.Sqrt(xDistance * xDistance + yDistance * yDistance);
        }

        // Calculates the distance squared between this vector and another
        public double distanceToSq(Vector2D v2)
        {
            double yDistance = v2.y - y;
            double xDistance = v2.x - x;
            return xDistance * xDistance + yDistance * yDistance;
        }

        // Normalizes this vector 
        public void normalize()
        {
            if (this.length() > double.Epsilon)
            {
                x /= this.length();
                y /= this.length();
            }
        }

        // Multiplies this vector by val
        public void times(double val)
        {
            x *= val;
            y *= val;
        }


        // Adds a vector to this vector
        public void add(Vector2D v2)
        {
            x += v2.x;
            y += v2.y;
        }

        // Truncates a vector so that its length does not exceed max
        public void truncate(double max)
        {
            if (this.length() > max)
            {
                this.normalize();
                this.times(max);
            }
        }

        // Returns a vector that is reverse of this vector
        public Vector2D getReverse()
        {
            return new Vector2D(-x, -y);
        }

        // Given a normalized vector this method reflects the vector 
        // Like a light bouncing off a surface
        public void reflect(Vector2D norm)
        {
            Vector2D reflectedVector = norm.getReverse();
            reflectedVector.times(2 * this.dot(norm));
            this.add(reflectedVector);
        }

    }
}
