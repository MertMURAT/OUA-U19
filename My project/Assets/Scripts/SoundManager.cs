using UnityEngine;
using UnityEngine.Audio;
using StarterAssets;

public class SoundManager : MonoBehaviour
{

    public static SoundManager instance;

    public AudioSource SFXManager1, SFXManager2, BGM;
    public AudioClip[] themeSongs;

    public AudioMixer BGM_Mixer, SFX_Mixer;


    void Awake()
    {
        MakeSingleton();
        //BGM.Play();
    }


    void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Update()
    {
        /*
        if (!BGM.isPlaying)
        {
            BGM.clip = themeSongs[Random.Range(0, themeSongs.Length)];
            BGM.Play();
        }
        */
    }

    public void PlaySoundFX(AudioClip audioClip, float volume)
    {
        if (!SFXManager1.isPlaying)
        {
            SFXManager1.clip = audioClip;
            SFXManager1.volume = volume;
            SFXManager1.PlayOneShot(audioClip, volume);
        }
        else
        {
            SFXManager2.clip = audioClip;
            SFXManager2.volume = volume;
            SFXManager2.PlayOneShot(audioClip, volume);
        }
    }

    public void PlayRandomSoundFX(AudioClip[] audioClips)
    {
        if (!SFXManager1.isPlaying)
        {
            SFXManager1.clip = audioClips[Random.Range(0, audioClips.Length)];
            SFXManager1.volume = Random.Range(0.3f, 0.6f);
            SFXManager1.Play();
        }
    }



    //Sound
    public void SetBGMVolume(float volume)
    {
        BGM_Mixer.SetFloat("BGM_Volume", Mathf.Log10(volume) * 20);
       
    }

    public void SetSFXVolume(float volume)
    {
        SFX_Mixer.SetFloat("SFX_Volume", Mathf.Log10(volume) * 20);
        ThirdPersonController.instance.FootstepAudioVolume = volume / 2;
        Debug.Log(ThirdPersonController.instance.FootstepAudioVolume + "" + volume);
    }

}
