using System.Collections;
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
        HealAnimalsText.text = " Heal Animals " + HealAnimalsCount.ToString() + " / 10";
    }

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
        Start_FindGrimnir();
    }
    #endregion

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
        //Start chapter 3
        chapter2End = true;
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
        BACK_TO_GRIMNIR = 6
    }
    public enum MissionStatus : int
    {
        NONE = 0,
        ONGOING = 1,
        COMPLETED = 2
    }

    public enum MissionType : int
    {
        CHAT = 0,
        GATHER = 1
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
            //GÖrevilerin devamı buraya
        }



    }

    public MissionStatus GetMissionData(Mission mission)
    {
        return MissionData.ContainsKey(mission) ? MissionData[mission] : MissionStatus.NONE;
    }



}
