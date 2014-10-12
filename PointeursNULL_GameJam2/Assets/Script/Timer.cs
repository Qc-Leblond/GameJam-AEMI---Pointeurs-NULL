using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour 
{
    private bool TimerActive = false;
	private float timeLeft;
    private float timeStart = 20;
	public int ZPoints = 0;
	public int HPoints = 0;

	void Update ()
	{
        if (TimerActive)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                GetComponent<Game_Main>().AddToRoundCount();
                TimerActive = false;
            }
        }
	}

	void OnGUI ()
	{
        if (TimerActive)
        {
            GUI.Box(new Rect((Screen.width / 2) - 30, 50, 60, 50), "Temps \n" + ((int)timeLeft));
        }
		GUI.Label (new Rect (100, Screen.height - 100, 50, 50), "Score \n"+ZPoints.ToString());
		GUI.Label (new Rect (Screen.width - 100, Screen.height-100, 50, 50), "Score \n"+HPoints.ToString ());
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
