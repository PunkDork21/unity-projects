using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class healthManager : MonoBehaviour {
	
	public GameObject[] hearts;
	private int health;
	public Rigidbody2D playerBody;
	public Platformer2DUserControl playerControl;

	// Use this for initialization
	void Start () {
		health = hearts.Length;

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Hzrd" && playerControl.movementEnabled) {
			health--;
			knockback (coll.transform.position);
			if (health >= 1) {	
				hearts [health].SetActive (false);
			}
		}

		if (health <= 0) {
			Application.LoadLevel (Application.loadedLevelName);
		}
	}

	void knockback(Vector3 hazardPosition){
		StartCoroutine ("haltMovement");
		Vector3 heading = transform.position - hazardPosition;
		float distance = heading.magnitude;
		Vector3 direction = heading / distance;

		Vector2 directionForVelocity = new Vector2 (direction.x, direction.y);
		playerBody.velocity = directionForVelocity * 15f;
	}

	IEnumerator haltMovement(){
		playerControl.movementEnabled = false;
		yield return new WaitForSeconds(1.0f);
		playerControl.movementEnabled = true;
	}
}
