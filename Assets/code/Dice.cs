using UnityEngine;

public class Dice{
	
	private Dice() { } //cant instantiate! 
	
	public static int[] roll(int count){
		int[] result = new int[count];
		for(int i = 0; i < count; i++){
			result[i] = Random.Range(1, 6);
		}
		return result;
	}
}