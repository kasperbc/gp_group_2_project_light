using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    /// Give a set of serialized field to set the walking and running speed, and the jumping & double jumping power
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float jumpPower;
    [SerializeField] private float doubleJumpPower;

    private Rigidbody2D body; /// Set a rigidbody for the player
    private Animator animator; /// Set an animator indicator for the player                              
    private bool isGrounded; /// Check if the player is on the ground. "Jump" can only be started when the player is on the ground                          
    private bool doubleJump; /// Check if the player is double jumping

    [SerializeField] public bool isFlying;
    public float flyingSpeed = 5f; // Speed of flying movement

    // Awake is called before start and quicker than start
    private void Awake()
    {
       // Link your scripte with the unity components
       body = GetComponent<Rigidbody2D>(); /// Link the player movement to the Regidbody2D component
       animator = GetComponent<Animator>(); /// Link the animator to the animator component
    }

    // Update is called once per frame
    private void Update()
    {

        if (isFlying)
        {
            FlyingMovement();
        }
        else
        {
            GroundMovement();
        }
    }

    // method to check if the player is on the ground
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.tag == "Ground") /// if the player collides with an object with the tag "ground" (In our scene, the GroundTilemap is set with the tag "ground")
        {
            isGrounded = true; /// Then the method checking whether the player is on the ground is set to be true
        }
    }

    private void GroundMovement()
    {
        body.gravityScale = 1; //enables the gravity for the character
        // Get the horizontal movement for the player by pressing A/D or left/right
        float horizontalInput = Input.GetAxis("Horizontal");

        // Walk & run (movement & animator)
        if (!(horizontalInput != 0)) /// If you're not moving, set the animator to default status, which is "idle"
        {
            animator.SetBool("isWalking", false); /// You're not walking
            animator.SetBool("isRunning", false); /// You're not running
        }
        else if ((horizontalInput != 0) && !(Input.GetKey(KeyCode.LeftShift))) /// If you're moving and not pressing the shift button, change the animator to "walking"
        {
            animator.SetBool("isWalking", true); /// You're walking
            animator.SetBool("isRunning", false); /// You're not running
            body.velocity = new Vector2(Input.GetAxis("Horizontal") * walkSpeed, body.velocity.y); /// you're only moving on X axis, the movement = your moving direction * walk speed, and Y axis doesn't change
        }
        else if ((horizontalInput != 0) && (Input.GetKey(KeyCode.LeftShift))) /// If you're moving and pressing the shift button, change the animator to "running"
        {
            animator.SetBool("isWalking", false); /// You're not walking
            animator.SetBool("isRunning", true); /// You're running
            body.velocity = new Vector2(Input.GetAxis("Horizontal") * runSpeed, body.velocity.y); /// You're only moving on X axis, the movement = your moving direction * run speed, and Y axis doesn't change
        }

        // Jump & double jump (movement & animator)
        /// Aim of the code: The player can jump when pressing "space", and can double jump when pressing "space" again, but can only double jump once
        /// The condition for jumping is the player needs to be on the ground; the condition for double jumping is the "doubleJump" status needs to be false
        /// The code loop 1 is to make the player jump + double jump
        /// The code loop 2 is to avoid the player from jumping again: he is not standing on the ground, so he can't jump; and the "doubleJump" value is true, so he can't double jump
        /// If there's loop 3,4,5...they will be the same as loop 2, until the player reaches the ground, then the code will go back from loop 1

        if (isGrounded) /// Loop 1: you are standing on the ground
                        /// Loop 2: you are not standing on the ground, so the condition is not met
        {
            doubleJump = false; /// Loop 1: you can't double jump
                                /// Loop 2: this line won't be executed, doubleJump is still true
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (Input.GetKey(KeyCode.Space) && isGrounded) /// Loop 1: if you press "space" when standing on the ground, the player will start to jump
                                                           /// Loop 2: you are not standing on the ground, so the conditions are not met
            {
                body.velocity = new Vector2(body.velocity.x, jumpPower); /// Loop 1: your X axis doesn't change, only moving on Y axis, the movement = jump power
                                                                         /// Loop 2: this line won't be executed, you can't jump again
                isGrounded = !isGrounded; /// Loop 1: you leave the ground
                                          /// Loop 2: this line won't be executed, you're not on the ground
            }
            else if (Input.GetKeyDown(KeyCode.Space) && !doubleJump) /// Loop 1: if you press "space" again in the air for the first time, double jump is false, so the conditions are met
                                                                     /// Loop 2: doubleJump is true, so the conditions are not met
            {
                body.velocity = new Vector2(body.velocity.x, doubleJumpPower); /// Loop 1: your X axis doesn't change, only moving on Y axis, the movement = double jump power
                                                                               /// Loop 2: this line won't be executed, you can't jump again
                doubleJump = !doubleJump; /// Loop 1: double jump will be changed to true after the first double jump in the air, then you go back for the second loop
                                          /// Loop 2: this line won't be executed, doubleJump is still true
                // Debug.Log(doubleJump);
                // Debug.Log(isGrounded);
            }
        }

        // Set animator parameters
        animator.SetBool("isGrounded", isGrounded); /// Ask the animator condition "isGrounded" to always check whether the player is on the ground or not, so that it can change to "jump" animation

        // Flip player when moving left-right
        if (horizontalInput > 0f) /// If the horizontal movement is positive on the X axis, which means the player is moving towards right
        {
            transform.localScale = Vector3.one; /// Then the player sprite stays in the default status, facing left
        }
        else if (horizontalInput < 0f) /// If the horizontal movement is negative on the X axis, which means the player is moving towards left
        {
            transform.localScale = new Vector3(-1, 1, 1); /// Then the player sprite should be flipped to facing left
        }
    }

    private void FlyingMovement()
    {
        body.gravityScale = 0; //disables the gravity for the character

        // Get the horizontal movement for the player by pressing A/D or left/right
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        body.velocity = new Vector2(horizontalInput, verticalInput) * flyingSpeed;

    }
}
