using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    public bool GetKey;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        GetKey = true;
        Destroy(gameObject);

    }
}
