using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueTrigger : MonoBehaviour
{

    public static DialogueTrigger instance;

    public Dialogue dialogue;
    public PlayerInput input;
    public bool isSunflowerCompleted = false;
    public bool isAnimalsCompleted = false;
    public bool startDialogue = false;

    private void Awake()
    {
        instance = this;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            TriggerDialogue();
            Debug.Log("Dialogue Trigger");
        }
    }

    public void TriggerDialogue()
    {
        if (dialogue.name == "Kuesa" && !startDialogue)
        {
            MissionSystem.instance.SetMissionData(MissionSystem.Mission.FIND_NOVORA, MissionSystem.MissionStatus.ONGOING);
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            input.enabled = false;
            Debug.Log("Start dialogue");
            startDialogue = true;
        }

        if (dialogue.name == "Novora" && MissionSystem.instance.GetMissionData(MissionSystem.Mission.FIND_NOVORA) == MissionSystem.MissionStatus.ONGOING)
        {
            MissionSystem.instance.SetMissionData(MissionSystem.Mission.FIND_NOVORA, MissionSystem.MissionStatus.COMPLETED);
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            input.enabled = false;
            Debug.Log("Novora's first dialogue");
        }
        else if (dialogue.name == "Novora" && MissionSystem.instance.GetMissionData(MissionSystem.Mission.BACK_TO_NOVORA) == MissionSystem.MissionStatus.ONGOING)
        {
            MissionSystem.instance.SetMissionData(MissionSystem.Mission.BACK_TO_NOVORA, MissionSystem.MissionStatus.COMPLETED);
            FindObjectOfType<SecondDialogueManager>().StartDialogue(dialogue);
            input.enabled = false;
            Debug.Log("Novora's second dialogue");
        }
        else if (dialogue.name == "Grimnir" && MissionSystem.instance.GetMissionData(MissionSystem.Mission.FIND_GRIMNIR) == MissionSystem.MissionStatus.ONGOING)
        {
            MissionSystem.instance.SetMissionData(MissionSystem.Mission.FIND_GRIMNIR, MissionSystem.MissionStatus.COMPLETED);
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            input.enabled = false;
            Debug.Log("Grimnir's first dialogue");
        }
        else if (dialogue.name == "Grimnir" && MissionSystem.instance.GetMissionData(MissionSystem.Mission.BACK_TO_GRIMNIR) == MissionSystem.MissionStatus.ONGOING)
        {
            MissionSystem.instance.SetMissionData(MissionSystem.Mission.BACK_TO_GRIMNIR, MissionSystem.MissionStatus.COMPLETED);
            FindObjectOfType<SecondDialogueManager>().StartDialogue(dialogue);
            input.enabled = false;
            Debug.Log("Grimnir's second dialogue");
        }
        else if (dialogue.name == "X-37" && MissionSystem.instance.GetMissionData(MissionSystem.Mission.FIND_TOWN) == MissionSystem.MissionStatus.ONGOING)
        {
            MissionSystem.instance.SetMissionData(MissionSystem.Mission.FIND_TOWN, MissionSystem.MissionStatus.COMPLETED);
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            input.enabled = false;
            Debug.Log("Find Town dialogue");
        }
        else if (dialogue.name == "Nolf" && MissionSystem.instance.GetMissionData(MissionSystem.Mission.FIND_NOLF) == MissionSystem.MissionStatus.ONGOING)
        {
            MissionSystem.instance.SetMissionData(MissionSystem.Mission.FIND_NOLF, MissionSystem.MissionStatus.COMPLETED);
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            input.enabled = false;
            Debug.Log("Nolf's dialogue");
        }
        else if (dialogue.name == "Uten" && MissionSystem.instance.GetMissionData(MissionSystem.Mission.FIND_UTEN) == MissionSystem.MissionStatus.ONGOING)
        {
            MissionSystem.instance.SetMissionData(MissionSystem.Mission.FIND_UTEN, MissionSystem.MissionStatus.COMPLETED);
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            input.enabled = false;
            Debug.Log("Uten's dialogue");
        }
        else if (dialogue.name == "Highin" && MissionSystem.instance.GetMissionData(MissionSystem.Mission.FIND_HIGHIN) == MissionSystem.MissionStatus.ONGOING)
        {
            MissionSystem.instance.SetMissionData(MissionSystem.Mission.FIND_HIGHIN, MissionSystem.MissionStatus.COMPLETED);
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            input.enabled = false;
            Debug.Log("Highin's dialogue");
        }






    }
}
