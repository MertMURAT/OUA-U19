using UnityEngine;

public class Settings : MonoBehaviour
{
    public GameObject videoPanel, audioPanel, controlsPanel, creditsPanel;
    public AudioClip menuSelect;


    //UI Panels
    public void OpenVideoPanel()
    {
        videoPanel.SetActive(true);
        audioPanel.SetActive(false);
        controlsPanel.SetActive(false);
        creditsPanel.SetActive(false);
        SoundManager.instance.PlaySoundFX(menuSelect, 0.3f);
    }
    public void OpenAudioPanel()
    {
        videoPanel.SetActive(false);
        audioPanel.SetActive(true);
        controlsPanel.SetActive(false);
        creditsPanel.SetActive(false);
        SoundManager.instance.PlaySoundFX(menuSelect, 0.3f);
    }
    public void OpenControlsPanel()
    {
        videoPanel.SetActive(false);
        audioPanel.SetActive(false);
        controlsPanel.SetActive(true);
        creditsPanel.SetActive(false);
        SoundManager.instance.PlaySoundFX(menuSelect, 0.3f);
    }
    public void OpenCreditsPanel()
    {
        videoPanel.SetActive(false);
        audioPanel.SetActive(false);
        controlsPanel.SetActive(false);
        creditsPanel.SetActive(true);
        SoundManager.instance.PlaySoundFX(menuSelect, 0.3f);
    }


    //Quality Settings
    public void SetQualityToHigh(bool quality)
    {
        if (quality)
        {
            QualitySettings.SetQualityLevel(5);
            SoundManager.instance.PlaySoundFX(menuSelect, 0.3f);
        }
    }
    public void SetQualityToMid(bool quality)
    {
        if (quality)
        {
            QualitySettings.SetQualityLevel(3);
            SoundManager.instance.PlaySoundFX(menuSelect, 0.3f);
        }
    }
    public void SetQualityToLow(bool quality)
    {
        if (quality)
        {
            QualitySettings.SetQualityLevel(1);
            SoundManager.instance.PlaySoundFX(menuSelect, 0.3f);
        }
    }

    //Resolution Setting
    public void SetResTo19201080(bool res)
    {
        if (res)
        {
            Screen.SetResolution(1920, 1080, true);
            SoundManager.instance.PlaySoundFX(menuSelect, 0.3f);
        }
    }
    public void SetResTo1280720(bool res)
    {
        if (res)
        {
            Screen.SetResolution(1280, 720, true);
            SoundManager.instance.PlaySoundFX(menuSelect, 0.3f);
        }
    }

    //Fullscreen
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        SoundManager.instance.PlaySoundFX(menuSelect, 0.3f);
    }

}
