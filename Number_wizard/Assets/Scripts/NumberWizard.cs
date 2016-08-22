using UnityEngine;
using System.Collections;

public class NumberWizard : MonoBehaviour {

	// Use this for initialization
	void Start () {
		print ("Welcome to Number Wizard");
		print ("Pick a number, any number BUT DON'T TELL ME!");

		int max = 1000;
		int min = 1;

		print ("The highest number you can choose is " + max);
		print ("The lowest number you can choose is " + min);

		print("Is the number higher than or lower than 500?");
		print("Up = higher, down = lower, return = equal");

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			print("That's up mate");
		}
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			print("Dats down mate");
		}
	}
}
