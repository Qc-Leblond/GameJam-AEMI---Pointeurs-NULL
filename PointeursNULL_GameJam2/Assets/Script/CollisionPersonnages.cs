using UnityEngine;
using System.Collections;

public class CollisionPersonnages : MonoBehaviour {

	void OnCollisionEnter(Collision collision)
	{
		Debug.Log ("Contact!");
		//Application.LoadLevelAdditive(Minigames);
	}
}
