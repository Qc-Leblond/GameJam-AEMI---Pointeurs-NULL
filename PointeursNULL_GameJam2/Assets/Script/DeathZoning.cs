using UnityEngine;
using System.Collections;

public class DeathZoning : MonoBehaviour 
{
	private AudioClip hbafloune;
    public GameObject Main;

    void OnTriggerEnter2D(Collider2D other)
    {
		hbafloune = Resources.Load ("hbafloune") as AudioClip;
        if (other.tag == "Zombie")
        {
			this.gameObject.AddComponent("AudioSource");
			audio.clip = hbafloune;
			audio.Play();
            Main.GetComponent<Game_Main>().ZombieDeath(other.gameObject);
        }
        if (other.tag == "Human")
        {
            Main.GetComponent<Game_Main>().HumanDeath(other.gameObject);
        }
    }
}
