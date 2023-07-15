using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public AudioClip menuSelect;
    public AudioSource audioSource;

    private void Update()
    {
        if (SoundManager.instance.BGM.isPlaying)
        {
            audioSource.mute = true;
        }
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 1;
    }

    public GameObject startMenu, creditsMenu;
    public void PlayButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void CreditsButton()
    {
        creditsMenu.SetActive(true);
        startMenu.SetActive(false);
        SoundManager.instance.PlaySoundFX(menuSelect, 0.3f);
    }

    public void BackButton()
    {
        creditsMenu.SetActive(false);
        startMenu.SetActive(true);
        SoundManager.instance.PlaySoundFX(menuSelect, 0.3f);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
