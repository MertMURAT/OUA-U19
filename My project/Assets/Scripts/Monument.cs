using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monument : MonoBehaviour
{
    public static Monument instance;

    public GameObject blue, green, orange, red;
    public bool blueBool = false, greenBool = false, orangeBool = false, redBool = false;
    public Animator anim;

    private void Awake()
    {
        instance = this;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Monument1") && Input.GetKeyDown(KeyCode.F) && !blueBool)
        {
            blueBool = true;
            MissionSystem.instance.AdvancePlaceStones();
            blue.SetActive(true);
        }
        else if (other.CompareTag("Monument2") && Input.GetKeyDown(KeyCode.F) && !greenBool)
        {
            greenBool = false;
            MissionSystem.instance.AdvancePlaceStones();
            green.SetActive(true);
        }
        else if (other.CompareTag("Monument3") && Input.GetKeyDown(KeyCode.F) && !orangeBool)
        {
            orangeBool = true;
            MissionSystem.instance.AdvancePlaceStones();
            orange.SetActive(true);
        }
        else if (other.CompareTag("Monument4") && Input.GetKeyDown(KeyCode.F) && !redBool)
        {
            redBool = true;
            MissionSystem.instance.AdvancePlaceStones();
            red.SetActive(true);
        }
        else
        {
            return;
        }
    }

    public void AnimateMonument()
    {
        anim.SetBool("isOpen", true);
    }

}
