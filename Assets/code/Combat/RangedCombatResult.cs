using UnityEngine;
using System.Collections;

public class RangedCombatResult{
	public int saveableWounds = 0;
	public int automaticWounds = 0;
	
	private static readonly RangedCombatResult empty = new RangedCombatResult();
	public static RangedCombatResult Empty { get { return empty; } }
}