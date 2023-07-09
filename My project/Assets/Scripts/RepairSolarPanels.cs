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
        if (other.gameObject.tag == "Player" && Input.GetKey(KeyCode.F) && !isChanged)
        {
            if (slider.value < slider.maxValue)
            {
                Repair();
            }
            else if (slider.value == slider.maxValue)
            {
                isChanged = true;
                MissionSystem.instance.AdvanceRepairPanels();
            }
            else
            {
                return;
            }
        }
    }

    public void Repair()
    {
        slider.value++;
    }

}
