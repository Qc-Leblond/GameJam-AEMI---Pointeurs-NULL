using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour 
{
	public bool Control = false;
    public Font fontName;
    public Font fontForRest;
    public bool ZombieWin;

    void Start()
    {
        ZombieWin = true;
    }

	void OnGUI () 
	{
        GUIStyle StyleName = new GUIStyle();
        GUIStyle StyleForRest = new GUIStyle();
        StyleName.font = fontName;
        StyleForRest.font = fontForRest;

        if (Application.loadedLevelName == "Menu")
        {
            if (!Control)
            {
                GUI.Label(new Rect((Screen.width / 4) * 3 - 230, Screen.height / 2 - 180, 100, 120), "World War H", StyleName);

                if (GUI.Button(new Rect(3 * Screen.width / 4 - 110, Screen.height / 2 - 90, 80, 20), "Jouer", StyleForRest))
                {
                    Debug.Log("Load");
                    Application.LoadLevel("Map_Final");
                }

                if (GUI.Button(new Rect(3 * Screen.width / 4 - 110, Screen.height / 2 - 50, 80, 20), "Controles", StyleForRest))
                {
                    Control = true;
                }
                if (GUI.Button(new Rect(3 * Screen.width / 4 - 110, Screen.height / 2 - 10, 80, 20), "Quitter", StyleForRest))
                {
                    Debug.Log("Quit");
                    Application.Quit();
                }
            }
            else
            {
                if (GUI.Button(new Rect(3 * Screen.width / 4 - 110, Screen.height / 2 + 95, 80, 20), "Return to Menu", StyleForRest))
                {
                    Control = false;
                }

                GUI.Label(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 180, 400, 130), "Controles\n\n Utilisez l'analog pour vous diriger de\n gauche a droite" +
                "\n\n Appuyez sur le boutton X pour sauter\n", StyleForRest);
            }
        }

		if (Application.loadedLevelName == "ZScoreBoard")
        {
            GUI.Label(new Rect(Screen.width / 2 - 230, Screen.height / 2 - 140, 400, 130), "Zombie Player Wins", StyleName);
        }

		if (Application.loadedLevelName == "HScoreBoard")
		{
			GUI.Label(new Rect(Screen.width / 2 - 230, Screen.height / 2 - 140, 400, 130), "Human Player Wins", StyleName);
		}
	}
}
