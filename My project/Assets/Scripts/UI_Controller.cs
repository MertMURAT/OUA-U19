using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class UI_Controller : MonoBehaviour
{
    public GameObject tabletPanel;
    public GameObject minimap;
    public GameObject mapPanel;
    public GameObject missionsPanel;
    public GameObject settingsPanel;
    public PlayerInput playerInput;
   

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!tabletPanel.activeSelf)
            {
                OpenTablet();
            }
            else
            {
                CloseTablet();
            }
        }
    }



    public void OpenTablet()
    {
        tabletPanel.SetActive(true);
        minimap.SetActive(false);
        Time.timeScale = 0;
        playerInput.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void CloseTablet()
    {
        tabletPanel.SetActive(false);
        minimap.SetActive(true);
        Time.timeScale = 1;
        playerInput.enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OpenMap()
    {
        mapPanel.SetActive(true);
        missionsPanel.SetActive(false);
        settingsPanel.SetActive(false);
    }

    public void OpenMissions()
    {
        missionsPanel.SetActive(true);
        mapPanel.SetActive(false);
        settingsPanel.SetActive(false);
    }
    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
        missionsPanel.SetActive(false);
        mapPanel.SetActive(false);
    }



}
