using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Collision : MonoBehaviour
{
    public Text scoreText;
    private int puan = 0;
    public AudioSource audioSource;

    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.gameObject.CompareTag("fruits"))
            {
                Destroy(collision.gameObject);
                puan += 10;
                checkScore();
                audioSource.Play();
            }      
    }

    private void Update()
    {
        scoreText.text = puan.ToString();
    }

    public void checkScore()
    {
        if (puan >= 100)
        {
            SceneManager.LoadScene(2);
        }
    }

}
