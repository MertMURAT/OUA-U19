using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CheckCollision : MonoBehaviour
{
    public GameObject infoPanel;
    public LaserManager laserMan;
    public UI_Controller uý;
    public Image infoImg;
    public Sprite[] infoSprite;
    public Image hZColor;
    public TextMeshProUGUI textInfo;
    public AudioSource[] laserSounds;


    private void OnTriggerEnter(Collider other)
    {  
        if (  laserMan.isOpen== true && other.CompareTag("tree"))
        {
            laserSounds[0].Play();
            Debug.Log("x");
            infoImg.sprite = infoSprite[0];
            hZColor.color = Color.red;
            textInfo.text = "Frequency value : 97 Hz";
            infoPanel.SetActive(true);

            uý.minimap.SetActive(false);
            Time.timeScale = 0;
            uý.playerInput.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (laserMan.isOpen == true && other.CompareTag("flower"))
        {
            Debug.Log("x");
            infoImg.sprite = infoSprite[1];
            hZColor.color = Color.blue;
            textInfo.text = "Frequency value : 136 Hz";
            infoPanel.SetActive(true);
            laserSounds[0].Play();
            uý.minimap.SetActive(false);
            Time.timeScale = 0;
            uý.playerInput.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
