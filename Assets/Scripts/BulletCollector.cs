using UnityEngine;
using System.Collections;

public class BulletCollector : MonoBehaviour {

	public GameManager gameManager;
	//public AudioClip collected;
	private AudioSource source;
	private float delay = .25f;
	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){

		if (other.tag == "Player") {
			gameManager.numBullets += 1;
			source.Play();

			StartCoroutine(WaitAndDestroy());

			}
	}

	
	IEnumerator WaitAndDestroy(){
		yield return new WaitForSeconds(delay);
		Destroy (this.transform.parent.gameObject);
	}
}
