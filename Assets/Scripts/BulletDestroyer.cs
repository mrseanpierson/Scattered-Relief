using UnityEngine;
using System.Collections;

public class BulletDestroyer : MonoBehaviour {
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){

		Destroy (this.gameObject);
		print ("I, a mighty bullet, have fallen." +
			" I will join the  others " +
			"that have gone before me.");

	}
}
