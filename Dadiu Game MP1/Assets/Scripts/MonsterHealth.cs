using UnityEngine;
using System.Collections;

public class MonsterHealth : MonoBehaviour {
	public int startingHealth = 100;
	public int currentHealth;
	public int scoreValue = 10;

	BoxCollider boxCollider;
	bool isDead;

	void Awake(){
		boxCollider = GetComponent<BoxCollider> ();
		currentHealth = startingHealth; //initial full health
	}

	public void TakeDamage(int amount){
		if (isDead)
			return;
		currentHealth -= amount;
		if (currentHealth <= 0) {
			Death (); //should die
		}
	}

	void Death(){
		isDead = true;
		boxCollider.isTrigger = true;
		GetComponent<NavMeshAgent> ().enabled = false;
		//ScoreManger.score += scoreValue;
		Destroy(gameObject, 1f);
	}
}
