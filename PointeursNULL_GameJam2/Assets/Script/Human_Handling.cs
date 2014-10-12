using UnityEngine;
using System.Collections;

public class Human_Handling : MonoBehaviour
{
    public bool Incapacitated = false;
    private int TurnToZombie;
    public GameObject Main;
    public Animator anim;

	private AudioClip HumanBitten;

    void Start()
    {
        anim = GetComponent<Animator>();
        TurnToZombie = 2;
    }

    void Update()
    {
        if (TurnToZombie == 0)
        {
            Main.GetComponent<Game_Main>().HumanTransform(gameObject);
        }
    }

    public void GetBitten() 
    { 

        this.Incapacitated = true;

		HumanBitten = Resources.Load ("HumanBitten") as AudioClip;
		audio.clip = HumanBitten;
		audio.Play();
        Incapacitated = true;

        anim.SetBool("Infected", true);
    }
    public bool isIncapacitated() { return Incapacitated; }
    public void RemoveTurnToZombie() { TurnToZombie -= 1; }
	public void FuckOffIncapacitated()
	{
        TurnToZombie = 2;
		Incapacitated = false;
        anim.SetBool("Infected", false);
		transform.parent = null;
	}

	void OnEnterCollision2D(Collision2D other)
	{
		Debug.Log ("**");
		if (other.transform.tag == "Zombie") Main.GetComponent<Game_Main> ().StartCombat (other.gameObject, gameObject);
		
	}

    void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.gameObject.layer == 12 && collide.GetComponent<Human_Handling>().Incapacitated && !GetComponent<Character_Controller>().transportObjective)
        {
            GetComponent<Character_Controller>().transportObjective = true;
            transform.parent = collide.transform;
        }
        
    }
}
