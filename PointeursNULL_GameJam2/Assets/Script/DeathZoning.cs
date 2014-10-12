using UnityEngine;
using System.Collections;

public class DeathZoning : MonoBehaviour 
{
    public GameObject Main;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Zombie")
        {
            Main.GetComponent<Game_Main>().ZombieDeath(other.gameObject);
        }
        if (other.tag == "Human")
        {
            Main.GetComponent<Game_Main>().HumanDeath(other.gameObject);
        }
    }
}
