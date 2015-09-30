public class MovementEngine {

	private MovementEngine() { }
	private static MovementEngine instance;
	public static MovementEngine getInstance(){
		if(instance == null)
			instance = new MovementEngine();
		return instance;
	}

	public void move(BaseUnit unit, MovementPath movementPath){
		//Move unit
	}
}