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
        if (dialogue.name == "  ")
        {
            MissionSystem.instance.SetMissionData(MissionSystem.Mission.FIND_NOVORA, MissionSystem.MissionStatus.ONGOING);
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            input.enabled = false;
            Debug.Log("Start dialogue");
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
    }

        

    public void EnableCollider()
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = true;
    }

    public void DisableCollider()
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;

    }
}
