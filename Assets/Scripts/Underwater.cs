using UnityEngine;
using System.Collections;

[ExecuteInEditMode]

public class Underwater : MonoBehaviour {
	
	#region public data
	public float m_UnderwaterCheckOffset = 0.001F;	
	public Color envFogColor;
	public Color underwaterFogColor = new Color32(249,59,59,255);
	public GameObject water;
	
	public float skyFogDensity = 0.005f;
	public float waterFogDensity = 0.05f;


	#endregion
	
	
	#region private data
	private bool wasUnderwater = false;
	#endregion
	
	public bool IsUnderwater(Camera cam) {
		return cam.transform.position.y + m_UnderwaterCheckOffset < transform.position.y ? true : false;	
	}
			
	public void OnWillRenderObject()
	{
		
		Camera cam = Camera.current;
		
		if(IsUnderwater(cam)) 
		{
			if(Camera.main == cam && !cam.gameObject.GetComponent(typeof(UnderwaterEffect)) ) {
					cam.gameObject.AddComponent(typeof(UnderwaterEffect));	
				}
				
				UnderwaterEffect effect = (UnderwaterEffect)cam.gameObject.GetComponent(typeof(UnderwaterEffect));				
				if(effect) {
					effect.enabled = true;					
				}
				
				//Ok some HACK's here 
				GetComponent<Renderer>().sharedMaterial.shader.maximumLOD = 50;	
				
			
				if(!wasUnderwater){
					
					wasUnderwater = true;
							
					//Change fog a little
					//RenderSettings.fog = true;
					RenderSettings.fogDensity = waterFogDensity;
					RenderSettings.fogColor = underwaterFogColor;		
					water.transform.Rotate(new Vector3(0f, 0f, 180f));


									
				}
			
		}
		else{
			
			UnderwaterEffect effect = (UnderwaterEffect)cam.gameObject.GetComponent(typeof(UnderwaterEffect));
				if(effect && effect.enabled) {
					effect.enabled = false;
				}

				//Ok some HACK's here 
				GetComponent<Renderer>().sharedMaterial.shader.maximumLOD = 100;	
				
				if(wasUnderwater){
				
					
					//Change fog a little
				//RenderSettings.fog = false;
					RenderSettings.fogDensity = skyFogDensity;
					RenderSettings.fogColor = envFogColor;
					wasUnderwater = false;
					water.transform.Rotate(new Vector3(0f, 0f, 180f));


				
				}
			
		}
		
	}
}
