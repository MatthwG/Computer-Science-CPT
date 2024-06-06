using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
public class Movement : MonoBehaviour
{
    public Transform LaunchOffset;
    private float horizontal;
    
    public bool isGrounded = false;
    public float Fire = 0f;
    Animator animator;
    public float fireindicator = 0f;
    public float openindicator = 0f;
    public AudioSource audioSource;
    public AudioClip fire;
    public Attack ProjectilePrefab;
    public HealthBar manabar;
    public Attack ProjectilePrefab2;
    private float speed = 8f;
    private float jumpingPower = 20f;
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
        if (transform.position.y <= -14f)
        {
            transform.position = new Vector3(-21.7f,-1.09f,-16.61f);
        }
        
        animator.SetFloat("Shoot", 0);
        fireindicator = 0f;
        openindicator = 0f;
        horizontal = Input.GetAxisRaw("Horizontal");
        
        if (Input.GetButtonDown("Jump")&& isGrounded)
        {
            animator.SetFloat("Turn", 0);
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            isGrounded = false;
            animator.SetBool("isJumping", !isGrounded);
            animator.SetFloat("Shoot", 0);
        }
        if (transform.position.x > 70f && transform.position.x < 76f)
        {
            animator.SetFloat("Turn", 1);
            openindicator = 1f;
            if (transform.position.x > 74f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }
        }
        

        if (Input.GetButtonDown("Fire1")&& transform.localScale.x == 1.51f&&manabar.slider.value >=1)
        {
            animator.SetFloat("Shoot", 1);
            
            animator.SetFloat("Turn", 0);
            audioSource.PlayOneShot(fire,1);
            Instantiate(ProjectilePrefab,LaunchOffset.position, transform.rotation);
            manabar.slider.value = manabar.slider.value - 5f;
            fireindicator = fireindicator + 1;
           
        }
        if (Input.GetButtonDown("Fire1")&& transform.localScale.x == -1.51f&&manabar.slider.value >=1)
        {
            //rb.velocity = new Vector2(rb.velocity.x + 500f, 1);
            animator.SetFloat("Shoot", 1);
            animator.SetFloat("Turn", 0);
            audioSource.PlayOneShot(fire,1);
            Instantiate(ProjectilePrefab2,LaunchOffset.position, transform.rotation);
            manabar.slider.value = manabar.slider.value - 5f;
            fireindicator = fireindicator + 1;
            
        }
        
        Flip();
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        animator.SetFloat("Turn", 0);
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
