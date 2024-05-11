using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text score;
    private int puan = 0;
    //public Transform animasyonSpawnPoint;
    //public Text animasyonText;
    //private Rigidbody2D animasyonrb;

    private void Start()
    {
        //Rigidbody2D animasyonrb = animasyonText.GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            puan += 10;
            UpdatePuan();
            //StartCoroutine(TextAnimation());
            
        }
        
    }
    private void Update()
    {
        score.text = puan.ToString();
    }
    void UpdatePuan()
    {
        score.text = puan.ToString();
    }
    /*IEnumerator TextAnimation()
    {
        Instantiate(animasyonText, animasyonSpawnPoint.position, animasyonSpawnPoint.rotation);
        animasyonText.SetParent(animasyonSpawnPoint, false);
        yield return new WaitForSeconds(10f);
        
    }*/
}
