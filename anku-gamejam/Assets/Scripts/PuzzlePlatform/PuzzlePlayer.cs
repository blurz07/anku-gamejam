using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PuzzlePlayer : MonoBehaviour
{
    private Rigidbody2D rb;
    public float MovementSpeed = 0.01f;
    public float MovementSpeed2 = 1f;
    private Vector2 Movement = Vector2.zero;
    private Animator animator;
    private bool inLadder;
    public float jumpForce = 2f;
    [SerializeField]private float maxHorizontalSpeed;
    [SerializeField] private float maxVerticalSpeed;
    private bool isGround;
    public GameObject GameOver;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            animator.SetBool("isMoving", true);
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            gameObject.transform.rotation = Quaternion.Euler(180f, 0f, 180f);
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
        if (Input.GetAxisRaw("Vertical") < 0)
        {
            animator.SetBool("isMoving", true);
        }
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            animator.SetBool("isMoving", true);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGround)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            }

        }
        if (inLadder)
        {

            Movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            transform.position = transform.position;
            rb.velocity = new Vector3(0f,0f, 0f);
            transform.position += new Vector3(Input.GetAxisRaw("Horizontal")*MovementSpeed2*Time.deltaTime, Input.GetAxisRaw("Vertical") * MovementSpeed2 * Time.deltaTime, 0f);
        }
        else
        {
            Movement = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        }
        animator.SetFloat("speed", Movement.x);
       
    }

    private void FixedUpdate()
    {
        if(rb.velocity.x < 2f && rb.velocity.x > -2f)
        {
            rb.velocity += Movement * MovementSpeed * Time.fixedDeltaTime;
        }
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x,-maxHorizontalSpeed, maxHorizontalSpeed), Mathf.Clamp(rb.velocity.y, -maxVerticalSpeed, maxVerticalSpeed));
        


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        
        if (collision.gameObject.CompareTag("Ladder"))
        {
            inLadder = true;
            rb.gravityScale = 0f;
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            inLadder = false;
            rb.gravityScale = 0.5f;
        }
        if (collision.gameObject.CompareTag("Bg"))
        {
            GameOver.gameObject.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            animator.SetBool("isJump", false);
        }
        
        if (collision.gameObject.CompareTag("spike"))
        {
            Destroy(gameObject);
            GameOver.gameObject.SetActive(true);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isGround = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isGround = false;
        }
    }
}

