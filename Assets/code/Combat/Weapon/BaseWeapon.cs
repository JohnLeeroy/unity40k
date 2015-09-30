public class BaseWeapon : Weapon{

	public BaseWeapon(string json){
		//map properties to json 
	}

	private int range;
	private int strength;
	private int armorPierce;
	private int shots;
	private FireMode fireMode;

	public int getRange()	{ return range; }
	public int getStrength() { return strength; }
	public int getArmorPierce() {return armorPierce; }
	public int getShots()	{ return shots; }
	public FireMode getFireMode() { return fireMode; }
}
