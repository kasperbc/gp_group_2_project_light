using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float walkspeed;
    [SerializeField] private float runspeed;
    [SerializeField] private float jumpspeed;
    private Rigidbody2D body;
    private Animator animator;
    private bool isGrounded;
     
    private void Awake()
    {
       body = GetComponent<Rigidbody2D>();
       animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        // Run & walk movement
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (horizontalInput != 0)
            {
                animator.SetBool("isWalking", false);
                animator.SetBool("isRunning", true);
            }
            else
            {
                animator.SetBool("isWalking", false);
                animator.SetBool("isRunning", false);
            }
            body.velocity = new Vector2(Input.GetAxis("Horizontal") * runspeed, body.velocity.y);
        }
        else
        {
            if (horizontalInput != 0)
            {
                animator.SetBool("isWalking", true);
                animator.SetBool("isRunning", false);
            }
            else
            {
                animator.SetBool("isWalking", false);
                animator.SetBool("isRunning", false);
            }
            body.velocity = new Vector2(Input.GetAxis("Horizontal") * walkspeed, body.velocity.y);
        }
            
        // Jump movement
        if(Input.GetKey(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

        // Set animator parameters
        animator.SetBool("isGrounded", isGrounded);

        // Flip player when moving left-right
        if (horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpspeed);
        animator.SetTrigger("Jump");
        isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}
