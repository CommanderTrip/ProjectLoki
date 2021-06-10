public class Vehicle extends MovingEntity{

    private Steering steering;

    Vehicle(int ID) {
        super(ID);
        steering = new Steering(this);

    }



    @Override
    public void update(double time_elapsed){
        Vector2 steeringForce = steering.calculate(); // Calculate the force from the steering
        Vector2 acceleration = steeringForce.divideEquals(super.mass);  // F = ma
        super.velocity.plusEquals(acceleration.timesEquals(time_elapsed));  // v1 = a * t + v0

    }

}
