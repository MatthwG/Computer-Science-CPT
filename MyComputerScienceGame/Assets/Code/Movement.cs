using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Movement : MonoBehaviour
{
    public Transform LaunchOffset;
    private float horizontal;
    
    public bool isGrounded = false;

    Animator animator;

    public AudioSource audioSource;
    public AudioClip fire;
    public Attack ProjectilePrefab;
    public HealthBar manabar;
    public Attack ProjectilePrefab2;
    private float speed = 8f;
    private float jumpingPower = 50f;
    private bool isFacingRight = true;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump")&& isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            isGrounded = false;
            animator.SetBool("isJumping", !isGrounded);
        }
        
        

        if (Input.GetButtonDown("Fire1")&& transform.localScale.x == 1.51f&&manabar.slider.value >=1)
        {
            
            audioSource.PlayOneShot(fire,1);
            Instantiate(ProjectilePrefab,LaunchOffset.position, transform.rotation);
            manabar.slider.value = manabar.slider.value - 5f;
        }
        if (Input.GetButtonDown("Fire1")&& transform.localScale.x == -1.51f&&manabar.slider.value >=1)
        {
            audioSource.PlayOneShot(fire,1);
            Instantiate(ProjectilePrefab2,LaunchOffset.position, transform.rotation);
            manabar.slider.value = manabar.slider.value - 5f;
        }
        Flip();
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        animator.SetFloat("xVelocity", Math.Abs(rb.velocity.x));
        animator.SetFloat("yVelocity", rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        isGrounded = true;
        animator.SetBool("isJumping", !isGrounded);
        
    }
    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
            
            
        }
        /*if (isFacingRight == true)
        {
            Speed = 4.5f;
        }
        if (isFacingRight == false)
        {
            Speed = -4.5f;
        }
        */
    }
}
