using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine.InputSystem;
using Unity.VisualScripting;

public class ObjectInteraction : MonoBehaviour
{
    [SerializeField] UI_Controller u�Script;
    [SerializeField] Sprite[] infoImageSprites;
    [SerializeField] TextMeshProUGUI infoText;
    [SerializeField] Image infoImage,freColor;
    [SerializeField] GameObject infoPanel;


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("testflower") && u�Script.isGun==false)
        {
            infoText.text = "Frequency value: 136 Hz";
            infoImage.sprite = infoImageSprites[0];
            freColor.color = Color.red;

            infoPanel.SetActive(true);
            u�Script.minimap.SetActive(false);
            Time.timeScale = 0;
            u�Script.playerInput.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if (other.CompareTag("testtree") && u�Script.isGun == false)
        {
            infoText.text = "Frequency value: 97 Hz";
            infoImage.sprite = infoImageSprites[1];
            freColor.color = Color.blue;
            infoPanel.SetActive(true);
            u�Script.minimap.SetActive(false);
            Time.timeScale = 0;
            u�Script.playerInput.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if(other.CompareTag("garbage"))
        {
            Destroy(other.gameObject);
        }
    }

    public void CloseInfoPanel()
    {
        infoPanel.SetActive(false);
        u�Script.minimap.SetActive(true);
        Time.timeScale = 1;
        u�Script.playerInput.enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
