using UnityEngine;
using System.Collections;

public class player_stats : MonoBehaviour {
	public string Colour;
	float health ;
	// Use this for initialization
	void Start () {
		 Colour = null;
		 health = 100;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public string Get_Colour()
	{
		return Colour;
	}

	public void Store_Colour(string C)
	{
		Colour = C;
		Debug.Log ("Stored " + C);

	}
}
