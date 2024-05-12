using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    public Transform player;
    public Transform teleport;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.position = teleport.position;
            player.rotation = teleport.rotation;
        }
    }
}
