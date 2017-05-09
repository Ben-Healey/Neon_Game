using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spotted_Script : MonoBehaviour {
    Light Spot_Light;
    private Alarm_Script Alarm;
    bool inlight;
    float time = 0;
    IEnumerator Colour_Change()
    {
        inlight = false;
        Debug.Log("ALARM");
        Global_Script.Alarm = true;
        Spot_Light.color = Color.red;
        Alarm.AlarmSetoff();
        yield return null;

    }
	// Use this for initialization
	void Start () {
        Spot_Light = GetComponentInChildren<Light>();
        Alarm = gameObject.GetComponent<Alarm_Script>();


	}


    void Update()
    {
        if(inlight == true)
        { 
			time += Time.deltaTime;
			Debug.Log(time);
			Debug.Log("Camera Space Has Been Entered");
			Spot_Light.color = Color.yellow;
                
			if (time >= 5){
               StartCoroutine(Colour_Change());
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        time = 0;
        inlight = true;
    }

    private void OnTriggerExit(Collider other)
    {
        inlight = false;
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("LEAVING CAMERA SPACE");
            Spot_Light.color = Color.white;
        }
    }
}
