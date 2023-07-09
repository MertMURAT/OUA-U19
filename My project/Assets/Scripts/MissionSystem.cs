﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using StarterAssets;

public class MissionSystem : MonoBehaviour
{
    public static MissionSystem instance;

    //Chapter - 1
    public GameObject Chapter1;
    public bool chapter1End = false;
    public GameObject FindNovoraGO, HealSunflowerGO, BackToNovoraGO;
    public TMP_Text FindNovoraText, HealSunflowerText, BackToNovoraText;
    public GameObject FindNovoraCheck, HealSunflowerCheck, BackToNovoraCheck;
    private int HealSunflowerCount = 0;
    //Chapter - 2
    public GameObject Chapter2;
    public bool chapter2End = false;
    public GameObject FindGrimnirGO, HealAnimalsGO, BackToGrimnirGO;
    public TMP_Text FindGrimnirText, HealAnimalsText, BackToGrimnirText;
    public GameObject FindGrimnirCheck, HealAnimalsCheck, BackToGrimnirCheck;
    private int HealAnimalsCount = 0;

    //Chapter - 3
    public GameObject Chapter3;
    public bool chapter3End = false;
    public GameObject FindTownGO, FindNolfGO, CollectWastesGO;
    public TMP_Text FindTownText, FindNolfText, CollectWastesText;
    public GameObject FindTownCheck, FindNolfCheck, CollectWastesCheck;
    private int CollectWastesCount = 0;

    //Chapter - 4
    public GameObject Chapter4;
    public bool chapter4End = false;
    public GameObject FindUtenGO, RepairPanelsGO, FindHighinGO;
    public TMP_Text FindUtenText, RepairPanelsText, FindHighinText;
    public GameObject FindUtenCheck, RepairPanelsCheck, FindHighinCheck;
    private int RepairPanelsCount = 0;

    //Chapter - 5
    public GameObject Chapter5;
    public bool chapter5End = false;
    public GameObject FindMonumentGO, PlaceStonesGO;
    public TMP_Text FindMonumentText, PlaceStonesText;
    public GameObject FindMonumentCheck, PlaceStonesCheck;
    private int PlaceStonesCount = 0;

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
        HealAnimalsText.text = " Heal Rabbits " + HealAnimalsCount.ToString() + " / 10";
        CollectWastesText.text = " Collect Wastes " + CollectWastesCount.ToString() + " / 10";
        RepairPanelsText.text = " Repair Panels " + RepairPanelsCount.ToString() + " / 4";
        PlaceStonesText.text = " Place the holy stones " + PlaceStonesCount.ToString() + " / 4";
    }

    //CHAPTER - 1
    #region Mission-1/1 Find Novora
    public void Start_FindNovora()
    {
        FindNovoraGO.SetActive(true);
        //Haritada işaretle
    }

    public void End_FindNovora()
    {
        FindNovoraText.GetComponent<TMP_Text>().color = Color.green;
        FindNovoraCheck.SetActive(true);
    }
    #endregion

    #region Mission-1/2 Heal Sunflower
    public void Start_HealSunflower()
    {
        HealSunflowerGO.SetActive(true);
        //Haritada işaretle
    }

    public void End_HealSunflower()
    {
        if (MissionSystem.instance.GetMissionData(Mission.SUNFLOWER) == MissionStatus.COMPLETED)
        {
            return;
        }

        HealSunflowerText.GetComponent<TMP_Text>().color = Color.green;
        HealSunflowerCheck.SetActive(true);
        MissionSystem.instance.SetMissionData(Mission.SUNFLOWER, MissionStatus.COMPLETED);
    }

    public void AdvanceHealSunflower()
    {
        HealSunflowerCount++;
        HealSunflowerText.text = " Heal Sunflower " + HealSunflowerCount.ToString() + " / 10";
        if (HealSunflowerCount == 1)
        {
            End_HealSunflower();
        }
    }
    #endregion

    #region Mission-1/3 Back To Novora
    public void Start_BackToNovora()
    {
        BackToNovoraGO.SetActive(true);
        //Haritada işaretle
    }

    public void End_BackToNovora()
    {
        BackToNovoraText.GetComponent<TMP_Text>().color = Color.green;
        BackToNovoraCheck.SetActive(true);
        Chapter1.SetActive(false);
        Chapter2.SetActive(true);
    }
    #endregion

    //CHAPTER - 2
    #region Mission-2/1 Find Grimnir
    public void Start_FindGrimnir()
    {
        FindGrimnirGO.SetActive(true);
        chapter1End = true;
        //Haritada işaretle
    }

    public void End_FindGrimnir()
    {
        FindGrimnirText.GetComponent<TMP_Text>().color = Color.green;
        FindGrimnirCheck.SetActive(true);
    }
    #endregion

    #region Mission-2/2 Heal Animals
    public void Start_HealAnimals()
    {
        HealAnimalsGO.SetActive(true);
        //Haritada işaretle
    }

    public void AdvanceHealAnimals()
    {
        HealAnimalsCount++;
        HealAnimalsText.text = " Heal Rabbits " + HealAnimalsCount.ToString() + " / 10";
        if (HealAnimalsCount == 1)
        {
            End_HealAnimals();
        }
    }

    public void End_HealAnimals()
    {
        if (MissionSystem.instance.GetMissionData(Mission.ANIMAL) == MissionStatus.COMPLETED)
        {
            return;
        }

        HealAnimalsText.GetComponent<TMP_Text>().color = Color.green;
        HealAnimalsCheck.SetActive(true);
        Start_BackToGrimnir();
        MissionSystem.instance.SetMissionData(Mission.ANIMAL, MissionStatus.COMPLETED);
    }


    #endregion

    #region Mission-2/3 Back To Grimnir
    public void Start_BackToGrimnir()
    {
        BackToGrimnirGO.SetActive(true);
        //Haritada işaretle
    }

    public void End_BackToGrimnir()
    {
        BackToGrimnirText.GetComponent<TMP_Text>().color = Color.green;
        BackToGrimnirCheck.SetActive(true);
        Chapter2.SetActive(false);
        Chapter3.SetActive(true);
        chapter2End = true;
    }
    #endregion

    //CHAPTER - 3
    #region Mission-3/1 Find Town
    public void Start_FindTown()
    {
        FindTownGO.SetActive(true);
        chapter2End = true;
        //Haritada işaretle
    }

    public void End_FindTown()
    {
        FindTownText.GetComponent<TMP_Text>().color = Color.green;
        FindTownCheck.SetActive(true);
    }
    #endregion

    #region Mission-3/2 Find Nolf
    public void Start_FindNolf()
    {
        FindNolfGO.SetActive(true);
        //Haritada işaretle
    }

    public void End_FindNolf()
    {
        FindNolfText.GetComponent<TMP_Text>().color = Color.green;
        FindNolfCheck.SetActive(true);
    }
    #endregion

    #region Mission 3/3 Collect Wastes
    public void Start_CollectWastes()
    {
        CollectWastesGO.SetActive(true);
    }
    public void AdvanceCollectWastes()
    {
        CollectWastesCount++;
        CollectWastesText.text = " Collect Wastes " + CollectWastesText.ToString() + " / 10";
        if (CollectWastesCount == 1)
        {
            End_CollectWastes();
        }
    }
    public void End_CollectWastes()
    {
        if (MissionSystem.instance.GetMissionData(Mission.COLLECT_WASTES) == MissionStatus.COMPLETED)
        {
            return;
        }

        CollectWastesText.GetComponent<TMP_Text>().color = Color.green;
        CollectWastesCheck.SetActive(true);
        Start_FindUten();
        MissionSystem.instance.SetMissionData(Mission.COLLECT_WASTES, MissionStatus.COMPLETED);
        Chapter3.SetActive(false);
        Chapter4.SetActive(true);
    }
    #endregion

    //CHAPTER - 4
    #region Mission-4/1 Find Uten
    public void Start_FindUten()
    {
        FindUtenGO.SetActive(true);
        chapter3End = true;
        //Haritada işaretle
    }
    public void End_FindUten()
    {
        FindUtenText.GetComponent<TMP_Text>().color = Color.green;
        FindUtenCheck.SetActive(true);
    }
    #endregion

    #region Mission-4/2 Reapir Panels
    public void Start_RepairPanels()
    {
        RepairPanelsGO.SetActive(true);
        //Haritada işaretle
    }

    public void AdvanceRepairPanels()
    {
        RepairPanelsCount++;
        RepairPanelsText.text = " Repair Solar Panels " + RepairPanelsCount.ToString() + " / 4";
        if (RepairPanelsCount == 1)
        {
            End_RepairPanels();
        }
    }

    public void End_RepairPanels()
    {
        if (MissionSystem.instance.GetMissionData(Mission.REPAIR_PANELS) == MissionStatus.COMPLETED)
        {
            return;
        }

        RepairPanelsText.GetComponent<TMP_Text>().color = Color.green;
        RepairPanelsCheck.SetActive(true);
        Start_FindHighin();
        MissionSystem.instance.SetMissionData(Mission.REPAIR_PANELS, MissionStatus.COMPLETED);
    }


    #endregion

    #region Mission-4/3 Find Highin
    public void Start_FindHighin()
    {
        FindHighinGO.SetActive(true);
        //Haritada işaretle
    }
    public void End_FindHighin()
    {
        FindHighinText.GetComponent<TMP_Text>().color = Color.green;
        FindHighinCheck.SetActive(true);
        Chapter4.SetActive(false);
        Chapter5.SetActive(true);
    }
    #endregion

    //CHAPTER - 5
    #region Mission-5/1 Find Monument
    public void Start_FindMonument()
    {
        FindMonumentGO.SetActive(true);
        chapter4End = true;
        //Haritada işaretle
    }
    public void End_FindMonument()
    {
        FindMonumentText.GetComponent<TMP_Text>().color = Color.green;
        FindMonumentCheck.SetActive(true);
    }
    #endregion

    #region Mission-5/2 Place Stones
    public void Start_PlaceStones()
    {
        PlaceStonesGO.SetActive(true);
    }

    public void AdvancePlaceStones()
    {
        PlaceStonesCount++;
        PlaceStonesText.text = " Place the holy stones " + PlaceStonesCount.ToString() + " / 4";
        if (PlaceStonesCount == 4)
        {
            End_PlaceStones();

            /// OYUN BİTİŞİ BURADA
        }
    }

    public void End_PlaceStones()
    {
        if (MissionSystem.instance.GetMissionData(Mission.PLACE_STONES) == MissionStatus.COMPLETED)
        {
            return;
        }

        PlaceStonesText.GetComponent<TMP_Text>().color = Color.green;
        PlaceStonesCheck.SetActive(true);
        MissionSystem.instance.SetMissionData(Mission.PLACE_STONES, MissionStatus.COMPLETED);
        Chapter5.SetActive(false);
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



    ///Mission Status
    public enum Mission : int
    {
        FIND_NOVORA = 1,
        SUNFLOWER = 2,
        BACK_TO_NOVORA = 3,

        FIND_GRIMNIR = 4,
        ANIMAL = 5,
        BACK_TO_GRIMNIR = 6,

        FIND_TOWN = 7,
        FIND_NOLF = 8,
        COLLECT_WASTES = 9,

        FIND_UTEN = 10,
        REPAIR_PANELS = 11,
        FIND_HIGHIN = 12,

        FIND_MONUMENT = 13,
        PLACE_STONES = 14
    }
    public enum MissionStatus : int
    {
        NONE = 0,
        ONGOING = 1,
        COMPLETED = 2
    }

    public Dictionary<Mission, MissionStatus> MissionData = new Dictionary<Mission, MissionStatus>();

    public void SetMissionData(Mission mission, MissionStatus status)
    {
        Debug.Log(mission + "/" + status);

        if (MissionData.ContainsKey(mission))
        {
            MissionData[mission] = status;
        }
        else
        {
            MissionData.Add(mission, status);
        }

        if (mission == Mission.FIND_NOVORA && status == MissionStatus.ONGOING)
        {
            Start_FindNovora();
        }
        else if (mission == Mission.FIND_NOVORA && status == MissionStatus.COMPLETED)
        {
            End_FindNovora();
            SetMissionData(Mission.SUNFLOWER, MissionStatus.ONGOING);
        }
        else if (mission == Mission.SUNFLOWER && status == MissionStatus.ONGOING)
        {
            Start_HealSunflower();
        }
        else if (mission == Mission.SUNFLOWER && status == MissionStatus.COMPLETED)
        {
            End_HealSunflower();
            SetMissionData(Mission.BACK_TO_NOVORA, MissionStatus.ONGOING);
        }
        else if (mission == Mission.BACK_TO_NOVORA && status == MissionStatus.ONGOING)
        {
            Start_BackToNovora();
        }
        else if (mission == Mission.BACK_TO_NOVORA && status == MissionStatus.COMPLETED)
        {
            End_BackToNovora();
            SetMissionData(Mission.FIND_GRIMNIR, MissionStatus.ONGOING);
        }
        else if (mission == Mission.FIND_GRIMNIR && status == MissionStatus.ONGOING)
        {
            Start_FindGrimnir();
        }
        else if (mission == Mission.FIND_GRIMNIR && status == MissionStatus.COMPLETED)
        {
            End_FindGrimnir();
            SetMissionData(Mission.ANIMAL, MissionStatus.ONGOING);
        }
        else if (mission == Mission.ANIMAL && status == MissionStatus.ONGOING)
        {
            Start_HealAnimals();
        }
        else if (mission == Mission.ANIMAL && status == MissionStatus.COMPLETED)
        {
            End_HealAnimals();
            SetMissionData(Mission.BACK_TO_GRIMNIR, MissionStatus.ONGOING);
        }
        else if (mission == Mission.BACK_TO_GRIMNIR && status == MissionStatus.ONGOING)
        {
            Start_BackToGrimnir();
        }
        else if (mission == Mission.BACK_TO_GRIMNIR && status == MissionStatus.COMPLETED)
        {
            End_BackToGrimnir();
            SetMissionData(Mission.FIND_TOWN, MissionStatus.ONGOING);
        }
        else if (mission == Mission.FIND_TOWN && status == MissionStatus.ONGOING)
        {
            Start_FindTown();
        }
        else if (mission == Mission.FIND_TOWN && status == MissionStatus.COMPLETED)
        {
            End_FindTown();
            SetMissionData(Mission.FIND_NOLF, MissionStatus.ONGOING);
        }
        else if (mission == Mission.FIND_NOLF && status == MissionStatus.ONGOING)
        {
            Start_FindNolf();
        }
        else if (mission == Mission.FIND_NOLF && status == MissionStatus.COMPLETED)
        {
            End_FindNolf();
            SetMissionData(Mission.COLLECT_WASTES, MissionStatus.ONGOING);
        }
        else if (mission == Mission.COLLECT_WASTES && status == MissionStatus.ONGOING)
        {
            Start_CollectWastes();
        }
        else if (mission == Mission.COLLECT_WASTES && status == MissionStatus.COMPLETED)
        {
            End_CollectWastes();
            SetMissionData(Mission.FIND_UTEN, MissionStatus.ONGOING);
        }
        else if (mission == Mission.FIND_UTEN && status == MissionStatus.ONGOING)
        {
            Start_FindUten();
        }
        else if (mission == Mission.FIND_UTEN && status == MissionStatus.COMPLETED)
        {
            End_FindUten();
            SetMissionData(Mission.REPAIR_PANELS, MissionStatus.ONGOING);
        }
        else if (mission == Mission.REPAIR_PANELS && status == MissionStatus.ONGOING)
        {
            Start_RepairPanels();
        }
        else if (mission == Mission.REPAIR_PANELS && status == MissionStatus.COMPLETED)
        {
            End_RepairPanels();
            SetMissionData(Mission.FIND_HIGHIN, MissionStatus.ONGOING);
        }
        else if (mission == Mission.FIND_HIGHIN && status == MissionStatus.ONGOING)
        {
            Start_FindHighin();
        }
        else if (mission == Mission.FIND_HIGHIN && status == MissionStatus.COMPLETED)
        {
            End_FindHighin();
            SetMissionData(Mission.FIND_MONUMENT, MissionStatus.ONGOING);
        }
        else if (mission == Mission.FIND_MONUMENT && status == MissionStatus.ONGOING)
        {
            Start_FindMonument();
        }
        else if (mission == Mission.FIND_MONUMENT && status == MissionStatus.COMPLETED)
        {
            End_FindMonument();
            SetMissionData(Mission.PLACE_STONES, MissionStatus.ONGOING);
        }
        else if (mission == Mission.PLACE_STONES && status == MissionStatus.ONGOING)
        {
            Start_PlaceStones();
        }
        else if (mission == Mission.PLACE_STONES && status == MissionStatus.COMPLETED)
        {
            End_PlaceStones();
        }




    }

    public MissionStatus GetMissionData(Mission mission)
    {
        return MissionData.ContainsKey(mission) ? MissionData[mission] : MissionStatus.NONE;
    }



}