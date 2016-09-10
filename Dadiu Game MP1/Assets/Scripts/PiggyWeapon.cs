using UnityEngine;
using System.Collections;

public class PiggyWeapon : MonoBehaviour {
	public int lightDamage = 100;

	void Weapon (MonsterHealth monsterHealth){
		if (monsterHealth != null)
			monsterHealth.TakeDamage (lightDamage);
	}

	//monster dies when hit by the light
	void OnTriggerEnter (Collider hittingCollider){
		if(hittingCollider.tag == "Monster"){
			//Weapon (hittingCollider.GetComponent<MonsterHealth> ());
		}
	}
}
