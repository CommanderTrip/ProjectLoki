public class Vector2 {
    private double x;
    private double y;

    public Vector2() {
        x = 0;
        y = 0;
    }

    public Vector2(double a, double b) {
        x = a;
        y = b;
    }

    /**
     * Sets x and y of the vector to zero
     */
    public void zero() {
        x = 0;
        y = 0;
    }

    /**
     * Checks if a vector is a zero vector
     *
     * @return true if x and y are zero
     */
    public boolean isZero() {
        return this.x == 0 && this.y == 0;
    }

    /**
     * Calculates the length of the vector
     *
     * @return the length of the vector
     */
    public double length() {
        return Math.sqrt(x * x + y * y);
    }

    /**
     * Calculates the squared length of the vector (avoiding slow sqrts)
     *
     * @return Length of the vector squared
     */
    public double lengthSq() {
        return x * x + y * y;
    }

    /**
     * Normalizes the vector
     */
    public void normalize() {
        double magnitude = length();
        x = x / magnitude;
        y = y / magnitude;
    }

    /**
     * Calculates the dot product between two vectors
     *
     * @param v Some other vector
     * @return the dot product
     */
    public double dot(Vector2 v) {
        return x * v.getX() + y * v.getY();
    }

    // Still figuring out these functions
    public int sign(Vector2 v) {
        return -93210;
    }

    public Vector2 perp(Vector2 v) {
        return null;
    }

    public void truncate(double max) {
    }

    public double distance(Vector2 v) {
        return -93210;
    }

    public double distanceSq(Vector2 v) {
        return -93210;
    }

    public Vector2 getReverse() {
        return new Vector2(-x, -y);
    }

    // Operators
    public Vector2 opPE(Vector2 v) {
        return new Vector2(x + v.getX(), y + v.getY());
    }

    public Vector2 opME(Vector2 v) {
        return new Vector2(x - v.getX(), y - v.getY());
    }

    public Vector2 opTE(double vMag) {
        return new Vector2(x * vMag, y * vMag);
    }

    public Vector2 opDE(double vMag) {
        return new Vector2(x / vMag, y / vMag);
    }


    public double getX() {
        return x;
    }

    public void setX(double a) {
        x = a;
    }

    public double getY() {
        return y;
    }

    public void setY(double b) {
        y = b;
    }

}
