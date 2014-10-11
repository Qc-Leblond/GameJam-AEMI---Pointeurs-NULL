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

    void Awake()
    {
        SpeedForce = 250f;
        MaxSpeed = 5f;
        JumpForce = 10000f;

        GroundCheck = transform.FindChild("GroundCheck");
    }

    void Update()
    {
        onGround = Physics2D.OverlapCircle(GroundCheck.position, groundCheckRadius, 1 << LayerMask.NameToLayer("Platform"));
        float h = Input.GetAxis("Horizontal");

        if (rigidbody2D.velocity.x < MaxSpeed)
        {
            rigidbody2D.AddForce(new Vector2(SpeedForce * h, 0f));
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            rigidbody2D.AddForce(new Vector2(0f, JumpForce));
        }
    }

}
