using UnityEngine;
using System.Collections;

public class Character_Controller : MonoBehaviour
{
	public bool canMove;
    private float Speed = 10f;
    private float jumpSpeed = 15f;
    private float Gravity = 20f;
    public bool isHuman;
    protected Animator animator;

    CharacterController Controller;
    private bool facingRight = true;
    Vector3 moveDirection = Vector3.zero;
    private float Ymove;

    private string horizontal;
    private string jump;
    private string powerUp1;
    private string powerUp2;

    private bool Button1Down;
    private bool Button2Down;
    private string ControllerActive;

    void Start()
    {
        animator = GetComponent<Animator>();
        if (isHuman) ControllerActive = "P1_";
        else ControllerActive = "P2_";

    }

    void Update()
    {
        DpadButton();
        Triggers();

        if (Input.GetAxis(horizontal) < 0)
            this.transform.localScale = (new Vector3(-5, 5, 1));

        if (Input.GetAxis(horizontal) > 0)
            this.transform.localScale = (new Vector3(5, 5, 1));


        if (Mathf.Abs(moveDirection.x) > 0.5f || Mathf.Abs(moveDirection.y) > 0.5f)
            animator.SetFloat("Speed", Mathf.Sqrt((moveDirection.x*moveDirection.x)+(moveDirection.y*moveDirection.y)));
        else
            animator.SetFloat("Speed",0.0f);
    }

    void FixedUpdate()
    {
        Controller = GetComponent<CharacterController>();
		if (Controller.isGrounded && canMove == true) 
        {
			// We are grounded, so recalculate
			// move direction directly from axes
            animator.SetBool("Jump", false);
			moveDirection = new Vector3(Input.GetAxis(ControllerActive + "Horizontal"), 0, 0);
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= Speed;

            if (Input.GetButtonDown(ControllerActive + "Jump"))
            {
                Ymove = jumpSpeed;
                animator.SetBool("Jump", true);
            }
            else
            {
                Ymove = 0;
            }
		}
		Ymove -= Gravity * Time.deltaTime;
        moveDirection.y = Ymove;
        Controller.Move(moveDirection * Time.deltaTime);
    }

    void Triggers()
    {

    }

    void DpadButton()
    {
        if (Input.GetAxis(powerUp1) < 0)
            Debug.Log("PowerUp 1");
        else if (Input.GetAxis(powerUp1) > 0)
            Debug.Log("PowerUp 4");

        if (Input.GetAxis(powerUp2) < 0)
            Debug.Log("PowerUp 2");
        else if (Input.GetAxis(powerUp2) > 0)
            Debug.Log("PowerUp 3");

    }

	public void Move()
	{
		canMove = true;
	}

	public void DontMove()
	{
		canMove = false;
	}
}
