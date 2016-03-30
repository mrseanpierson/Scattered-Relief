using UnityEngine;
using System.Collections;

public class PickupNote : MonoBehaviour {
	
	//Maximum Distance you Can Pick Up A Book
	public float maxDistance = 1.5F;
	
	//Your Custom GUI Skin with the Margins, Padding, Align, And Texture all up to you :)
	public GUISkin skin;

	public Texture2D myTex;
	//Are we currently reading a note?
	private bool readingNote = false;
	private bool hasBeenRead;
	//The text of the note we last read
	private string noteText = 
		" There isnt much ammo to defend yourself. \n" +
		"Bring the items back to the boat.\n " +
		"'e' to interact.\n" +
		"'q' to switch\n" +
		"Escape...\n";
	
	
	void Start () {
		hasBeenRead = false;
		//Start the input check loop
//SS		StartCoroutine ( CheckForInput () );
		
	}

	void OnTriggerEnter(Collider other){
		print (other.name);
		print (this.name);
		if (other.name == "Note") {
			//hasBeenRead = true;
			readingNote = true;

		}


	}

	void OnTriggerExit(Collider other){
		if (other.name == "Note") {
			readingNote = false;
			hasBeenRead = true;

		}
	}

	void OnGUI () {
		
		if (skin)
			GUI.skin = skin;
		
		//Are we reading a note? If so draw it.
		if (readingNote && !hasBeenRead) {
			
			//Draw the note on screen, Set And Change the GUI Style To Make the Text Appear The Way you Like (Even on an image background like paper)
			GUI.skin.box.normal.background = myTex;
			GUI.Box (new Rect (Screen.width / 4F, Screen.height / 16F, Screen.width / 2F, Screen.height * 0.9F), noteText);
		
		}
		
	}
	
}
