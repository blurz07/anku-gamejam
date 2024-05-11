using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Collision : MonoBehaviour
{
    public Text scoreText;
    private int puan = 0;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.gameObject.CompareTag("fruits"))
            {
                Destroy(collision.gameObject);
                puan += 10;
                checkScore();
            }      
    }

    private void Update()
    {
        scoreText.text = puan.ToString();
    }

    private void checkScore()
    {
        if (puan >= 100)
        {
            Debug.Log("you won");
        }
    }

}
