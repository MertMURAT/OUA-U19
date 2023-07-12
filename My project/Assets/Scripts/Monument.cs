using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class Monument : MonoBehaviour
{
    public static Monument instance;
    public AudioClip place;
    public AudioClip platformUp;

    public GameObject blue, green, orange, red;
    public bool blueBool = false, greenBool = false, orangeBool = false, redBool = false;
    public Animator anim;
    public ParticleSystem blueP, greenP, orangeP, redP;

    private void Awake()
    {
        instance = this;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Monument1") && Input.GetKeyDown(KeyCode.F) && !blueBool)
        {
            ThirdPersonController.instance.AnimatePlace();
            blueBool = true;
            blue.SetActive(true);
            blueP.Play();
            MissionSystem.instance.AdvancePlaceStones();
            SoundManager.instance.PlaySoundFX(place, 0.3f);
        }
        else if (other.CompareTag("Monument2") && Input.GetKeyDown(KeyCode.F) && !greenBool)
        {
            ThirdPersonController.instance.AnimatePlace();
            greenBool = true;
            green.SetActive(true);
            greenP.Play();
            MissionSystem.instance.AdvancePlaceStones();
            SoundManager.instance.PlaySoundFX(place, 0.3f);
        }
        else if (other.CompareTag("Monument3") && Input.GetKeyDown(KeyCode.F) && !orangeBool)
        {
            ThirdPersonController.instance.AnimatePlace();
            orangeBool = true;
            orange.SetActive(true);
            orangeP.Play();
            MissionSystem.instance.AdvancePlaceStones();
            SoundManager.instance.PlaySoundFX(place, 0.3f);
        }
        else if (other.CompareTag("Monument4") && Input.GetKeyDown(KeyCode.F) && !redBool)
        {
            ThirdPersonController.instance.AnimatePlace();
            redBool = true;
            red.SetActive(true);
            redP.Play();
            MissionSystem.instance.AdvancePlaceStones();
            SoundManager.instance.PlaySoundFX(place, 0.3f);
        }
        else
        {
            return;
        }
    }

    public void AnimateMonument()
    {
        anim.SetBool("isOpen", true);
        SoundManager.instance.PlaySoundFX(platformUp, 0.4f);

    }

}
