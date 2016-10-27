using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class moneyController : MonoBehaviour {

	public Text money;
	public static int cash;

	// Use this for initialization
	void Start () {
		cash = 900;

	}
	
	// Update is called once per frame
	void Update () {
		money.text = "$" + cash;
	}
	void takeMoney(){

	}
}


	
