using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharactherController : MonoBehaviour
{
    public float speed = 2.8f;
    private Rigidbody2D r2d;
    //private Animator _animator;
    private Vector3 characterPos;
    public Canvas canvas;

    
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>(); 
        //_animator = GetComponent<Animator>();
        characterPos = transform.position;
        
    }

    public void FixedUpdate()
    {
        //r2d.velocity = new Vector2(speed, 0f);
    }

    
    void Update()  
    {
        characterPos = new Vector3(characterPos.x + (Input.GetAxis("Horizontal") * speed * Time.deltaTime), characterPos.y);
        transform.position = characterPos; 
        /* if(Input.GetAxis("Horizontal") == 0.0f)
        {
            _animator.SetFloat("speed", 0.0f);
        }
        else
        {
            _animator.SetFloat("speed", speed);
        }
        */
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("bomb"))
        {
            Destroy(gameObject);
            Time.timeScale = 0;
            canvas.gameObject.SetActive(true);
        }
    }
}
