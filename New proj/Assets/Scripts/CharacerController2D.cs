using UnityEngine;

public class CharacerController2D : MonoBehaviour
{
    public float jumpForce;
    public float speed;
    public float smooth;
    Rigidbody2D rb2d;
    bool facingRight = true;
    public LayerMask groundLayer;
    Animator animator;
    public bool isGrounded;
    public Transform groundcheck;
    public LayerMask whatisGround;
    public float checkRadius;
    private float x;


    // Start is called before the first frame update
    void Start()
    {
        isGrounded = true;
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();

    }



    private void Update()
    {
        //get input 
        x = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
            rb2d.velocity = new Vector2(0f, jumpForce);
        }

        isGrounded = Physics2D.OverlapCircle(groundcheck.position, checkRadius, whatisGround);

        if (rb2d.velocity.y == 0)
        {
            animator.SetBool("Jumping", false);
        }
        else
        {
            animator.SetBool("Running", false);
            animator.SetBool("Jumping", true);
        }

        //if the input is moving the player right and the player is facing left...
        if (x > 0 && !facingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (x < 0 && facingRight)
        {
            // ... flip the player.
            Flip();
        }

    }



    // Update is called once per frame
    void FixedUpdate()
    {

        if (x != 0)
        {
            animator.SetBool("Running", true);
        }
        else
        {
            animator.SetBool("Running", false);
        }

        //update the player's velocity
        Vector2 Targetvelocity = new Vector2(x * speed, rb2d.velocity.y);

        rb2d.velocity = Vector2.SmoothDamp(rb2d.velocity, Targetvelocity, ref Targetvelocity, Time.deltaTime * smooth);



    }
    void Flip()
    {
        //Invert the facingRight variable
        facingRight = !facingRight;

        //Flip the Character
        Vector2 scale = transform.localScale;

        scale.x *= -1;

        transform.localScale = scale;
    }
}