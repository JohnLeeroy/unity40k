using UnityEngine;
using System.Collections;

public interface FireMode {
	bool requireLineOfSight();
	bool canMoveAndFire();
}
