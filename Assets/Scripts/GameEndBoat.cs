using UnityEngine;
using System.Collections;

public class GameEndBoat : MonoBehaviour {
	public GameManager gameManager;

	

	void OnTriggerEnter(Collider other){
		if (gameManager.hasOar == true && gameManager.hasPlank == true && gameManager.hasTools == true) {
			gameManager.moving = true;

		}
	}
}
