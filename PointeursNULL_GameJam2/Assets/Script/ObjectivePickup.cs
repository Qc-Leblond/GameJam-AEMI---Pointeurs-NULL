using UnityEngine;
using System.Collections;

public class ObjectivePickup : MonoBehaviour 
{
	private AudioClip bpickup;
	private AudioClip bdies;

	void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 11 && !collider.gameObject.GetComponent<Character_Controller>().transportObjective)
        {
			bpickup = Resources.Load ("bpickup") as AudioClip;
			this.gameObject.AddComponent("bpickup");
			audio.clip = bpickup;
			audio.Play();
            collider.GetComponent<Character_Controller>().transportObjective = true;
            transform.parent = collider.gameObject.transform;
            transform.localPosition = (new Vector3(-0.125f, 0.125f, 1));
        }
        else if (collider.gameObject.layer == 12)
        {
			bdies = Resources.Load ("bdies") as AudioClip;
			this.gameObject.AddComponent("bdies");
			audio.clip = bdies;
			audio.Play();
            //ajouter point humain
            GameObject.FindGameObjectWithTag("GameController").GetComponent<Timer>().GiveHPoints();
            Debug.Log(GameObject.FindGameObjectWithTag("GameController").GetComponent<Timer>().HPoints);

            Destroy(this.gameObject);
        }
    }
}
