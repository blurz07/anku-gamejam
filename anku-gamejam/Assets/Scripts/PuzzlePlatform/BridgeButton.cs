using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeButton : MonoBehaviour
{
    public bool isPress;
    private Animator animator;
    [SerializeField] private buttonsliding buttonsliding;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Box"))
        {
            isPress = true;
            buttonsliding.ToggleBridge(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Box")){ 
            isPress = false;
            buttonsliding.ToggleBridge(false);
        }
    }

    private void Update()
    {
        if (isPress)
        {
            animator.SetBool("animbool", true);
        }
        else
        {
            animator.SetBool("animbool", false);
        }
    }
}
