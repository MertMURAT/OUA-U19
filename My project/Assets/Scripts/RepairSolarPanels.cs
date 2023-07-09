using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using StarterAssets;
public class RepairSolarPanels : MonoBehaviour
{
    public Slider slider;
    public bool isChanged = false;

    private void Start()
    {
        slider.maxValue = Random.Range(250, 500);
        slider.value = Random.Range(0, slider.maxValue);
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("OnTriggerStay");
        if (other.gameObject.tag == "Player" && Input.GetKey(KeyCode.F) && ThirdPersonController.instance.Grounded == true && !isChanged)
        {
            if (slider.value < slider.maxValue)
            {
                Repair();
                ThirdPersonController.instance.AnimateRepair();
            }
            else
            {
                ThirdPersonController.instance.StopRepair();
            }
        }
        else
        {
            ThirdPersonController.instance.StopRepair();

            if (slider.value == slider.maxValue && !isChanged)
            {
                isChanged = true;
                MissionSystem.instance.AdvanceRepairPanels();
            }
        }
    }

    public void Repair()
    {
        slider.value++;
    }

}
