using UnityEngine;
using System.Collections;

public class endGameTrigger : MonoBehaviour {
	public int levelNum;
	public bool finalLevel;
	public GameObject playAgainButton;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){
			if (finalLevel) {
				playAgainButton.SetActive (true);
			} else {
			Application.LoadLevel ("Level" + levelNum);
			}
		}

	}
	public void restartGame(){
		Application.LoadLevel ("Level1");
	}
}