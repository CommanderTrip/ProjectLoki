public class MovingEntity extends BaseGameEntity{

    MovingEntity(int ID) {
        super(ID);
    }

    protected Vector2 velocity;
    protected Vector2 heading;  // Normalized vectoring where the entity is heading
    protected Vector2 side; // Vector perpendicular to the heading vector
    protected double mass;
    protected double maxSpeed;
    protected double maxForce;
    protected double maxTurnRate;

    public Vector2 getVelocity() {
        return velocity;
    }

    public void setVelocity(Vector2 velocity) {
        this.velocity = velocity;
    }

    public Vector2 getHeading() {
        return heading;
    }

    public void setHeading(Vector2 heading) {
        this.heading = heading;
    }

    public Vector2 getSide() {
        return side;
    }

    public void setSide(Vector2 side) {
        this.side = side;
    }

    public double getMass() {
        return mass;
    }

    public void setMass(double mass) {
        this.mass = mass;
    }

    public double getMaxSpeed() {
        return maxSpeed;
    }

    public void setMaxSpeed(double maxSpeed) {
        this.maxSpeed = maxSpeed;
    }

    public double getMaxForce() {
        return maxForce;
    }

    public void setMaxForce(double maxForce) {
        this.maxForce = maxForce;
    }

    public double getMaxTurnRate() {
        return maxTurnRate;
    }

    public void setMaxTurnRate(double maxTurnRate) {
        this.maxTurnRate = maxTurnRate;
    }
}
