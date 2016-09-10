using UnityEngine;
using System.Collections;

public class MonsterManager : MonoBehaviour {

	public Transform piggy;
	public static int monstersAlive = 0;
	private int maxMonstersAlive = 4;

	public GameObject[] monsterType;
	public float spawnTime = 3f;
	public Transform[] spawnPoints;

	void Start () {
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}
	
	private void Spawn(){
		if (monstersAlive < maxMonstersAlive) {
			int spawnPointIndex = Random.Range (0, spawnPoints.Length);
			GameObject spawned = (GameObject)Instantiate (monsterType[spawnPointIndex],
				                     spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
			spawned.GetComponent<MonsterMovement> ().target = piggy;
			monstersAlive += 1;
		}
	}
}
