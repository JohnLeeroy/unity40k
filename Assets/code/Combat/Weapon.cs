public interface Weapon{
	int getRange();
	int getStrength();
	int getArmorPierce();
	int getShots();
	WeaponType getWeaponType();
}

public enum WeaponType{RAPID_FIRE, ASSAULT, HEAVY };