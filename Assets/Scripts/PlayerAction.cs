using UnityEngine;
using System.Collections;

public class PlayerAction : MonoBehaviour {

	public Crosshair crosshair;
	public GameManager gameManager;
	public GameObject arms;
	public GameObject thisPlayer;
	public Transform lHandPos;
	public float shotLoadTime;
	public float shotForce;
	public Transform holdL;
	public Transform holdR;

	private GameObject lHand;
	private Rigidbody leftHoldingItem;
	private GameObject flash;
	private GameObject gun;
	private bool carrying;
	private bool hasFlash;
	private bool hasGun;
	private float lastShot;
	private bool hasTools;
	private bool hasOar;
	private bool hasPlank;
	private int prevState;
	private Animator animator;


	void Start () { 
		carrying = false;
		hasGun = false;
		hasFlash = false;
		prevState = 0;
		animator = arms.GetComponent<Animator> ();
	}

	void Update () {
		if (Input.GetKeyUp ("e")) {
			GameObject inspecting = crosshair.lookingAt ();
			if(inspecting != null && inspecting.name == "Flashlight"){
				flash = inspecting;
				if(Vector3.Distance (thisPlayer.transform.position, flash.transform.position) <= 4){
					setupFlash();
					if(carrying && hasGun){
						flash.SetActive(false);
					}
					else if(!carrying && hasGun){
						leftHoldingItem = flash.GetComponent<Rigidbody>();
						lHand = flash;
						switchLight(false);
					}
					hasFlash = true;
					gameManager.hasFlash = true;
				}
				else flash = null;
			}
			else if(inspecting != null && inspecting.name == "Gun"){
				gun = inspecting;
				if(Vector3.Distance (thisPlayer.transform.position, gun.transform.position) <= 4){
					setupGun();
					if(carrying && hasFlash){
						gun.SetActive(false);
					}
					else if(!carrying && hasFlash) switchLight(false);
					hasGun = true;
					gameManager.hasGun = true;
				}
				else gun = null;
			}
			else if(carrying){
				dropItem();
				if(hasFlash)
					switchLight(false);
			}
			else if ((inspecting != null) && 
			         (inspecting.name == "Oar" || inspecting.name == "Plank" || inspecting.name == "Tools")) {
				if(Vector3.Distance (thisPlayer.transform.position, inspecting.transform.position) <= 4){
					if(hasFlash){
						switchLight(true);
					}

					lHand = inspecting;
					leftHoldingItem = inspecting.GetComponent<Rigidbody> ();
					inspecting.transform.position = (crosshair.transform.position) - 
						(transform.right*1.1f + transform.up - transform.forward*0.5f);
					inspecting.transform.rotation = transform.rotation;
					inspecting.transform.parent = lHandPos;
					//inspecting.GetComponent<Collider>().enabled = false;
					leftHoldingItem.isKinematic = true;
					leftHoldingItem.useGravity = false;
					carrying = true;
					if(inspecting.name == "Oar"){
						inspecting.transform.localEulerAngles = (new Vector3 (0f, 101.759f, 0f));
						inspecting.transform.localPosition = (new Vector3 (-.03f, -2.5f, -.01f));

					}
					else if(inspecting.name == "Plank"){
							inspecting.transform.localEulerAngles = (new Vector3 (308.629f, 236.915f, 140.709f));
							inspecting.transform.localPosition = (new Vector3 (-.4f, 0.18f, 1.9f));
							
					}
				}
			}
		}
		if(Input.GetKeyUp("q")){
			if(carrying && gameManager.hasGun && hasFlash){
				if(gun.activeSelf){
					gun.SetActive(false);
					flash.SetActive(true);
				}
				else{
					flash.SetActive(false);
					gun.SetActive(true);
				}
			}
		}
		if (gun != null && flash != null && gun.activeSelf && flash.activeSelf)
			gameManager.armState = 3;
		else if (gun != null && gun.activeSelf)
			gameManager.armState = 1;
		else if (flash != null && flash.activeSelf)
			gameManager.armState = 2;
		else
			gameManager.armState = 0;
		
		if (prevState != 0 && gameManager.armState != prevState) {
			animator.SetTrigger("Switch");
		}
		prevState = gameManager.armState;
	}


	void setupGun(){
		Rigidbody rbGun = gun.GetComponent<Rigidbody> ();
		//		gun.transform.position = (crosshair.transform.position) - 
		//			(-crosshair.transform.right*0.8f - crosshair.transform.forward*1f + crosshair.transform.up*0.5f);
		//		gun.transform.parent = crosshair.transform;
		
		gun.transform.rotation = holdR.rotation * Quaternion.Euler (26f, 0.5f, 355f);
		gun.transform.parent = holdR;
		gun.transform.localPosition = new Vector3(-0.0023f,0.0006f,0.0045f);
		gun.GetComponent<Collider> ().enabled = false;
		rbGun.isKinematic = true;
		rbGun.useGravity = false;
	}

	void setupFlash(){
		Rigidbody rbFlash = flash.GetComponent<Rigidbody> ();
		//		flash.transform.position = (crosshair.transform.position) - 
		//			(-crosshair.transform.right * 0.8f - crosshair.transform.forward * 1f + crosshair.transform.up * 0.5f);
		//		flash.transform.parent = crosshair.transform;
		flash.transform.rotation = holdR.rotation * Quaternion.Euler (14.2f, 0f, 266.9387f);
		flash.transform.parent = holdR;
		flash.transform.localPosition = new Vector3(-0.00308f,-0.00356f,-0.00175f);
		flash.transform.localScale = new Vector3(0.001423881f,0.003058604f,0.002572078f);
		flash.GetComponent<Collider> ().enabled = false;
		rbFlash.isKinematic = true;
		rbFlash.useGravity = false;

	}

	void switchLight(bool toRight){
		if (toRight) {
			flash.transform.rotation = holdR.rotation * Quaternion.Euler (14.2f, 0f, 266.9387f);
			flash.transform.parent = holdR;
			flash.transform.localPosition  = new Vector3(-0.00308f,-0.00356f,-0.00175f);
			flash.transform.localScale = new Vector3(0.001423881f,0.003058604f,0.002572078f);
			if (hasGun)
				flash.SetActive (false);
		} else {
			flash.transform.rotation = holdL.rotation * Quaternion.Euler (346f, 1.3f, 105f);
			flash.transform.parent = holdL;
			flash.transform.localPosition = new Vector3(-0.00082f,0.00398f,0.00174f);
			flash.transform.localScale = new Vector3(0.001396176f,0.003328305f,0.002932155f);
			flash.SetActive(true);
			lHand = flash;
			if(hasGun)
				gun.SetActive(true);
		}
	}
	

	void dropItem(){
		lHand.transform.parent = null;
		//lHand.GetComponent<Collider>().enabled = true;
		leftHoldingItem.isKinematic = false;
		leftHoldingItem.useGravity = true;
		lHand.transform.position = crosshair.transform.position + crosshair.transform.forward*1.3f;
		leftHoldingItem.velocity = crosshair.transform.forward*5f;
		leftHoldingItem.angularVelocity = Vector3.zero;
		leftHoldingItem = null;
		lHand = null;
		carrying = false;
	}


}