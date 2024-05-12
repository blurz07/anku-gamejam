using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    private Button button;
    public Canvas canvas;
    public AudioSource audioSource;

    public void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(RestartGame);
        audioSource.Play();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        canvas.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
