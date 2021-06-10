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

}
