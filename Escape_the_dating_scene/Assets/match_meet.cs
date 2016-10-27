using UnityEngine;
using System.Collections;

public class match_meet : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}


	void OnCollisionEnter(Collision col) {

		if (col.collider.name == "RigidBodyFPSController") {
			Destroy(gameObject);
		}
////		Destroy(gameObject);
//
//		print("Detected collision between " + gameObject.name + " and " + collisionInfo.collider.name);

	}

	// Update is called once per frame
	void Update () {
	}
}
