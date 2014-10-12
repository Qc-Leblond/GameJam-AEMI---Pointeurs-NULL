using UnityEngine;
using System.Collections;

public class Character_Controller : MonoBehaviour
{
	public bool canMove;
    private float maxSpeed = 10f;
    private float jumpSpeed = 1000f;
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

    public LayerMask ground;

    [SerializeField]
    bool grounded = false;

    public Transform groundCheck;
    float groundRadius = 0.2f;

    void Start()
    {
        animator = GetComponent<Animator>();
        if (isHuman) ControllerActive = "P1_";
        else ControllerActive = "P2_";

        if (isHuman)
        {
            horizontal = "P2Horizontal";
            jump = "P2Jump";
            powerUp1 = "P2PowerUp1";
            powerUp2 = "P2PowerUp2";
        }
        else
        {
            horizontal = "Horizontal";
            jump = "Jump";
            powerUp1 = "PowerUp1";
            powerUp2 = "PowerUp2";
        }

    }

    void Update()
    {
        DpadButton();
        Triggers();

      /*  if (Input.GetAxis(horizontal) < 0 && canMove)
            this.transform.localScale = (new Vector3(-5, 5, 1));

        if (Input.GetAxis(horizontal) > 0 && canMove)
            this.transform.localScale = (new Vector3(5, 5, 1));


        if ((Mathf.Abs(moveDirection.x) > 0.5f || Mathf.Abs(moveDirection.y) > 0.5f) && canMove)
            animator.SetFloat("Speed", Mathf.Sqrt((moveDirection.x*moveDirection.x)+(moveDirection.y*moveDirection.y)));
        else
            animator.SetFloat("Speed",0.0f);*/

        if (grounded && Input.GetButtonDown(jump))
        {
            animator.SetBool("Jump", false);
            rigidbody2D.AddForce(new Vector2(0, jumpSpeed));
        }


    }

    void FixedUpdate()
    {
       /* Controller = GetComponent<CharacterController>();
		if (Controller.isGrounded && canMove == true) 
        {
			// We are grounded, so recalculate
			// move direction directly from axes
            animator.SetBool("Jump", false);
			moveDirection = new Vector3(Input.GetAxis(horizontal), 0, 0);
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= Speed;

            if (Input.GetButton(jump) && canMove)
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
        if(!canMove)
            moveDirection = new Vector3(0,0,0);*/
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, ground);
        animator.SetBool("Jump", grounded);



        float move = Input.GetAxis(horizontal);
        if(canMove)
        {
            rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);
            animator.SetFloat("Speed", Mathf.Abs(move));
        }
        if (move > 0 && !facingRight)
            flip();
        else if (move < 0 && facingRight)
            flip();
    }

    void flip()
    {
        facingRight = !facingRight;
        Vector3 scaling = transform.localScale;
        scaling.x *= -1;
        transform.localScale = scaling;
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
