using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //  Speed of the player
    public float speed = 1f;
    public float jumpForce = 1f;

    //  Is the player facing right (or left)
    public static bool facingRight = true;

    //  Just a handle for quick access
    private Rigidbody2D rb;
    private Animator anim;

    //  Used for checking ground
    public Transform groundCheck;       //  Position of foot.
    public float groundRadius = 0.2f;   //  Radius to check
    public LayerMask whatIsGround;      //  What to check agains.

    // Start is called before the first frame update
    void Start()
    {
        //  Look the rigidbody2D up.
        rb = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //  Get horizontal movement on left/right buttons
        float horiz = Input.GetAxis("Horizontal");

        //  Update velocity of object.
        Vector2 old_v = rb.velocity;
        old_v.x = speed * horiz;
        rb.velocity = old_v;

        //  Flip player if necessary
        if (facingRight && horiz < 0)
        {
            flip();
        }
        else if (!facingRight && horiz > 0)
        {
            flip();
        }

        //  Jump if used wants to.
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

        //  Sending the speed of player for animator
        anim.SetFloat("Speed", Mathf.Abs(this.rb.velocity.x));

        //  Are we standing on the ground?
        bool grounded = Physics2D.OverlapCircle(groundCheck.position,
                                                groundRadius,
                                                whatIsGround);
        anim.SetBool("Grounded", grounded);

    }

    //  Function for tuning arround. Practically flip on x axis.
    private void flip()
    {
        //  We will be facing the other direction
        facingRight = !facingRight;

        //  Reverse scale on X.
        Vector3 theScale = this.transform.localScale;
        theScale.x *= -1;
        this.transform.localScale = theScale;
    }
}
