using UnityEngine;
using System.Collections;

public class Minigames : MonoBehaviour 
{
	
	public int  InputZombie = -1, 
				InputHumain = -1;
	public bool ZombieGagne, 
				HumainGagne, 
				ZombieAJoue = false, 
				HumainAJoue = false,
				StartGame = true;
	public string RPCHumain, 
				  RPCZombie ;

	public GUIText Texte;
	
	void Test()
	{
		InputZombie = -1; InputHumain = -1;
		ZombieAJoue = false; HumainAJoue = false;
		RPCZombie = " "; RPCHumain = " ";
	}

	void FixedUpdate()
	{
		Texte.text = "                  Roche Papier Ciseaux\n  Appuyez sur Carré pour séléctionner Roche,\n appuyez sur Triangle pour séléctionner Papier\net appuyez sur Cercle pour séléctionner Ciseaux";
		if (StartGame == true)
		{
			if(ZombieAJoue == false)
			{
				if (Input.GetButton("Roche"))
				{
					InputZombie = 1;
					ZombieAJoue = true;
					RPCZombie = "Pret";
				}
				else if (Input.GetButton("Papier"))
				{
					InputZombie = 2;
					ZombieAJoue = true;
					RPCZombie = "Pret";
				}
				if (Input.GetButton("Ciseaux"))
				{
					InputZombie = 3;
					ZombieAJoue = true;
					RPCZombie = "Pret";
				}
			}
			if(HumainAJoue == false)
			{
				if (Input.GetButtonDown("P2Roche"))
				{
					InputHumain = 1;
					HumainAJoue = true;
					RPCHumain = "Pret";
				}
				else if (Input.GetButtonDown("P2Papier"))
				{
					InputHumain = 2;
					HumainAJoue = true;
					RPCHumain = "Pret";
				}
				if (Input.GetButtonDown("P2Ciseaux"))
				{
					InputHumain = 3;
					HumainAJoue = true;
					RPCHumain = "Pret";
				}
			}
			if (InputHumain == InputZombie)
			{
				Test ();
			}
			if (RPCZombie == "Pret" && RPCHumain == "Pret")
			{
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
<<<<<<< HEAD
		}
		
		if ((InputHumain) % 3 + 1 == InputZombie)
		{
			ZombieGagne = true;
			StartGame = false;
		}
		else if ((InputZombie) % 3 + 1 == InputHumain)
		{
			HumainGagne = true;
			StartGame = false;
=======
			
			if ((InputHumain) % 3 + 1 == InputZombie)
			{
				ZombieGagne = true;
                GameObject.FindGameObjectWithTag("Human").GetComponent<Human_Handling>().GetBitten();
				GO = false;
			}
			else if ((InputZombie) % 3 + 1 == InputHumain)
			{
				HumainGagne = true;
                Destroy(GameObject.FindGameObjectWithTag("Zombie"));
                HumainGagne = false;
				GO = false;
			}

			if (InputHumain == InputZombie)
			{
				//BUG!!!
				InputZombie = -1; InputHumain = -10;
				ZombieAJoue = false; HumainAJoue = false;
				RPCZombie = " "; RPCHumain = " ";
			}
>>>>>>> origin/master2
		}
	}
	
	void OnGUI()
	{
		GUI.Box (new Rect ((Screen.width / 2) - 100, 100, 60, 60), "Zombie\n\n" + RPCZombie);
		GUI.Box (new Rect ((Screen.width / 2) + 40, 100, 60, 60), "Humain\n\n" + RPCHumain);
		if (ZombieGagne == true)
			GUI.Box (new Rect ((Screen.width / 2) - 30, 200, 60, 60), "Zombie\n\n" + "gagne!");
		else if (HumainGagne == true)
			GUI.Box (new Rect ((Screen.width / 2) - 30, 200, 60, 60), "Humain\n\n" + "gagne!");
	}
}
