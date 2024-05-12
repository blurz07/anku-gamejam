using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDoor : MonoBehaviour
{
    public KeyScript Key;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(Key.GetKey);
        if (collision.gameObject.CompareTag("Player") && Key.GetKey == true)
        {
            Destroy(gameObject);
        }
    }
}
