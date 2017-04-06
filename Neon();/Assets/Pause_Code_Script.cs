using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause_Code_Script : MonoBehaviour {
    public TextAsset Pause_Code;
    string message;
    Text text;

    IEnumerator TypeText()
    {
       foreach(char letter in message.ToCharArray())
        {
            text.text += letter;
            yield return new WaitForSeconds(2.0f);
        }
        yield return new WaitForSeconds(1.0f);
        text.text = null;

    }
    
    
    // Use this for initialization
	void Start () {
       text =  this.GetComponent<Text>();

	}
	
	// Update is called once per frame
	void Update () {
        if (Global_Script.Paused == true)
        {
            for (int i = 0; i < 100; i++)
            {
                message = Pause_Code.ToString();
                text.text = "";
                StartCoroutine(TypeText());
            }
        }
	}
}
