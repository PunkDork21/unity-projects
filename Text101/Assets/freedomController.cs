using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class freedomController : MonoBehaviour {
	private Image freedom;
	// Use this for initialization
	void Start () {
		freedom.enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.F)) {
			freedom.enabled = true;
		}
	}
}
