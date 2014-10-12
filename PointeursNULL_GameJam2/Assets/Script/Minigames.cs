using UnityEngine;
using System.Collections;

public class Minigames : MonoBehaviour 
{

	public int Chiffre, Jeu, InputZombie = -1, InputHumain = -10;
	public bool ZombieGagne, HumainGagne, ZombieAJoue = false, HumainAJoue = false;
	public string RPCHumain, RPCZombie ;
	public bool StartGame = false;
	public bool GO = false;

	public Sprite Carre, Triangle, X, Cercle;

	private SpriteRenderer spriteRenderer;

	void Start()
	{

	}
	
	void Update ()
	{
		if (StartGame == true)
		{
			GO = true;
			spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
			Jeu = Random.Range (1, 3); 
			
			if (Jeu == 1) 
			{
				Chiffre = Random.Range (1, 5);
			}
			StartGame = false;
		}

		if (GO == true)
		{
			if(Jeu == 1)
			{
				switch (Chiffre) 
				{
				case 1:
					spriteRenderer.sprite = Carre;
					if(Input.GetButtonDown("Carre") && ZombieAJoue == false)
						ZombieAJoue = ZombieGagne = true;
					else if(Input.GetButtonDown("P2Carre") && HumainAJoue == false)
						HumainAJoue = HumainGagne = true; GO = false;
					break;
				case 2:
					spriteRenderer.sprite = Triangle;
					if(Input.GetButtonDown("Triangle") && ZombieAJoue == false)
						ZombieAJoue = ZombieGagne = true;
					else if(Input.GetButtonDown("P2Triangle") && HumainAJoue == false)
						HumainAJoue = HumainGagne = true; GO = false;
					break;
				case 3:
					spriteRenderer.sprite = X;
					if(Input.GetButtonDown("Jump") && ZombieAJoue == false)
						ZombieAJoue = ZombieGagne = true;
					else if(Input.GetButtonDown("P2Jump") && HumainAJoue == false)
						HumainAJoue = HumainGagne = true; GO = false;
					break;
				case 4:
					spriteRenderer.sprite = Cercle;
					if(Input.GetButtonDown("Cercle") && ZombieAJoue == false)
						ZombieAJoue = ZombieGagne = true;
					else if(Input.GetButtonDown("P2Cercle") && HumainAJoue == false)
						HumainAJoue = HumainGagne = true; GO = false;
					break;
				}
			}
			if(Jeu == 2)
			{
				if(ZombieAJoue == false)
				{
					if (Input.GetAxis("PowerUp1") < 0)
					{
						InputZombie = 1;
						ZombieAJoue = true;
					}
					else if (Input.GetAxis("PowerUp2") > 0)
					{
						InputZombie = 2;
						ZombieAJoue = true;
					}
					if (Input.GetAxis("PowerUp1") > 0)
					{
						InputZombie = 3;
						ZombieAJoue = true;
					}
				}
				if(HumainAJoue == false)
				{
					if (Input.GetAxis("P2PowerUp1") < 0)
					{
						InputHumain = 1;
						HumainAJoue = true;
					}
					else if (Input.GetAxis("P2PowerUp2") > 0)
					{
						InputHumain = 2;
						HumainAJoue = true;
					}
					if (Input.GetAxis("P2PowerUp1") > 0)
					{
						InputHumain = 3;
						HumainAJoue = true;
					}
				}
				switch(InputZombie)
				{
				case 1:
					RPCZombie = "Roche";
					break;
				case 2:
					RPCZombie = "Papier";
					break;
				case 3:
					RPCZombie = "Ciseaux";
					break;
				}
				
				switch(InputHumain)
				{
				case 1:
					RPCHumain = "Roche";
					break;
				case 2:
					RPCHumain = "Papier";
					break;
				case 3:
					RPCHumain = "Ciseaux";
					break;
				}
			}
			
			if ((InputHumain) % 3 + 1 == InputZombie)
			{
				ZombieGagne = true;
				GO = false;
			}
			else if ((InputZombie) % 3 + 1 == InputHumain)
			{
				HumainGagne = true;
				GO = false;
			}

			if (InputHumain == InputZombie)
			{
				//BUG!!!
				InputZombie = -1; InputHumain = -10;
				ZombieAJoue = false; HumainAJoue = false;
				RPCZombie = " "; RPCHumain = " ";
			}
		}
	}

	void OnGUI()
	{
		if (ZombieGagne == true || HumainGagne == true || Jeu == 2) 
		{
			if(Jeu == 2)
			{
				GUI.Box (new Rect ((Screen.width / 2) - 100, 100, 60, 60), "Zombie\n\n" + RPCZombie);
				GUI.Box (new Rect ((Screen.width / 2) + 40, 100, 60, 60), "Humain\n\n" + RPCHumain);
			}
			if (ZombieGagne == true)
				GUI.Box (new Rect ((Screen.width / 2) - 30, 200, 60, 60), "Zombie\n\n" + "gagne!");
			else if (HumainGagne == true)
				GUI.Box (new Rect ((Screen.width / 2) - 30, 200, 60, 60), "Humain\n\n" + "gagne!");
		}
	}
}
