using UnityEngine;
using System.Collections;

public class MonsterMovement : MonoBehaviour {

	public Transform target; //what to follow (piggy)
	private NavMeshAgent nav;
	public bool followPiggy = true;

	void Start () {
		nav = GetComponent<NavMeshAgent> ();
	}

	void Update () {
		if(followPiggy == true)
			nav.SetDestination (target.position); //move towards target
	}

	//dies when hit by the light
	void OnCollisionEnter (Collision col){
		if(col.gameObject.name == "piggyLight"){
			Destroy(gameObject);
			MonsterManager.monstersAlive -= 1;
			Debug.Log ("Sea monster killed");
		}
	}
}
