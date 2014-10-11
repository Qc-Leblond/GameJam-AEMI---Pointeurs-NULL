using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
	float timeLeft = 20;
	int ZPoints = 0;
	int HPoints = 0;

	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
		timeLeft -= Time.deltaTime;
		if(timeLeft < 0)
		{
		//	GameOver();
		}
	}

	void OnGUI ()
	{
		GUI.Box (new Rect ((Screen.width/2)-30, 50, 60, 50), "Temps \n"+((int)timeLeft));
		GUI.Box (new Rect (100, Screen.height - 100, 50, 50), "Score \n"+ZPoints);
		GUI.Box (new Rect (Screen.width - 100, Screen.height-100, 50, 50), "Score \n"+HPoints);
	}
}
