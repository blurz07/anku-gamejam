using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI score;
    private int puan = 0;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("point"))
        {
            puan += 10;
            UpdatePuan();
            Destroy(collision.gameObject);
        }
        
    }
    private void Update()
    {
        score.text = puan.ToString();
    }
    void UpdatePuan()
    {
        score.text = puan.ToString();
        if (puan >= 70)
        {
            SceneManager.LoadScene(4);
        }
    }

    
}
