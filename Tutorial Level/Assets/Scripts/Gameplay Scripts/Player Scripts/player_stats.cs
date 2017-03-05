using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class player_stats : MonoBehaviour {
	public string Colour;
	public float Health;
	float Max_Playerhealth;
	bool hasColour = false;
	private Image Player_Healthbar;
	GameObject Player_Health;
	// Use this for initialization
	void Start () {
		Colour = null;
		Health = 100;
		Max_Playerhealth = 100;
		Player_Health = GameObject.Find ("UICanvas");
		Player_Healthbar = Player_Health.transform.FindChild("HealthBG").FindChild("PlayerHealth").GetComponent<Image>();
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
		//Debug.Log ("Stored " + C);

	}

	public void sethasColour(bool Colour)
	{
		hasColour = Colour;
		//Debug.Log ("Colour is now" + hasColour);
	}

	public bool gethasColour()
	{
		return hasColour;
	}

	public float getHealth()
	{
		return Health;
	}

	public void setHealth(float x)
	{
		Health = x;
	}

	public float Damage_player()
	{
		float damage = 5;

		setHealth (Health - damage);
		Player_Healthbar.fillAmount = getHealth () / Max_Playerhealth;

		if (getHealth () == 0) {
			PlayerisDead ();
		}
		return 0;
	}


	public void PlayerisDead()
	{
		Debug.Log ("Player is Dead!");
		//Need to add code that will either restart level or figure out how to add a check point in
	}
}
