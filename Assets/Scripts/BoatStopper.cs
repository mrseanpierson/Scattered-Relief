using UnityEngine;
using System.Collections;

public class BoatStopper : MonoBehaviour {
 	

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			Application.LoadLevel("Test");
		}
	}
}
