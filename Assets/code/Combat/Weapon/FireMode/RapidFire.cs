using UnityEngine;
using System.Collections;

public class RapidFire : FireMode {
	public bool requireLineOfSight() {
		return true;
	}
	
	public bool canMoveAndFire() {
		return true;
	}
}
