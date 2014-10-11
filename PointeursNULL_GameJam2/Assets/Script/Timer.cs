using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
    private bool TimerActive = false;
	private float timeLeft;
    private float timeStart = 5;
	private int ZPoints = 0;
	private int HPoints = 0;

	// Update is called once per frame
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
		GUI.Box (new Rect (100, Screen.height - 100, 50, 50), "Score \n"+ZPoints);
		GUI.Box (new Rect (Screen.width - 100, Screen.height-100, 50, 50), "Score \n"+HPoints);
	}

    public void NewTimer()
    {
        timeLeft = timeStart;
        TimerActive = true;
    }
}
