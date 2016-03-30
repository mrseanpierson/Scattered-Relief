using UnityEngine;
using System.Collections;

public class MotionZombie : MonoBehaviour {
	
	//public GameObject zombie;
	//private Rigidbody rbZ;
	//private Transform thisZombie;
	private Vector3 direction;
	private float speed;
	public GameObject target;
	private Vector3 targetPosition;
	private Animator anim;
	private BoxCollider bc;
	private AudioSource source;
	private bool played;
	//public Rigidbody rbZ;
	// Use this for initialization
	void Start () {
		played = false;
		//thisZombie = GetComponent<Transform> ();
		speed = .55f;
		anim = GetComponent<Animator> ();
		bc = GetComponent<BoxCollider> ();
		bc.isTrigger = true;
		bc.enabled = false;
		source = GetComponent<AudioSource> ();
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
		
				Application.LoadLevel("Test");

		}
	}
	// Update is called once per frame
	void FixedUpdate () {

		if (Vector3.Distance (transform.position, target.transform.position) > 3) {
			transform.LookAt (new Vector3 (target.transform.position.x, 3f, target.transform.position.z));

		}

		if (Vector3.Distance (transform.position, target.transform.position) <= 3.5
		    && Vector3.Distance (transform.position, target.transform.position) > 1) {
			//bc.enabled = true;
			anim.speed = 1;
			//transform.position += transform.forward * speed * Time.deltaTime;
			anim.Play ("attack");

			bc.enabled = true;

		}

		if (Vector3.Distance (transform.position, target.transform.position) > 3.5) {
			if (Vector3.Distance (transform.position, target.transform.position) < 30) {
				bc.enabled = false;
				if(!source.isPlaying  && !played){
					source.Play ();
					played = true;
				}
				anim.speed = 4;
				speed = 2.2f;			
			}
			if (Vector3.Distance (transform.position, target.transform.position) > 30) {
				played = false;
				bc.enabled = false;
				anim.speed = 1;
				speed = .55f;			
			}
			anim.Play ("walk");
			transform.position += transform.forward * speed * Time.deltaTime;

		}

	}
}