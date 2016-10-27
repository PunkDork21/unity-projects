using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;
	private enum States{cell, 
						sheets_0, 
						mirror, 
						mirror_1,  
						sheets_1, 
						cell_mirror,
						lock_0, 
						lock_1, 
						lock_2, 
						corridor_0, 
						free, 
						idiot,
						corridor_1,
						corridor_2,
						corridor_3,
						stairs_0,
						stairs_1,
						stairs_3,
						floor,
						floor_1,
						closet_door,
						inside_closet,
						inside_closet_1,
						courtyard,
						place_to,
						dead};
	private States myState; 

	// Use this for initialization
	void Start () {
		myState = States.cell;
	}
	
	// Update is called once per frame
	void Update ()
	{
		print (myState);
		if 		(myState == States.cell) 			{cell ();} 
		else if (myState == States.sheets_0) 		{sheets_0 ();} 
		else if (myState == States.sheets_1) 		{sheets_1 ();} 
		else if (myState == States.lock_0) 			{lock_0 ();} 
		else if (myState == States.lock_1) 			{lock_1 ();}
		else if (myState == States.lock_2) 			{lock_2 ();}
		else if (myState == States.mirror) 			{mirror ();} 
		else if (myState == States.mirror_1) 		{mirror_1 ();} 
		else if (myState == States.cell_mirror) 	{cell_mirror ();}
		else if (myState == States.dead)			{dead();}
		else if (myState == States.corridor_0)		{corridor_0();}
		else if (myState == States.corridor_1)		{corridor_1();}
		else if (myState == States.corridor_2)		{corridor_2();}
		else if (myState == States.corridor_3)		{corridor_3();}
		else if (myState == States.stairs_0)		{stairs_0();}
		else if (myState == States.stairs_1)		{stairs_1();}
		else if (myState == States.floor)			{floor();}
		else if (myState == States.floor_1)			{floor_1();}
		else if (myState == States.closet_door)		{closet_door();}
		else if (myState == States.inside_closet)	{inside_closet();}
		else if (myState == States.inside_closet_1)	{inside_closet_1();}
		else if (myState == States.place_to)		{place_to();}
		else if (myState == States.courtyard)		{courtyard();}

	}
	void stairs_0 ()
	{
		text.text = "You make your way towards the stairs\n" +
		"Realizing that no one is on break, and this is\n" +
		"a terrible idea, you retreat back to the corridor\n\n" +
		"Press R to return to the corridor";
		if (Input.GetKeyDown (KeyCode.R)) {myState = States.corridor_0;}
	}
	void stairs_1 ()
	{
		text.text = "You run up the stairs in the hurry\n"+
					"turn the corner and you meet eyes with a prison guard\n"+
					"They KNOCK you over the head\n"+
					"Press C to continue";
		if(Input.GetKeyDown(KeyCode.C)) {myState = States.dead;}

	}
	void courtyard ()
	{
		text.text = "You head up the stairs and out into the courtyard\n"+
					"past the gate into freedom, press R to return to the closet";
		if(Input.GetKeyDown(KeyCode.R)) {myState = States.dead;}
	}

	void cell (){
		text.text = "You are in a prison cell. \n The room is dark and damp.\n\n"+
					"There are dirty sheets on the bed, a mirror on the wall, the door is locked from outside.\n"+
					"Press S for sheets, M for mirror, or L to view lock lock";
		if (Input.GetKeyDown (KeyCode.S)) {myState = States.sheets_0;}
		else if (Input.GetKeyDown (KeyCode.M)) {myState = States.mirror;}
		else if (Input.GetKeyDown (KeyCode.L)) {myState = States.lock_0;}
	}
	void cell_mirror (){
		text.text = "You're still in a prison cell. The room is dark and damp.\n" +
					"There are dirty sheets on the bed, the mirror is no longer on the wall,\n" +
					"the door is still locked from outside.\n\n" +
					"Press S for sheets, M for mirror, or L to view lock lock";
		if (Input.GetKeyDown (KeyCode.S)) 	   {myState = States.sheets_1;}
		else if (Input.GetKeyDown (KeyCode.M)) {myState = States.mirror_1;}
		else if (Input.GetKeyDown (KeyCode.L)) {myState = States.lock_1;}
	}
	void sheets_0 ()
	{
		text.text = "The sheets have the scent of a motel 6 that skimped on maid service.\n" +
					"Enough grime to believe these were rags reborn blankets\n\n" +
					"Press R to return";
		if (Input.GetKeyDown (KeyCode.R)) {myState = States.cell;}
	}
	void sheets_1 ()
	{
		text.text = "The mirror doesn't make the sheets \n" +
					"look any better.\n\n" +
					"Press R to return";
		if (Input.GetKeyDown (KeyCode.R)) {myState = States.cell_mirror;}
	}

	void place_to ()
	{
		text.text = "'I have a place to put you' the guard replies\n"+
					"Press C\n";
		if(Input.GetKeyDown(KeyCode.C)){myState = States.dead;}
	}
	void mirror ()
	{
		text.text = "The mirror seems to be loose\n\n" +
					"Press T to take the mirror or Press R to return";
		if (Input.GetKeyDown (KeyCode.R)) 	 {myState = States.cell;}
		else if (Input.GetKeyDown(KeyCode.T)){myState = States.cell_mirror;}
	}
	void mirror_1 ()
	{
		text.text = "You have the mirror. It's not on the wall\n" +
					"But there is blood on the wall\n\n" +
					"Press R to return";
		if (Input.GetKeyDown (KeyCode.R)) {myState = States.cell_mirror;}
	}
	void lock_0 ()
	{
		text.text = "It's a button lock, incredibly eroded on this side.\n" +
					"You have no idea what the combination is.\n If only you could see the dirty fingerprints on the other side\n\n" +
					"Press R to return";
		if (Input.GetKeyDown (KeyCode.R)) {myState = States.cell;}
	}
	void lock_1 ()
	{
		text.text = "You slip the mirror between the bars and turn it towards the lock\n" +
					"You can make out the combination from the smudges. \nYou put it in and hear a click.\n\n" +
					"Press O to open or R to return";
		if (Input.GetKeyDown (KeyCode.O)) {myState = States.corridor_0;}
		else if (Input.GetKeyDown (KeyCode.R)) {myState = States.cell_mirror;}
	}
	void lock_2 ()
	{
		text.text = "You crack the door open. No one is around\n" +
					"Nows your chance.\n" +
					"Press C to enter the corridor or R to return to your cell";
		if (Input.GetKeyDown (KeyCode.C)) {myState = States.corridor_0;}
		else if (Input.GetKeyDown (KeyCode.R)) {myState = States.cell_mirror;}
	}
	void floor ()
	{
		text.text = "Oh shit a hairclip!\n"+
					"Prison guards must be prime on fashion.\n"+
					"Press R to return to corridor or P to pick it up you diva";
		if (Input.GetKeyDown(KeyCode.R)) {myState = States.corridor_0;}
		else if(Input.GetKeyDown(KeyCode.P)) {myState = States.corridor_1;}
	}
	void floor_1 ()
	{
		text.text = "Yeah, the floors wet\n"+
					"Press R to return to corridor";
		if(Input.GetKeyDown(KeyCode.R)) {myState = States.corridor_1;}
	}

	void closet_door ()
	{
		text.text = "The closet is locked\n"+
					"Well.. thats not out of character..\n"+
					"Press R to return";
		if(Input.GetKeyDown(KeyCode.R)) {myState = States.corridor_0;}
	}

	void inside_closet ()
	{
		text.text = "You pick the closet door open\n"+
					"Theres a janitor uniform in here\n\n"+
					"..It smells terrible...\n"+
					"Press R to return to corridor";
		if(Input.GetKeyDown(KeyCode.R)) {myState = States.corridor_2;}
	}

	void inside_closet_1 ()
	{
		text.text = "Back into the closet.\n"+
					"You hear footsteps and chatter storm by you and stop in front of the closet\n"+
					"Press P to put on the janitor outfit";
		if(Input.GetKeyDown(KeyCode.P)){myState = States.corridor_3;}
	}

			
	void corridor_0 ()
	{
		text.text = "Well.. the hall is not that much brighter\n" +
					"Down the hall is a series of stairs, the floor is wet, theres a locked closet to your left\n" +
					"Press S to check the stairs, F to look at the floor or C to check the closet";
		if (Input.GetKeyDown (KeyCode.C)) {myState = States.closet_door;}
		else if(Input.GetKeyDown(KeyCode.S)) {myState = States.stairs_0;}
		else if(Input.GetKeyDown(KeyCode.F)) {myState = States.floor;}
	}

	void corridor_1 ()
	{
		text.text = "Back into the corridor\n"+
					"Down the hall are still the stairs, floors wetter than normal\n"+
					"there is a locked closet to your left\n"+
					"Press S to go to the stairs, F to look at the floor, or C to check the closet";
		if (Input.GetKeyDown(KeyCode.F)){myState = States.floor_1;}
		else if (Input.GetKeyDown(KeyCode.S)){myState = States.stairs_1;}
		else if (Input.GetKeyDown(KeyCode.C)){myState = States.inside_closet;}
	}

	void corridor_2 ()
	{
		text.text = "You are back in the corridor\n"+
					"You can hear people coming down the hallway\n"+
					"Press R to return to the closet or S to head to the stairs";
		if(Input.GetKeyDown(KeyCode.R)) {myState = States.inside_closet_1;}
		else if (Input.GetKeyDown(KeyCode.S)) {myState = States.stairs_1;}
	}

	void corridor_3 ()
	{
		text.text = "You come out of the closet in uniform\n"+
					"The two guards stop talking and look at you\n"+
					"Press P to reply 'I only have one place to change, Im headed to the stairs'\n"+
					"or press S to reply 'Im not sure how I ended up there'";
		if(Input.GetKeyDown(KeyCode.S)) {myState = States.place_to;}
		if(Input.GetKeyDown(KeyCode.P)) {myState = States.courtyard;}
	}


	void dead()
	{
		text.text = "You are back in the cell.\n"+
					"There are no blankets.\n"+
					"There is no mirror.\n\n"+
					"Boy you really f***ed up\n"+
					"Press R to retry";
		if(Input.GetKeyDown(KeyCode.R)) {myState = States.cell;}
	}
}