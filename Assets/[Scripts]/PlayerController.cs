using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jump;
    
    [SerializeField]
    private bool isGrounded;
    
    public Transform playerPosition;
    
    [SerializeField] 
    private float radius;

    private float movement;
    
    private Rigidbody2D rb;
    
    [SerializeField]
    private LayerMask ground;

    [SerializeField] 
    private Animator animator;
    
    private SpriteRenderer sr;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Getting input from user and moving rigidbody times speed while keeping the Y velocity the same
    void FixedUpdate()
    {
        movement = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(movement * speed, rb.velocity.y);
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(playerPosition.position, radius, ground);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jump;
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKey(KeyCode.S) && Mathf.Abs(movement) == 0)
        {
            animator.SetBool("isDucking", true);
        }
        else if (Input.GetKeyUp(KeyCode.S) || Mathf.Abs(movement) > 0)
        {
            animator.SetBool("isDucking", false);
        }

        if (isGrounded)
        {
            animator.SetBool("isJumping", false);
        } 
        else if (!isGrounded)
        {
            animator.SetBool("isJumping", true);
        }

        if (movement > 0)
        {
            sr.flipX = false;
        }

        if (movement < 0)
        {
            sr.flipX = true;
        }
        
        animator.SetFloat("Speed", Mathf.Abs(movement));
    }
}
