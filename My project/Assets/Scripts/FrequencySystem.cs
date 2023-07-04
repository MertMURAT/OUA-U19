using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using StarterAssets;
public class FrequencySystem : MonoBehaviour
{
    public Slider slider;
    public TMP_Text text;
    public Transform cam;
    public GameObject OldObject;
    public GameObject NewObject;
    public GameObject particle;
    public bool isChanged = false;



    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Player" && Input.GetKey(KeyCode.F) && ThirdPersonController.instance.Grounded == true && !isChanged)
        {
            if (slider.value < slider.maxValue)
            {
                ChangeFrequency();
                ThirdPersonController.instance.AnimateChangeFrequency();
            }
            else
            {
                ThirdPersonController.instance.StopFrequencyAnimate();
            }
            
        }
        else
        {
            ThirdPersonController.instance.StopFrequencyAnimate();
         
            if (slider.value == slider.maxValue && !isChanged)
            {
                OldObject.SetActive(false);
                NewObject.SetActive(true);
                particle.SetActive(true);
                Destroy(particle, 2f);
                isChanged = true;
            }

        }
    }

    public void ChangeFrequency()
    {
        slider.value++;
        text.text = slider.value.ToString() + " / " +  slider.maxValue.ToString();
    }

    private void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }

}
