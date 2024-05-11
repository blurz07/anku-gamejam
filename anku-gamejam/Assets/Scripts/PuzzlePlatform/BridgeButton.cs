using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeButton : MonoBehaviour
{
    public bool isPress;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isPress = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isPress = false;
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
