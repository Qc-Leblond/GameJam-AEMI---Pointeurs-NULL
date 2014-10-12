using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour 
{
    public bool TimerActive = false;
	private float timeLeft;
    private float timeStart = 20;
	public int ZPoints = 0;
	public int HPoints = 0;

    public Font fontName;
    public Font fontForRest;

	void Update ()
	{
        if (TimerActive)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                GetComponent<Game_Main>().AddToRoundCount();
                TimerActive = false;
                GetComponent<Game_Main>().ForNextRound();
            }
        }
	}

	void OnGUI ()
	{
        GUIStyle StyleName = new GUIStyle();
        GUIStyle StyleForRest = new GUIStyle();
        StyleName.font = fontName;
        StyleForRest.font = fontForRest;
        StyleName.font.material.color = Color.white;
        StyleForRest.font.material.color = Color.white;

        if (TimerActive)
        {
            GUI.Box(new Rect((Screen.width / 2) - 30, 50, 60, 50), "Temps " + ((int)timeLeft), StyleForRest);
        }
        GUI.Label(new Rect(100, Screen.height - 100, 50, 50), "Score " + ZPoints.ToString(), StyleForRest);
        GUI.Label(new Rect(Screen.width - 100, Screen.height - 100, 50, 50), "Score " + HPoints.ToString(), StyleForRest);
	}

    public void NewTimer()
    {
        timeLeft = timeStart;
        TimerActive = true;
    }

	public void GiveZPoints()
	{
		ZPoints++;
	}

	public void GiveHPoints()
	{
		HPoints++;
	}
}
