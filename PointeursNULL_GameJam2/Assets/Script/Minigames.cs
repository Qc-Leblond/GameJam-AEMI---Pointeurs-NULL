﻿using UnityEngine;
using System.Collections;

public class Minigames : MonoBehaviour 
{

	public int Chiffre, Jeu, InputZombie = -1, InputHumain = -1;
	public bool ZombieGagne, HumainGagne, ZombieAjoue = false, HumainAJoue = false;
	public string RPCHumain, RPCZombie ;
	
	void Start()
	{
		Jeu = 2;//Random.Range (1, 3); COMMENTAIRE TEMPORAIRE

		if (Jeu == 1) 
		{
			Chiffre = Random.Range (1, 9);
		}
	}
	
	void FixedUpdate ()
	{
		if(Jeu == 1)
		{
			switch (Chiffre) 
			{
			case 1:
				if(Input.GetKey(KeyCode.JoystickButton0))
					Debug.Log ("OK");
				break;
			case 2:
				if(Input.GetKey(KeyCode.JoystickButton1))
					Debug.Log ("OK");
				break;
			case 3:
				if(Input.GetKey(KeyCode.JoystickButton2))
					Debug.Log ("OK");
				break;
			case 4:
				if(Input.GetKey(KeyCode.JoystickButton3))
					Debug.Log ("OK");
				break;
			case 5:
				if(Input.GetKey(KeyCode.JoystickButton4))
					Debug.Log ("OK");
				break;
			case 6:
				if(Input.GetKey(KeyCode.JoystickButton5))
					Debug.Log ("OK");
				break;
			case 7:
				if(Input.GetKey(KeyCode.JoystickButton6))
					Debug.Log ("OK");
				break;
			default:
				if(Input.GetKey(KeyCode.JoystickButton7))
					Debug.Log ("OK");
				break;
			}
		}
		if(Jeu == 2)
		{
			if(ZombieAjoue == false)
			{
				if (Input.GetAxis("PowerUp1") < 0)
				{
					InputZombie = 1;
					ZombieAjoue = true;
				}
				else if (Input.GetAxis("PowerUp2") > 0)
				{
					InputZombie = 2;
					ZombieAjoue = true;
				}
				if (Input.GetAxis("PowerUp1") > 0)
				{
					InputZombie = 3;
					ZombieAjoue = true;
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
			ZombieGagne = true;
		else if ((InputZombie) % 3 + 1 == InputHumain)
			HumainGagne = true;
	}
	void OnGUI()
	{
		GUI.Box (new Rect ((Screen.width/2)-100, 100, 60, 60), "Zombie\n\n" + RPCZombie);
		GUI.Box (new Rect ((Screen.width/2)+40, 100, 60, 60), "Humain\n\n" + RPCHumain);
		if(ZombieGagne == true)
			GUI.Box (new Rect ((Screen.width/2) - 30, 200, 60, 60), "Zombie\n\n" + "gagne!");
		else if (HumainGagne == true)
			GUI.Box (new Rect ((Screen.width/2) - 30, 200, 60, 60), "Humain\n\n" + "gagne!");
	}
}
