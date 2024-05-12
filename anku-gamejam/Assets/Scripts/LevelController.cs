using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public Button continueButton;
    public Image[] comicPages;
    

    void Start()
    {
        continueButton.onClick.AddListener(ShowNextPage);
    }

    void ShowNextPage()
    {
        comicPages[1].gameObject.SetActive(true);
        continueButton.onClick.AddListener(ShowNextScene);
    }
    void ShowNextScene()
    {
        SceneManager.LoadScene(sceneBuildIndex: 3);
    }
}
