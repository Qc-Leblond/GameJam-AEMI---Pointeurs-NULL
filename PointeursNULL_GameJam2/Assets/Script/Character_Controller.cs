using UnityEngine;
using System.Collections;

public class Character_Controller : MonoBehaviour
{
	public bool canMove;
    private float maxSpeed = 25f;
    private float jumpSpeed = 1750f;
    private float Gravity = 20f;
    public bool isHuman;
    protected Animator animator;

    public bool transportObjective = false;

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

    public bool fighting = false;
	private AudioClip rpc;
    
    public LayerMask ground;
    public LayerMask zombie;
    public LayerMask humain;

    int ZombieInput = -1;
    int HumanInput = -1;
    bool ZombieAJoue = false;
    bool HumanAJoue = false;

    GameObject zombieObj;
    GameObject humanObj;
/*
    rpc = Resources.Load ("rpc") as AudioClip;
	this.gameObject.AddComponent("rpc");
	audio.clip = rpc;
	audio.Play();  */


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
        Physics2D.IgnoreLayerCollision(11, 11);
        Physics2D.IgnoreLayerCollision(12, 12);
        if(isHuman)
        {
            maxSpeed = 30f;
        }

    }

    void Update()
    {
        DpadButton();

      /*  if (Input.GetAxis(horizontal) < 0 && canMove)
            this.transform.localScale = (new Vector3(-5, 5, 1));

        if (Input.GetAxis(horizontal) > 0 && canMove)
            this.transform.localScale = (new Vector3(5, 5, 1));


        if ((Mathf.Abs(moveDirection.x) > 0.5f || Mathf.Abs(moveDirection.y) > 0.5f) && canMove)
            animator.SetFloat("Speed", Mathf.Sqrt((moveDirection.x*moveDirection.x)+(moveDirection.y*moveDirection.y)));
        else
            animator.SetFloat("Speed",0.0f);*/

        if (grounded && Input.GetButtonDown(jump) && canMove)
        {
            animator.SetBool("Jump", false);
            rigidbody2D.AddForce(new Vector2(0, jumpSpeed));
        }

        if(fighting)
        {
            Fight();
            GameObject.FindGameObjectWithTag("GameController").GetComponent<Timer>().TimerActive = false;


        }
        else
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<Timer>().TimerActive = true;
        }

        if(gameObject.layer == 12 && GetComponent<Human_Handling>().Incapacitated && grounded)
        {
            gameObject.rigidbody2D.isKinematic = true;
        }

        if (transportObjective)
        {
            maxSpeed = 20f;
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
            if (move > 0 && !facingRight)
                flip();
            else if (move < 0 && facingRight)
                flip();
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(gameObject.layer ==11 && other.gameObject.layer == 12)
        {
            fighting = true;
            zombieObj = this.gameObject;
            humanObj = other.gameObject;
        }
    }



    void flip()
    {
        facingRight = !facingRight;
        Vector3 scaling = transform.localScale;
        scaling.x *= -1;
        transform.localScale = scaling;
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


    void Fight()
    {
        DontMove();

        if (!ZombieAJoue)
        {
            if (Input.GetButton("Roche"))
            {
                Debug.Log("ZR");
                ZombieInput = 1;
                ZombieAJoue = true;
            //    RPCZombie = "Pret";
            }
            else if (Input.GetButton("Papier"))
            {
                Debug.Log("ZP");

                ZombieInput = 2;
                ZombieAJoue = true;
            //    RPCZombie = "Pret";
            }
            if (Input.GetButton("Ciseaux"))
            {
                Debug.Log("ZC");

                ZombieInput = 3;
                ZombieAJoue = true;
             //   RPCZombie = "Pret";
            }
        }
        if (!HumanAJoue)
        {
            if (Input.GetButtonDown("P2Roche"))
            {
                Debug.Log("HR");

                HumanInput = 1;
                HumanAJoue = true;
              //  RPCHumain = "Pret";
            }
            else if (Input.GetButtonDown("P2Papier"))
            {
                Debug.Log("HP");

                HumanInput = 2;
                HumanAJoue = true;
                //RPCHumain = "Pret";
            }
            if (Input.GetButtonDown("P2Ciseaux"))
            {
                Debug.Log("HC");

                HumanInput = 3;
                HumanAJoue = true;
                //RPCHumain = "Pret";
            }
        }
        if (ZombieAJoue && HumanAJoue)
        {
            if ((HumanInput) % 3 + 1 == ZombieInput)
            {
                Debug.Log("ZG");
                //ZombieGagne = true;
                zombieObj.GetComponent<Character_Controller>().Move();
                //GameObject.FindGameObjectWithTag("Human").GetComponent<Human_Handling>().GetBitten();
                //Debug.Log(humanObj.transform.GetChild(1).name);
                if (GameObject.FindGameObjectWithTag("MainCamera").transform.parent = humanObj.transform)
                {
                    GameObject.FindGameObjectWithTag("MainCamera").transform.parent = null;
                }
                humanObj.GetComponent<Human_Handling>().GetBitten();
                Debug.Log(humanObj.GetComponent<Human_Handling>().Incapacitated);

                fighting = false;
            }
            else if ((ZombieInput) % 3 + 1 == HumanInput)
            {
                Debug.Log("HG");

                //HumainGagne = true;
                humanObj.GetComponent<Character_Controller>().Move();

                if (GameObject.FindGameObjectWithTag("MainCamera").transform.parent = zombieObj.transform)
                {
                    GameObject.FindGameObjectWithTag("MainCamera").transform.parent = null;
                }
                Destroy(zombieObj);
                //Destroy(GameObject.FindGameObjectWithTag("Zombie"));
                fighting = false;

            }
            else
            {
                ZombieInput = -1; ZombieAJoue = false;
                HumanInput = -1; HumanAJoue = false;
                //RPCHuman = "Draw";
                //RPCZombie = "Draw";
            }
            if(!fighting)
            {
                ZombieInput = -1; ZombieAJoue = false;
                HumanInput = -1; HumanAJoue = false;
            }
        }
    }
}
