using UnityEngine;
using System.Collections;

public class ObjectivePickup : MonoBehaviour 
{

	void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 11 && !collider.gameObject.GetComponent<Character_Controller>().transportObjective)
        {
            collider.GetComponent<Character_Controller>().transportObjective = true;
            transform.parent = collider.gameObject.transform;
            transform.localPosition = (new Vector3(-0.125f, 0.125f, 1));
        }
        else if (collider.gameObject.layer == 12)
        {
            //ajouter point humain
            GameObject.FindGameObjectWithTag("GameController").GetComponent<Timer>().GiveHPoints();
            Debug.Log(GameObject.FindGameObjectWithTag("GameController").GetComponent<Timer>().HPoints);

            Destroy(this.gameObject);
        }
    }
}
