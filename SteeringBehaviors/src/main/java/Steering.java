public class Steering {

    private Vehicle parentVehicle;

    public Steering(Vehicle parent){
        parentVehicle = parent;
    }

    public Vector2 Seek(Vector2 targetPos) {
        Vector2 desiredVelocity = targetPos.minusEquals(parentVehicle.position).normalize().timesEquals(parentVehicle.maxSpeed);
        return desiredVelocity.minusEquals(parentVehicle.velocity);
    }

    public Vector2 Flee(Vector2 targetPos) {
        Vector2 desiredVelocity = parentVehicle.position.minusEquals(targetPos).normalize().timesEquals(parentVehicle.maxSpeed);
        return desiredVelocity.minusEquals(parentVehicle.velocity);
    }

    public Vector2 calculate() {
        return null;
    }
}
