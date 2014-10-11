using UnityEngine;
using System.Collections;

public class Tour_Zombie : MonoBehaviour {

	// Use this for initialization
	public void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void Disable_Move()
	{
		CharacterController cc = GetComponent(typeof(CharacterController)) as CharacterController;
		cc.enabled = false;
	}
	
	public void able_Move()
	{
		CharacterController cc = GetComponent(typeof(CharacterController)) as CharacterController;
		cc.enabled = true;
	}
}
