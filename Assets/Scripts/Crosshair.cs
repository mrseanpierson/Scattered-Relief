using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour 
{
	public bool drawCrosshair = true;
	public Color crosshairColor = Color.white;
	public Texture2D crossTex;
	public float chRad = 8; //for the size of the crosshair

	private new Camera camera;

	void Start(){
		camera = GetComponent<Camera>();
	}

	void Update(){
		Ray ray = camera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit)) {
			SetColor(crossTex,Color.green);
			//print ("I'm looking at " + hit.transform.name);
		} else {
			SetColor(crossTex,Color.white);
			//print ("I'm looking at nothing!");
		}
	}

	void OnGUI () {
		Vector2 centerPoint = new Vector2(Screen.width / 2, Screen.height / 2);
		float offSet = chRad / 2;

		if (drawCrosshair) GUI.DrawTexture(new Rect(centerPoint.x-offSet,centerPoint.y-offSet,chRad,chRad),crossTex);

	}
	void SetColor(Texture2D myTexture, Color myColor) {
		for (int y = 0; y < myTexture.height; y++) {
			for (int x = 0; x < myTexture.width; x++){
				if(myTexture.GetPixel(x,y).a > 0.5){
					myTexture.SetPixel(x, y, myColor);
				}
			}
			myTexture.Apply();
		}
	}

	public GameObject lookingAt(){
		Ray ray = camera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit)) {
			//print ("I'm looking at " + hit.transform.name);
			return hit.transform.gameObject;
		} else {
			//print ("I'm looking at nothing!");
			return null;
		}
	}

}