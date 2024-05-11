using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StoryBoardController : MonoBehaviour
{
    public Image[] comicPages;
    public Button startButton;
    public Button continueButton;

    private int currentPageIndex = 0;

    void Start()
    {
        // ilk sayfay� g�ster
        startButton.onClick.AddListener(StartComic);

        // bir sonraki sayfay� g�ster
        continueButton.onClick.AddListener(ShowNextPage);

        continueButton.gameObject.SetActive(false);

    }


    void StartComic()
    {

        startButton.gameObject.SetActive(false);
        comicPages[currentPageIndex].gameObject.SetActive(false);
        currentPageIndex++;
        comicPages[currentPageIndex].gameObject.SetActive(true);

        continueButton.gameObject.SetActive(true);
    }

    void ShowNextPage()
    {
        // Mevcut sayfan�n g�r�n�rl���n� kapat
        comicPages[currentPageIndex].gameObject.SetActive(false);

        // Bir sonraki sayfay� g�ster
        currentPageIndex++;
        if (currentPageIndex < comicPages.Length)
        {
            comicPages[currentPageIndex].gameObject.SetActive(true);
        }
        else if (currentPageIndex == 8)
        {
            continueButton.gameObject.SetActive(false);
            SceneManager.LoadScene(sceneBuildIndex: 1);
        }
    }
}
