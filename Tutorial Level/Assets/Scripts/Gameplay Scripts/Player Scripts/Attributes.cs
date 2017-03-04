using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Attributes : MonoBehaviour {
	// Use this for initialization
	//public Global_Script Global;
	public float Health;
	public float Squad_health;
	public float MaxHealth;
	private Image Heathbar;
	void Start () {
		Health = 100;
		MaxHealth = 100;
		Heathbar = this.transform.FindChild ("EnemyCanvas").FindChild ("HealthBG").FindChild ("Health").GetComponent<Image> ();
	}

	// Update is called once per frame
	void Update () {

	}

	public float Get_Enemy_Health(){
		return Health;
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
