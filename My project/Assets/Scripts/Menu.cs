using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public GameObject startMenu, creditsMenu;
    public void PlayButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void CreditsButton()
    {
        creditsMenu.SetActive(true);
        startMenu.SetActive(false);
    }

    public void BackButton()
    {
        creditsMenu.SetActive(false);
        startMenu.SetActive(true);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
