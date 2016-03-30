using UnityEngine;
using System.Collections;

public class Gunshot : MonoBehaviour
{
	//public Rigidbody projectile;
	public float speed = 20;
	private AudioSource source;
	public GameManager gameManager;
	private MeshRenderer mr;
	private MeshCollider mc;
	public GameObject crosshair;
	private Camera cam;
	private Transform target;
	private float shotTime1;
	private float shotTime2;
	private ParticleSystem muzflash;

	void Start(){
		source = GetComponent<AudioSource> ();
		cam = crosshair.GetComponent<Camera> ();
		muzflash = GetComponentInChildren<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (Input.GetButtonDown("Fire1") && gameManager.numBullets > 0 && gameManager.hasGun)
		{	


			target = CheckForImpact();
			muzflash.Play();
			if(target != null){
				if(target.name == "Scary Monster"){
				Destroy(target.gameObject);
				}

			}

			gameManager.numBullets = gameManager.numBullets - 1;
			gameManager.numActiveBullets = gameManager.numActiveBullets + 1;
			//CheckForImpact();
			source.Play();

		}
	}

	private Transform CheckForImpact () {
		
		Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit)) {
			target = hit.transform;
			print ("I Hit: " + hit.transform.name);

			//print (gameManager.numBullets);
			return hit.transform;
		} else {
			return null;
		}
	}


		


}