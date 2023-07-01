using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using StarterAssets;

public class MissionSystem : MonoBehaviour
{
    public static MissionSystem instance;
    public GameObject FindNovoraGO, HealSunflowerGO, Mission3, Mission4, Mission5;
    public TMP_Text FindNovoraText, HealSunflowerText, MissionText3, MissionText4, MissionText5;
    public GameObject FindNovoraCheck, HealSunflowerCheck;
    public int HealSunflowerCount = 0;

    ThirdPersonController controller;
    public GameObject player;
    private Animator anim;
    

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        anim = player.GetComponent<Animator>();
        controller = player.GetComponent<ThirdPersonController>();
        HealSunflowerText.text = " Heal Sunflower " + HealSunflowerCount.ToString() + " / 10";
    }

    #region Mission-1 Find Novora
    public void Start_FindNovora()
    {
        FindNovoraGO.SetActive(true);
        //Haritada işaretle
        //Tablette göster
        //NPC ile etkileşimi kapat
    }

    public void End_FindNovora()
    {
        FindNovoraText.GetComponent<TMP_Text>().color = Color.green;
        FindNovoraCheck.SetActive(true);
        //tablette tamamla
    }
    #endregion

    #region Mission-2 Heal Sunflower
    public void Start_HealSunflower()
    {
        HealSunflowerGO.SetActive(true);
        //Haritada işaretle
        //Tablette göster
    }

    public void End_HealSunflower()
    {
        HealSunflowerText.GetComponent<TMP_Text>().color = Color.green;
        HealSunflowerCheck.SetActive(true);
        //tablette tamamla
        //NPC ile etkileşimi kapat
    }

    public void AdvanceHealSunflower()
    {
        HealSunflowerCount++;
        HealSunflowerText.text = " Heal Sunflower " + HealSunflowerCount.ToString() + " / 10";
        if (HealSunflowerCount == 10)
        {
            End_HealSunflower();
        }
    }
#endregion
    

    public void DisableInput()
    {
        controller.enabled = false;
        anim.enabled = false;
    }
    public void EnableInput()
    {
        controller.enabled = true;
        anim.enabled = true;
    }



}
