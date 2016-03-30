using UnityEngine;
using System.Collections;

public class HasItemChecker : MonoBehaviour {
	public GameManager gameManager;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.name == "Plank") {
			gameManager.hasPlank = true;
		}
		if (other.name == "Oar") {
			gameManager.hasOar = true;
		}
		if (other.name == "Tools") {
			gameManager.hasTools = true;
		}
	}
	void OnTriggerExit(Collider other) {
		if (other.name == "Plank") {
			gameManager.hasPlank = false;
		}
		if (other.name == "Oar") {
			gameManager.hasOar = false;
		}
		if (other.name == "Tools") {
			gameManager.hasTools = false;
		}
	}
}
