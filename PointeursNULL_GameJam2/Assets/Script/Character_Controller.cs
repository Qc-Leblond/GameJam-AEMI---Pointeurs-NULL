using UnityEngine;
using System.Collections;

public class Character_Controller : MonoBehaviour 
{
    private float SpeedForce;
    private float MaxSpeed;
    private float JumpForce;

    private Transform GroundCheck;
    private bool onGround;
    private float groundCheckRadius = 0.1f;

    private bool Button1Down;
    private bool Button2Down;

    void Awake()
    {
        SpeedForce = 300f;
        MaxSpeed = 5f;
        JumpForce = 10000f;

        GroundCheck = transform.FindChild("GroundCheck");
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        Mouvement(h);
    }

    void Update()
    {
        onGround = Physics2D.OverlapCircle(GroundCheck.position, groundCheckRadius, 1 << LayerMask.NameToLayer("Platform"));

        if (Input.GetButtonDown("Jump") && onGround)
        {
            rigidbody2D.AddForce(new Vector2(0f, JumpForce));
        }
    }

    void Mouvement(float h)
    {
        if (rigidbody2D.velocity.x < MaxSpeed)
        {
            
        }
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
