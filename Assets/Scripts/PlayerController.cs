using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;

    public bool canMove = true;
    public float speed;
    public float jumpPower;
    private bool isGrounded = true;

    public static PlayerController instance;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }
        
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (canMove) {
            Move();
        }
    }

    private void Move() {

        float moveX = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2 (moveX * speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            anim.SetBool("jump", true);
            Jump();
            anim.SetBool("jump", false);
        }

        //ANIMATIONS
        if (rb.velocity.x > 1f || rb.velocity.x < -1f)
        {
            anim.SetFloat("moveX", 1);
        }
        else
        {
            anim.SetFloat("moveX", 0);
        }

        //FLIP
        if (moveX < 0.0f)
        {
            sr.flipX = false;
        } 
        else if(moveX > 0.0f)
        {
            sr.flipX = true;
        }
    }

    public void Jump()
    {
        rb.velocity = Vector2.up * jumpPower;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
