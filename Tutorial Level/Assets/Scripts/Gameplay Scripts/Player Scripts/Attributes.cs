using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Attributes : MonoBehaviour {
	// Use this for initialization
	//public Global_Script Global;
	public float Health;
	public float MaxHealth;
	private Image Heathbar;
	void Start () {
		Health = 100;
		MaxHealth = 100;
		Heathbar = transform.FindChild ("EnemyCanvas").FindChild ("HealthBG").FindChild ("Health").GetComponent<Image> ();
	}

	// Update is called once per frame
	void Update () {

	}

	public float Get_Enemy_Health(){
		return Health;
	}

	public float Get_Player_Speed(){
		float speed = 6.0f;
		return speed;
	}

	public int damage(){
		Health -= 25;

		Heathbar.fillAmount = Health / MaxHealth;

		if (Health <= 0) {
			Destroy (gameObject);
			Global_Script.Destoryed_Targets += 1;
		}
		return 0;
	}
	public bool Died(){
		bool isDead = true;
		return isDead; 
	}
}
