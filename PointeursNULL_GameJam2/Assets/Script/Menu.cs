using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour 
{
	void OnGUI () 
	{
		GUI.Box(new Rect(100,100,100,90), "Menu");

		if(GUI.Button(new Rect(110,130,80,20), "Jouer")) 
		{
			Application.LoadLevel("Scene1");
		}
			
		if(GUI.Button(new Rect(110,160,80,20), "Bouton 2")) 
		{
			Debug.Log("Action 2");
		}
	}
}
