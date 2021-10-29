/*
 * Author: Jason Carnahan
 * 2D vector supported for doubles.
 */


using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("LokiTests")]
class Vector2D
{
    public double X { get; set; }
    public double Y { get; set; }

    /// <summary>
    /// Creates a zero vector.
    /// </summary>
    public Vector2D()
    { X = 0; Y = 0; }

    /// <summary>
    /// Creates a vector with the given x/y values.
    /// </summary>
    /// <param name="x">X-value</param>
    /// <param name="y">Y-value</param>
    public Vector2D(double x, double y)
    { X = x; Y = y; }

    // ----------------Overloaded Operators-------------------------
    public static Vector2D operator +(Vector2D lhs, Vector2D rhs)
    { return new Vector2D(lhs.X + rhs.X, lhs.Y + rhs.Y); }

    public static Vector2D operator -(Vector2D lhs, Vector2D rhs)
    { return new Vector2D(lhs.X - rhs.X, lhs.Y - rhs.Y); }

    public static Vector2D operator *(Vector2D lhs, Vector2D rhs)
    { return new Vector2D(lhs.X * rhs.X, lhs.Y * rhs.Y); }

    public static Vector2D operator /(Vector2D lhs, Vector2D rhs)
    { return new Vector2D(lhs.X / rhs.X, lhs.Y / rhs.Y); }

    public static bool operator ==(Vector2D lhs, Vector2D rhs)
    { return rhs.X == lhs.X && rhs.Y == lhs.Y; }

    public static bool operator !=(Vector2D lhs, Vector2D rhs)
    { return rhs.X != lhs.X || rhs.Y != lhs.Y; }
    // ----------------Overloaded Operators - End ------------------

    /// <summary>
    /// Turns this vector into a zero vector.
    /// </summary>
    public void Zero()
    { X = 0; Y = 0; }

    /// <summary>
    /// Checks if this vector is a (or close to a) zero vector. 
    /// </summary>
    /// <returns></returns>
    public bool IsZero()
    { return X * X + Y * Y <= double.Epsilon; }

    /// <summary>
    /// Returns the length of the vector.
    /// </summary>
    /// <returns></returns>
    public double Length()
    { return Math.Sqrt(X * X + Y * Y); }

    /// <summary>
    /// Returns the length squared of the vector to save computation power.
    /// </summary>
    /// <returns></returns>
    public double LengthSq() 
    { return (X * X + Y * Y); }

    /// <summary>
    /// Returns the dot product of vectors.
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
    public double Dot(Vector2D v) 
    { return (X * v.X + Y * v.Y); }

    /// <summary>
    /// Returns a new vector that is +90 degrees (perpendicular) to this vector.
    /// </summary>
    /// <returns></returns>
    public Vector2D GetPerp() 
    { return new Vector2D(-Y, X); }

    /// <summary>
    /// Returns the distance between this vector and the input vector.
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
    public double Distance(Vector2D v)
    {
        double deltaY = v.Y - Y;
        double deltaX = v.X - X;
        return Math.Sqrt(deltaY * deltaY + deltaX * deltaX);
    }

    /// <summary>
    /// Returns the distance squared between this vector and the input vector.
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
    public double DistanceSq(Vector2D v)
    {
        double deltaY = v.Y - Y;
        double deltaX = v.X - X;
        return deltaY * deltaY + deltaX * deltaX;
    }

    /// <summary>
    /// Normalizes this vector.
    /// </summary>
    public void Normalize()
    {
        double length = this.Length();
        X /= length;
        Y /= length;
    }

    /// <summary>
    /// Truncates the vector so that its length does not exceed the input value.
    /// </summary>
    /// <param name="max"></param>
    public void Truncate(double max)
    {
        if (this.Length() > max)
        {
            this.Normalize();
            X *= max;
            Y *= max;
        }
    }

    /// <summary>
    /// Returns a vector that is opposite this vector.
    /// </summary>
    /// <returns></returns>
    public Vector2D GetReverse()
    { return new Vector2D(-X, -Y); }

    /// <summary>
    /// Returns a new vector that is a reflection of this vector off the given surface vector.
    /// </summary>
    /// <param name="surface"></param>
    /// <returns></returns>
    public Vector2D GetReflection(Vector2D surface)
    {
        return new Vector2D(
            2 * this.Dot(surface) * surface.GetReverse().X, 
            2 * this.Dot(surface) * surface.GetReverse().Y
            );
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(this, obj))
            return true;
        if (ReferenceEquals(obj, null))
            return false;
        throw new NotImplementedException();
    }

    public override int GetHashCode()
    {
        throw new NotImplementedException();
    }
}

