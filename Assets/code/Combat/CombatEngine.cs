public class CombatEngine {

	private CombatEngine() { }
	private static CombatEngine instance;
	public static CombatEngine getInstance(){
		if(instance == null)
			instance = new CombatEngine();
		return instance;
	}

	public void shoot(BaseUnit attacker, Weapon weapon, BaseUnit defender){
		if(!isWithinRange(weapon, defender) || !isWithinLineOfSight(attacker, defender))
			return;

		int shots = 1;
		switch(weapon.getWeaponType()){
			case WeaponType.RAPID_FIRE:
				processRapidFire(attacker, weapon, defender);
				break;
			case WeaponType.ASSAULT:
			break;
			case WeaponType.HEAVY:
			break;
			default:
				//do regular
				processCombat(attacker, weapon, defender);
			break;
		}
	}

	private void processRapidFire(BaseUnit attacker, Weapon weapon, BaseUnit defender){
		int shots = 1;
		if(isWithinRapidFireRange(weapon, defender))
			shots = 2;
	}

	private CombatResults processCombat(BaseUnit attacker, Weapon weapon, BaseUnit defender){
		int hitCount = 0;
		int hitDifficulty = getHitDifficulty (attacker.getBallisticSkills());
		int woundDifficulty = getWoundDifficulty(weapon.getStrength(), defender.getToughness());
		bool isSaveable = isSaveableAgainstWeapon(defender, weapon);
		CombatResults result = new CombatResults();

		for(int i = 0; i < weapon.getShots(); i++){
			int hitRoll = Dice.roll(1)[0];
			if(hitRoll >= hitDifficulty) {
				int woundRoll = Dice.roll(1)[0];
				if(woundRoll >= woundDifficulty){
					if(isSaveableAgainstWeapon(defender, weapon))
						result.saveableWounds++;
					else
						result.automaticWounds++;
				}
			}
		}
		return result;
	}

	bool isSaveableAgainstWeapon(BaseUnit defender, Weapon attackingWeapon){
		//Check special rules for saves
		bool hasCoverOrInvunerableSave = false;
		if(hasCoverOrInvunerableSave)
			return true;

		if(attackingWeapon.getArmorPierce() <= defender.getSavingThrow())
			return false;

		return true;
	}

	public int getWoundDifficulty(int attackStrength, int defenseToughness){
		int difference = defenseToughness - attackStrength;
		int result = 4 + difference;
		if(result > 6)
			return 6;
		if(result < 2)
			return 2;
		return result;
	}

	public int getHitDifficulty(int ballisticSkill){
		return 7 - ballisticSkill;
	}

	private bool isWithinRapidFireRange(Weapon weapon, BaseUnit defender){
		return true;
	}

	private bool isWithinRange(Weapon a, BaseUnit b){
		return true;
	}

	private bool isWithinLineOfSight(BaseUnit a, BaseUnit b){
		return true;
	}

	public class CombatResults{
		public int saveableWounds = 0;
		public int automaticWounds = 0;
	}
}

//handle saving throws
//handle leadership rolls

//Special rules 
//categories -> if found apply special rule
//categories ... which phase it affects, which stat it affects