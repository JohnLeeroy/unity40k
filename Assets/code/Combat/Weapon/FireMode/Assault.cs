using UnityEngine;
using System.Collections;

public class Assault : FireMode {
	public bool requireLineOfSight() {
		return false;
	}

	public bool canMoveAndFire() {
		return true;
	}
}
