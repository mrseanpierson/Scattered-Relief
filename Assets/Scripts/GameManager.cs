using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public GameObject arms;
	public bool hasOar;
	public bool hasTools;
	public bool hasPlank;
	public int numBullets;
	public int numActiveBullets;
	public bool hasGun;
	public bool hasFlash;
	public GameObject boat;
	public bool moving;
	public GameObject player;
	public int armState;
	public GameObject nuxPlatform;
	private bool nuxMode;
	public Material sunnySky;
	private Material nightSky;
	private Vector3 playerPos;
	private float speed;
	private Animator animator;

	/*
	 <summary> Arm States
	 0 = Both arms empty. Arms down/out of frame
	 1 = Left arm down, gun out. Can be used for holding something, or empty left hand
	 2 = Left arm down, flash out. Can be used for holding something, or empty left hand
	 3 = Both arms up holding gun and flash.
	 </summary>
	*/

	// Use this for initialization
	void Start () {
		hasFlash = false;
		hasGun = false;
		hasOar = false;
		hasTools = false;
		hasPlank = false;
		numBullets = 5;
		speed = 5;
		numActiveBullets = 0;
		armState = 0;
		animator = arms.GetComponent<Animator> ();
		nuxPlatform.SetActive (false);
		nuxMode = false;
		nightSky = RenderSettings.skybox;
		Cursor.visible = false;
	}



	// Update is called once per frame
	void Update () {

		if (Input.GetKeyUp ("n")) {
			nuxMode = !nuxMode;
			nuxPlatform.SetActive(nuxMode);
			if(nuxMode == true){
				playerPos = player.transform.position;
				player.transform.position = new Vector3(157.1f, 5.5f, -240.1f);
				RenderSettings.skybox = sunnySky;
				RenderSettings.ambientIntensity = 1f;
			}
			else if(nuxMode == false){
				player.transform.position = playerPos;
				RenderSettings.skybox = nightSky;
				RenderSettings.ambientIntensity = 0.05f;

			}
		}
		if (hasOar && hasPlank && hasTools && !moving) {
			boat.transform.localPosition = new Vector3(278.29f, -10.56f, -316.85f);
			boat.transform.localRotation = Quaternion.Euler(-90, 180, 0);
		}
		else if (hasOar && hasPlank && hasTools && moving) {
			boat.transform.localPosition += (transform.forward*-1)*speed*Time.deltaTime;
			player.transform.localPosition += (transform.forward*-1)*speed*Time.deltaTime;

		}

		animator.SetInteger("State",armState);
	}
}
