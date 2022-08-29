using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb2D;
    Animator anim;
    GameController gameController;

    float speed = 3;
    float horizontalMove;
    bool isRunning; //control anim idle-run

    [Space(5)]
    [Header("Jump Control")]
    public bool isJumping;
    public float jumpStrength = 2;
    public bool doubleJump;

    [Space(5)]
    [Header("Ground Check Control")]
    public LayerMask groundLayer;
    public Transform groundCheckStart;

    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(gameController.life > 0)
        {
            horizontalMove = Input.GetAxis("Horizontal");


            Jump();
            anim.SetBool("isRunning", isRunning);
            anim.SetBool("isJumping", isJumping);
        }
    }

    //Padrão: a cada 0,02 segundos
    private void FixedUpdate()
    {
        if(gameController.life > 0)
        {
            BasicMovement();
            CheckGround();

            if (transform.position.y < -10) gameController.TakeDMG(gameController.life);
        }
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
