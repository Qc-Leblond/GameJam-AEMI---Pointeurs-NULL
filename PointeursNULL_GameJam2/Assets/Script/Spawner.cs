using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

	}

    void OnTriggerEnter2D(Collider2D collide)
    {
        if ((gameObject.layer ==13 && collide.gameObject.layer ==12) && collide.GetComponent<Character_Controller>().transportObjective)
        {
            collide.GetComponent<Character_Controller>().transportObjective = false;
            collide.GetComponent<Human_Handling>().FuckOffIncapacitated();
            collide.transform.GetChild(1).GetComponent<Human_Handling>().FuckOffIncapacitated();
        }
        else if ((gameObject.layer ==14 && collide.gameObject.layer ==11) && collide.GetComponent<Character_Controller>().transportObjective)
        {
            collide.GetComponent<Character_Controller>().transportObjective = false;
            Destroy(collide.transform.GetChild(2).gameObject);
            GameObject.FindGameObjectWithTag("GameController").GetComponent<Timer>().GiveZPoints();
            Debug.Log(GameObject.FindGameObjectWithTag("GameController").GetComponent<Timer>().ZPoints);
            
        }
    }
}
