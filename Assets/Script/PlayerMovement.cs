using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb2D;
    
    float speed = 5;
    float horizontalMove;

    public bool isJumping;
    public bool doubleJumping;
    float jumpStrength = 500;

    public LayerMask groundLayer;
    public Transform groundCheckStart;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        BasicMovement();
        CheckGround();
        if(! isJumping) JumpMovement();
    }

    void BasicMovement()
    {
        horizontalMove = Input.GetAxis("Horizontal");

        if(horizontalMove < 0)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            //transform.eulerAngles = new Vector3(0, 0, 0);
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if(horizontalMove > 0)
        {
            transform.Translate(Vector2.right * speed * Time.fixedDeltaTime);
            //transform.eulerAngles = new Vector3(0, 180f, 0);
            GetComponent<SpriteRenderer>().flipX = false;
        }
        
    }
    void JumpMovement()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb2D.AddForce(new Vector2(rb2D.velocity.x, jumpStrength));
        }
    }
    void CheckGround()
    {
        //docs.unity3d.com/ScriptReference/Physics2D.Raycast.html
        RaycastHit2D groundHit = Physics2D.Raycast(groundCheckStart.transform.position, transform.TransformDirection(Vector2.down), 0.1f, groundLayer);

        Debug.DrawRay(groundHit.point, transform.TransformDirection(Vector2.down), Color.red);

        if (groundHit.collider != null) isJumping = false;
        else isJumping = true;
    }
}
