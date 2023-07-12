using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public PlayerInput input;
    private bool dialogueStarted = false;

    public Animator anim;
    public AudioClip nextDia;

    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && dialogueStarted)
        {
            DisplayNextSentence();
        }
    }


    public void StartDialogue(Dialogue dialogue)
    {
        dialogueStarted = true;

        sentences.Clear();

        anim.SetBool("isOpen", true);

        nameText.text = dialogue.name;

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();

    }


    public void DisplayNextSentence()
    {
            if (sentences.Count == 0)
            {
                EndDialogue();
                return;
            }
        SoundManager.instance.PlaySoundFX(nextDia, 0.3f);
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }
    public void EndDialogue()
    {
        dialogueStarted = false;
        input.enabled = true;
        anim.SetBool("isOpen", false);
    }
}

