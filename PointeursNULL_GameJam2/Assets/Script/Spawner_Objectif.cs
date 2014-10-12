using UnityEngine;
using System.Collections;

public class Spawner_Objectif : MonoBehaviour {

	public bool PorteObjectif = false;
	public GameObject Main;
	
	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.tag == "Zombie" && PorteObjectif == true) 
		{
			Main.GetComponent<Timer>().GiveZPoints();
		//	other.Destroy(other.gameObject.Find());
		}
		if (other.tag == "Human" && PorteObjectif == true)
		{
			other.GetComponentInChildren<Human_Handling>().FuckOffIncapacitated();
		}
		PorteObjectif = false;
	}
}