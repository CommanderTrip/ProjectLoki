public class Vector2 {
    public double x;
    public double y;

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
        return (x*x + y*y) < Double.MIN_VALUE;
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
        return (x * x + y * y);
    }

    /**
     * Normalizes the vector
     */
    public Vector2 normalize() {
        double magnitude = length();
        x = x / magnitude;
        y = y / magnitude;
        return this;
    }

    /**
     * Calculates the dot product between two vectors
     *
     * @param v Some other vector
     * @return the dot product
     */
    public double dot(Vector2 v) {
        return (x * v.x + y * v.y);
    }

    /**
     * Returns positive if v is clockwise of this vector(pointing in a partly same direction),
     * negative if counterclockwise (pointing in an opposite direction).
     * @param v other vector
     * @return sign of direction
     */
    public int sign(Vector2 v) {
        if(y * v.x > x * v.y){
            return -1;
        } else{
            return 1;
        }
    }

    /**
     * Returns a vector perpendicular to this vector.
     * @param v some other vector
     * @return a perpendicular vector
     */
    public Vector2 perp(Vector2 v) {
        return new Vector2(-y, x);
    }

    /**
     * Truncates a vector so its length does not exceed max
     * @param max upper limit
     */
    public void truncate(double max) {
        if(this.length() > max){
            this.normalize();
            this.timesEquals(max);
        }
    }

    /**
     * Calculates the euclidean distance between two vectors
     * @param v some other vector
     * @return distance between the vectors
     */
    public double distance(Vector2 v) {
        double dy = v.y - y;
        double dx = v.x - x;
        return Math.sqrt(dy * dy + dx * dx);
    }

    /**
     * Calculates the euclidean distance between two vectors without the sqrt
     * @param v some other vector
     * @return distance between the vectors
     */
    public double distanceSq(Vector2 v) {
        double dy = v.y - y;
        double dx = v.x - x;
        return (dy * dy + dx * dx);
    }

    /**
     * Calculates a vector reflected over a normal vector (light reflecting off a surface)
     * @param norm a normal vector to reflect our vector over
     */
    public void reflect(Vector2 norm) {
        this.plusEquals(norm.getReverse().timesEquals(this.dot(norm)).timesEquals(2));
    }

    /**
     * Calculates a vector reverse of this vector.
     * @return a vector with -x, -y
     */
    public Vector2 getReverse() {
        return new Vector2(-x, -y);
    }

    // Operators
    public Vector2 plusEquals(Vector2 v) {
        x += v.x;
        y += v.y;
        return this;
    }

    public Vector2 minusEquals(Vector2 v) {
        x -= v.x;
        y -= v.y;
        return this;
    }

    public Vector2 timesEquals(double val) {
        x *= val;
        y *= val;
        return this;
    }

    public Vector2 divideEquals(double val) {
        x /= val;
        y /= val;
        return this;
    }

    public boolean equals(Vector2 v) {
        return (x == v.x && y == v.y);
    }

    public boolean notEquals(Vector2 v) {
        return (x != v.x || y != v.y);
    }
}
