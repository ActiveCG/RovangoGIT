using UnityEngine;
using System.Collections;

public class PiggyMovement : MonoBehaviour {
	private int lifes = 3; 

	public float speed = 6f;

	Vector3 movement; //direction of movement
	Rigidbody piggyRB;
	int floorMask; //casting rays only on floor laayer
	float camRayLength = 100f;

	void Awake(){
		floorMask = LayerMask.GetMask ("Floor");
		piggyRB = GetComponent<Rigidbody> ();
	}

	void FixedUpdate(){
		//move and turn piggy towards mouse
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");

		#if UNITY_EDITOR
			Move(h, v);
		  	Turning ();

		#else
		if (Input.GetMouseButtonDown (0)) {
			Ray camRaym = Camera.main.ScreenPointToRay (Input.mousePosition); //cast ray
			RaycastHit floorHitm;

			if (Physics.Raycast (camRaym, out floorHitm, camRayLength, floorMask)) {
				transform.position = new Vector3(floorHitm.point.x, transform.position.y, floorHitm.point.z);
			}
		}
		#endif
			
	}

	private void Move(float h, float v){
		movement.Set (h, 0f, v); //movement vector direction
		movement = Camera.main.transform.TransformDirection(movement);
		movement = movement.normalized * speed * Time.deltaTime; //how much should move
		piggyRB.MovePosition(transform.position + movement); //move to new position
	}

	private void Turning(){
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition); //cast ray
		RaycastHit floorHit;

		if (Physics.Raycast (camRay, out floorHit, camRayLength, floorMask)) { //check for hit
			Vector3 piggyToMouse = -floorHit.point + transform.position;
			piggyToMouse.y = 0f; //make it on floor
			Quaternion newRotation = Quaternion.LookRotation(piggyToMouse);
			piggyRB.MoveRotation (newRotation); //rotate piggy
		}
	}
	
	/*void OnCollisionEnter (Collision col){
		//when hit by an enemy
		if(col.gameObject.tag == "enemy"){
			Debug.Log("Bitten by a sea monster!");
			lifes -= 1;
			if (lifes <= 0) {
				col.gameObject.GetComponent<Enemy> ().followPiggy = false;
				Destroy (gameObject);
				Debug.Log ("Eaten!");
			}
		}
	}*/
}
