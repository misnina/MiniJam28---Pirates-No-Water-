using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;
    public float moveX;

    public bool canMove = true;
    public float speed;
    public float jumpPower;
    private bool isGrounded = true;
    private bool doubleJump = true;

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

    private void FixedUpdate()
    {
        if (canMove) {
            Move();
        }
    }

    private void Move() {

        moveX = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2 (moveX * speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump(1f);
            doubleJump = true;   
        }
        else if (Input.GetButtonDown("Jump") && doubleJump && GameManager.instance.hasFollower)
        {
            Jump(0.8f);
            doubleJump = false;
        }

        if (Input.GetKeyUp("q")) {
            anim.SetTrigger("kiss");
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

    public void Jump(float jumpMultiplier)
    {
        rb.velocity = Vector2.up * (jumpPower * jumpMultiplier);
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
