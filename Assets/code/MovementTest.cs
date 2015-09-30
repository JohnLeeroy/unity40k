public class MovementTest {

	void TestMovement(){
		BaseUnit spaceMarine = new BaseUnit();
		//spaceMarine.setMovementType(MovementType.NORMAL);
		MovementPath movementPath = new MovementPath();
		//TODO: mock movementPath
		MovementEngine.getInstance().move(spaceMarine, movementPath);
	}
}