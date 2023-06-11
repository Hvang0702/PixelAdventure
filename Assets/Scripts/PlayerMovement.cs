using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    private Rigidbody2D rb;
    private BoxCollider2D coll; //for collisions
    private SpriteRenderer sprite;
    private Animator anim; //This is for the animation

    private float dirX = 0f; //Horizontal movement //Does not need to be set to 0 but it won't hurt
    [SerializeField] private float moveSpeed = 7f; //SerializeField means we can edit the moveSpeed in Unity
    [SerializeField] private float jumpForce = 14f; //SerializeField means we can edit the jumpForce in Unity in menu
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField]private float fallMultiplier = 2.5f;
    [SerializeField]private float lowJumpMultiplier = 2f;

   // private Vector3 respawnPoint;
    //public GameObject fallDetector;

    private enum MovementState { idle, running, jumping, falling  } //for the animator tab

    [SerializeField] private AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
       // respawnPoint = transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        dirX = Input.GetAxisRaw("Horizontal"); //for moving side to side
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y); //use rb.velocity.y for y value

        

        if(Input.GetButtonDown("Jump") && IsGrounded()) //Jump button
        {
            jumpSoundEffect.Play(); //when we jump the audio will play for jumping
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimation();
    }

    private void UpdateAnimation()
    {

        MovementState state;

        if (dirX > 0f) //if the horizontal direction is greater than 0
        {
            state = MovementState.running; //if running
            sprite.flipX = false; //do not flip the sprite if running right
        }
        else if (dirX < 0f) //if the horizontal direction is less than 0
        {
            state = MovementState.running; //if running
            //Flip the sprite if running left
            sprite.flipX = true;
        } 
        else
        {
            state = MovementState.idle; //if running
        }

        if(rb.velocity.y > .1f && !Input.GetButton("Jump")) //if jumping up
        {
            state = MovementState.jumping;
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            //If tapping spacebar the player jumps lower
            //If holding spacebar the player jumps higher
        }
        else if (rb.velocity.y < -.1f) //if falling
        {
            state = MovementState.falling;
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            //The code above with rb.velocity lets the player fall faster down to the ground
           

        }
        anim.SetInteger("state", (int)state); //be careful with the spelling has to be the same as in the animator tab
    }

    //Create a private method for collisions with ground and only one jump per a time
    //if standing on ground == true
    //if in the air == false
    private bool IsGrounded()
    {
        //This creates a box around our player 
       return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }


}
