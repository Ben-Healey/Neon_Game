using UnityEngine;
using System.Collections;

public class Light_Script_Test : MonoBehaviour {
	float timer = 1.0f;
	public void Start(){
		StartCoroutine(Blink());
	}
	
	IEnumerator Blink()
	{
		GameObject lightGameObject = new GameObject ("Test Light");
		Light lightComp = lightGameObject.AddComponent<Light> ();
		//lightComp.color = Color.blue;
				while (true) {
					yield return new WaitForSeconds (timer);
					lightComp.enabled = !lightComp.enabled;
				}		
	}
}
