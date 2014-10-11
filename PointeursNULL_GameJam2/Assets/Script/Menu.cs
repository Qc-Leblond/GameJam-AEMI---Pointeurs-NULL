using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour 
{
	public bool Control = false, Quit = false;
	void OnGUI () 
	{
		GUI.Box(new Rect(Screen.width/2 - 50,Screen.height/2 - 135,100,120), "Menu");

		if(GUI.Button(new Rect(Screen.width/2 - 40,Screen.height/2 - 105,80,20), "Jouer")) 
		{
			Application.LoadLevel("PlatformTest");
		}
			
		if(GUI.Button(new Rect(Screen.width/2 - 40,Screen.height/2 - 75,80,20), "Controles")) 
		{
			Control = true;
		}
		if (GUI.Button (new Rect (Screen.width / 2 - 40, Screen.height / 2 - 45, 80, 20), "Quitter")) 
		{
			Quit = true;
		}
		if(Control)
			ControlGUI ();
		if (Quit)
			Application.Quit ();
			
	}
	void ControlGUI()
	{
		GUI.Box(new Rect(Screen.width/2 - 200,Screen.height/2,400,130), "Controles\n\n -Utilisez l'analog pour vous diriger de gauche a droite\n\n" +
			"-Appuyez sur le boutton X pour sauter\n\n" + "-Utilisez la croix directionnelle pour utiliser un pouvoir");
	}
}
