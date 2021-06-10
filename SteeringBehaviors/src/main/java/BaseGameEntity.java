/**
 * All entities derive from the base class
 */
public class BaseGameEntity {

    private int ID; // Every entity has a unique ID
    private static Integer nextID;  // The next unique ID, this is incremented each time a new entity is instantiated.
    protected Vector2 position;

    BaseGameEntity(int ID) {
        try{
            setID(ID);
        } catch (EntityIDException e) {
            e.printStackTrace();
        }
        position = new Vector2();
    }

    private void setID(int val) throws EntityIDException {
        if (nextID != null){
            if (val >= nextID){
                ID = val;
                nextID++;
            } else {
                throw new EntityIDException();
            }
        } else {
            nextID = 0;
        }
    }

    public int getID() {
        return ID;
    }

    public void update(double time_elapsed){

    }
}
