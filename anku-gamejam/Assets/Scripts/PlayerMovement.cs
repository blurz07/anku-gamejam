using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float MovementSpeed = 450f;
    private Vector2 Movement = Vector2.zero;
    private bool skill;
    private Animator animator;
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            animator.SetBool("isMoving", true);
        }
        else if(Input.GetAxisRaw("Horizontal") > 0)
        {
            gameObject.transform.rotation = Quaternion.Euler(180f,0f,180f) ;
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
        Movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (Input.GetKey(KeyCode.Space) && skill == false)
        {
            StartCoroutine(Hizlan());
        }
        animator.SetFloat("speed", Movement.x);
        Debug.Log(Input.GetAxisRaw("Horizontal"));
        
    }
    private void FixedUpdate()
    {

        rb.velocity = Movement * MovementSpeed * Time.fixedDeltaTime;

    }
    IEnumerator Hizlan()
    {
        skill = true;
        MovementSpeed = 700f;
        yield return new WaitForSeconds(10f);
        MovementSpeed = 450f;
        yield return new WaitForSeconds(10f);
        skill = false;
    }
}
