using UnityEngine;
using System.Collections;

public class MonsterBites : MonoBehaviour {

	public float timeBetweenBites = 0.5f;
	public int biteDamage = 25;

	GameObject piggy;
	PiggyHealth piggyHealth;
	//MonsterHealth monsterHealth; //later
	bool piggyInRange; //can monster bite?
	float timer; //counting to next bite

	void Awake(){
		piggy = GameObject.FindGameObjectWithTag ("Piggy");
		if(piggy != null)
			piggyHealth = piggy.GetComponent<PiggyHealth> ();
		//monsterHealth = GetComponent<MonsterHealth> ();
	}

	void OnTriggerEnter(Collider hittingCollider){
		if (hittingCollider.gameObject == piggy) { //is it piggy hitting
			piggyInRange = true;
		}
	}

	void OnTriggerExit(Collider exitingCollider){
		if (exitingCollider.gameObject == piggy) { //is it piggy exiting
			piggyInRange = false;
		}
	}

	void Update(){
		timer += Time.deltaTime;
		//if ready to bite again, bite
		if (timer >= timeBetweenBites && piggyInRange/* && monsterHealth.currentHealth > 0*/) {
			Bite ();
		}
	}

	void Bite(){
		timer = 0f;
		if (piggyHealth.currentHealth > 0) {
			piggyHealth.TakeDamage (biteDamage);
		}
	}
}
