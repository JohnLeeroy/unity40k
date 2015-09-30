public class BaseUnit : Attribute {
	protected int weaponSkill;	
	protected int ballisticSkill;	
	protected int strength;	
	protected int toughness;	
	protected int initiative;	
	protected int attack;	
	protected int leadership;	
	protected int savingThrow;

	protected int movementType;

	public int getWeaponSkill() { return weaponSkill; }
	public int getBallisticSkills() {return ballisticSkill; }
	public int getStrength() { return strength; }
	public int getToughness() { return toughness; }
	public int getInitiative() { return initiative; }
	public int getAttack() { return attack; }
	public int getLeadership() {return leadership; }
	public int getSavingThrow() {return savingThrow; }

	public int getMovementType() { return movementType; }

	bool hasMoved;
}
