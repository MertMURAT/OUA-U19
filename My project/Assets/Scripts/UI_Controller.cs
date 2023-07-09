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
    public GameObject[] chapterPanels;
   

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


    #region Chapter Panels
    public void ToggleChapterPanel1()
    {
        chapterPanels[0].SetActive(true);
        chapterPanels[1].SetActive(false);
        chapterPanels[2].SetActive(false);
        chapterPanels[3].SetActive(false);
        chapterPanels[4].SetActive(false);
    }
    public void ToggleChapterPanel2()
    {
        chapterPanels[0].SetActive(false);
        chapterPanels[1].SetActive(true);
        chapterPanels[2].SetActive(false);
        chapterPanels[3].SetActive(false);
        chapterPanels[4].SetActive(false);
    }
    public void ToggleChapterPanel3()
    {
        chapterPanels[0].SetActive(false);
        chapterPanels[1].SetActive(false);
        chapterPanels[2].SetActive(true);
        chapterPanels[3].SetActive(false);
        chapterPanels[4].SetActive(false);
    }
    public void ToggleChapterPanel4()
    {
        chapterPanels[0].SetActive(false);
        chapterPanels[1].SetActive(false);
        chapterPanels[2].SetActive(false);
        chapterPanels[3].SetActive(true);
        chapterPanels[4].SetActive(false);
    }
    public void ToggleChapterPanel5()
    {
        chapterPanels[0].SetActive(false);
        chapterPanels[1].SetActive(false);
        chapterPanels[2].SetActive(false);
        chapterPanels[3].SetActive(false);
        chapterPanels[4].SetActive(true);
    }
    #endregion

}
