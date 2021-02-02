using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    private bool moving;
    private float moveDir;
    public float hopHeight;
    public float speed;
    [SerializeField] private GameObject groundCheck;
    public LayerMask ground;
    public int hopCounter;
    private bool inAir;
    Animator animator;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        hopCounter = 0;
        moving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Horizontal") && Physics2D.OverlapCircle(groundCheck.transform.position, 0.1f, ground))
        {
            moving = true;
            moveDir = Input.GetAxisRaw("Horizontal");
            hopCounter++;
        }


        if (Mathf.Abs(Input.GetAxis("Horizontal")) == 1 && !Physics2D.OverlapCircle(groundCheck.transform.position, 0.1f, ground))
        {
            
            inAir = true;
            moveDir = Input.GetAxisRaw("Horizontal");
        }

        if (Physics2D.OverlapCircle(groundCheck.transform.position, 0.1f, ground))
        {
            animator.SetFloat("Speed", 0);
        } else
        {
            animator.SetFloat("Speed", 1);
        }

        switch (Input.GetAxisRaw("Horizontal"))
        {
            case -1:
                spriteRenderer.flipX = true;
                break;
            case 1:
                spriteRenderer.flipX = false;
                break;
        }
        

    }

    private void FixedUpdate()
    {

        if (moving)
        {
            Move();
        }

        if (inAir)
        {
            AirMove();
        }

    }

    private void Move()
    {
        
        if (hopCounter > 2)
        {
            moving = false;
            rb.AddForce(new Vector2(((moveDir * speed) * 2) * Time.deltaTime, (hopHeight * 3) * Time.deltaTime), ForceMode2D.Impulse);
            FindObjectOfType<AudioManager>().Play("ScarecrowJumpBig");
            moveDir = 0;
            hopCounter = 0;
        }
        else {
            moving = false;
            rb.AddForce(new Vector2((moveDir * speed) * Time.deltaTime, hopHeight * Time.deltaTime), ForceMode2D.Impulse);
            FindObjectOfType<AudioManager>().Play("ScarecrowJump");
            moveDir = 0;
            
            
            }  


        
    }

    private void AirMove()
    {
        
        rb.AddForce(new Vector2(((moveDir * speed) / 40) * Time.deltaTime, 0), ForceMode2D.Impulse);
        moveDir = 0;
    }

}

