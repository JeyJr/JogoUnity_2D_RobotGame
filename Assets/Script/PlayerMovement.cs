using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb2D;
    Animator anim;



    float speed = 3;
    float horizontalMove;
    bool isRunning; //control anim idle-run


    public bool isJumping;
    public float jumpStrength = 2;
    public bool doubleJump;

    public LayerMask groundLayer;
    public Transform groundCheckStart;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");


        Jump();
        anim.SetBool("isRunning", isRunning);
        anim.SetBool("isJumping", isJumping);
    }

    //Padrão: a cada 0,02 segundos
    private void FixedUpdate()
    {
        BasicMovement();
        CheckGround();
    }

    void BasicMovement()
    {
        if (horizontalMove < 0)
        {

            transform.Translate(Vector2.left * speed * Time.deltaTime);
            GetComponent<SpriteRenderer>().flipX = true;

            isRunning = true;
        }
        else if (horizontalMove > 0)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            GetComponent<SpriteRenderer>().flipX = false;

            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && ! isJumping)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpStrength);
        }
        else if(Input.GetButtonDown("Jump") && isJumping && !doubleJump) 
        {
            doubleJump = true;
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpStrength);
        }
    }

    void CheckGround()
    {
        //docs.unity3d.com/ScriptReference/Physics2D.Raycast.html
        RaycastHit2D groundHit = Physics2D.Raycast(groundCheckStart.transform.position, transform.TransformDirection(Vector2.down), 0.2f, groundLayer);

        Debug.DrawRay(groundHit.point, transform.TransformDirection(Vector2.down), Color.red);

        if (groundHit.collider != null) {
            isJumping = false;
            doubleJump = false;
        }
        else isJumping = true;
    }
}
