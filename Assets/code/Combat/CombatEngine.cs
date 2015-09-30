public class CombatEngine {

	private CombatEngine() { }
	private static CombatEngine instance;
	public static CombatEngine getInstance(){
		if(instance == null)
			instance = new CombatEngine();
		return instance;
	}

	//Three phases
	//Hits
	//Wounds
	//Saves


	public RangedCombatResult proccess(BaseUnit attacker, Weapon weapon, BaseUnit defender){
		RangedCombatResult result = RangedCombatResult.Empty;
		if(!RangeFinder.isWithinRange(attacker, weapon, defender) || !RangeFinder.hasLineOfSight(attacker, defender))
			return RangedCombatResult.Empty;


		/*
		switch(weapon.getFireMode()){
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
		*/
		return result;
	}

	private void processRapidFire(BaseUnit attacker, Weapon weapon, BaseUnit defender){
		int shots = 1;
		if(RangeFinder.isWithinRapidFireRange(attacker, weapon, defender))
			shots = 2;
	}

	private RangedCombatResult processCombat(BaseUnit attacker, Weapon weapon, BaseUnit defender){
		int hitCount = 0;
		int hitDifficulty = getHitDifficulty (attacker.getBallisticSkills());
		int woundDifficulty = getWoundDifficulty(weapon.getStrength(), defender.getToughness());
		bool isSaveable = isSaveableAgainstWeapon(defender, weapon);
		RangedCombatResult result = new RangedCombatResult();

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

	public bool isSaveableAgainstWeapon(BaseUnit defender, Weapon attackingWeapon){
		//TODO check invunerable save & special rules
		//Check special rules for saves
		bool hasCoverOrInvunerableSave = false;
		if(hasCoverOrInvunerableSave)
			return true;

		if(attackingWeapon.getArmorPierce() <= defender.getSavingThrow())
			return false;

		return true;
	}

	public static int getWoundDifficulty(int attackStrength, int defenseToughness){
		int difference = defenseToughness - attackStrength;
		int result = 4 + difference;
		if(result > 6)
			return 6;
		if(result < 2)
			return 2;
		return result;
	}

	public static int getHitDifficulty(int ballisticSkill){
		return 7 - ballisticSkill;
	}


}

//handle saving throws
//handle leadership rolls

//Special rules 
//categories -> if found apply special rule
//categories ... which phase it affects, which stat it affects