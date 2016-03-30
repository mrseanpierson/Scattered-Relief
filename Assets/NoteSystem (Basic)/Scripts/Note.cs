using UnityEngine;
using System.Collections;

public class Note : MonoBehaviour {
	
	//The Text Of The Note
	public string Text = "Welcome to Scattered Relief." +
		" There isnt much ammo to defend yourself. " +
		"Bring the items back to the boat. " +
		"Get out.";
	public GUISkin skin;
	
	void Start () {
	
		//AutoSet the Name
		//transform.name = "Note";
		
		//If there is no collider on the note add one
		if (GetComponent<Collider>() == null) {
			
			Debug.LogError ("No Collider On Note " + name + ". Add A Collider!");
			
		}
		
	}


}
