using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spotted_Script : MonoBehaviour {
    Light Spot_Light;
    private Alarm_Script Alarm;

    IEnumerator Colour_Change()
    {
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

    private void OnTriggerEnter(Collider other)
    {
        float time = Time.deltaTime;
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Camera Space Has Been Entered");
            Spot_Light.color = Color.yellow;
            if(time >  5)
            {
                
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("LEAVING CAMERA SPACE");
            Spot_Light.color = Color.white;
        }
    }
}
