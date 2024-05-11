using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float MovementSpeed = 450f;
    private Vector2 Movement = Vector2.zero;
    private bool skill;

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
    }


    void Update()
    {
        Movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (Input.GetKey(KeyCode.Space) && skill == false)
        {
            StartCoroutine(Hizlan());
        }
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
