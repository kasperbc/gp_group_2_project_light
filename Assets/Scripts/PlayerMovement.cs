using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movespeed;
    [SerializeField] private float runspeed;
    [SerializeField] private float jumpspeed;
    private Rigidbody2D body;
    private Animator animator;
    private bool isRunning;
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
        // Walk movement
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * movespeed, body.velocity.y);

        // Run movement
        if (Input.GetKey(KeyCode.LeftShift) && isGrounded)
        {
            Run();
        }

        // Jump movement
        if(Input.GetKey(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

        // Flip player when moving left-right
        if (horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        // Set animator parameters
        animator.SetBool("isWalking", horizontalInput != 0);
        animator.SetBool("isRunning", !isRunning);
        animator.SetBool("isGrounded", isGrounded);
    }

    private void Run()
    {
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * runspeed, body.velocity.y);
        animator.SetTrigger("Run");
        isRunning = true;
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
