using UnityEngine;
using System.Collections;

public class Character_Controller : MonoBehaviour 
{
    private float Speed = 5f;
    private float jumpSpeed = 8f;
    private float gravity = 20f;

    private Transform GroundCheck;
    private bool onGround;
    private float groundCheckRadius = 0.1f;

    private bool Button1Down;
    private bool Button2Down;

    private Vector3 moveDirection = Vector3.zero;

    void Awake()
    {
        GroundCheck = transform.FindChild("GroundCheck");
    }

    void Update()
    {
        CharacterController Controller = GetComponent<CharacterController>();

        if (Controller.isGrounded) 
        {

			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0,0);
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= Speed;
			
			if (Input.GetButton ("Jump")) 
            {
				moveDirection.y = jumpSpeed;
			}
		}

		moveDirection.y -= gravity * Time.deltaTime;
		Controller.Move(moveDirection * Time.deltaTime);
    }

    void Mouvement(bool onGround)
    {

              
    }

    void DpadButton()
    {
        if (Input.GetAxis("PowerUp1") == 0) Button1Down = false;
        else if (Input.GetAxis("PowerUp1") == 1 && !Button1Down)
        {
            Button1Down = true;
            Debug.Log("Power Up 1");
        }
        else if (Input.GetAxis("PowerUp1") == -1 && !Button1Down)
        {
            Button1Down = true;
            Debug.Log("Power Up 2");
        }

        if (Input.GetAxis("PowerUp2") == 0) Button2Down = false;
        else if (Input.GetAxis("PowerUp2") == 1 && !Button2Down)
        {
            Button2Down = true;
            Debug.Log("Power Up 3");
        }
        else if (Input.GetAxis("PowerUp2") == -1 && !Button2Down)
        {
            Button2Down = true;
            Debug.Log("Power Up 4");
        }
    }
}
