using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PuzzlePlayer : MonoBehaviour
{
    private Rigidbody2D rb;
    public float MovementSpeed = 45f;
    private Vector2 Movement = Vector2.zero;
    private Animator animator;
    private bool inLadder;
     

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
        if (inLadder)
        {

            
            Movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        }
        else
        {
            Movement = new Vector2(Input.GetAxis("Horizontal"), 0f);
        }

        
        animator.SetFloat("speed", Movement.x);

    }

    private void FixedUpdate()
    {

        rb.velocity = Movement * MovementSpeed * Time.fixedDeltaTime;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            inLadder = true;
            rb.gravityScale = 0f;
            rb.freezeRotation = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            inLadder = false;
            rb.gravityScale = 1f;
            rb.freezeRotation = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("spike"))
        {
            Destroy(gameObject);
        }
    }

}

