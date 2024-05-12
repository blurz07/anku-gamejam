using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class storyController : MonoBehaviour
{
    public Button continueButton;

    void Start()
    {
        continueButton.onClick.AddListener(ShowNextPage);
    }

    void ShowNextPage()
    {
        SceneManager.LoadScene(sceneBuildIndex: 5);
    }
}
