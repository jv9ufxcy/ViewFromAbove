using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    
    private Queue<string> sentences;

    [SerializeField] private TPSCharacterController characterController;
    [SerializeField] private TPSCameraController cameraController;

    private bool isDialogueBoxVisible;

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<TPSCharacterController>();
        cameraController = GetComponent<TPSCameraController>();
        sentences = new Queue<string>();
    }
    private void Update()
    {
        UpdatePlayer();
    }
    public void StartDialogue(Dialogue dialogue)
    {
        isDialogueBoxVisible = true;
        Debug.Log("Starting dialogue with " + dialogue.name);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count==0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        Debug.Log(sentence);
        dialogueText.text = sentence;
    }

    private void EndDialogue()
    {
        Debug.Log("End of Dialogue");
        isDialogueBoxVisible = false;
    }
    private void UpdatePlayer()
    {
        if (isDialogueBoxVisible)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        //characterController.enabled = !isDialogueBoxVisible;
        //cameraController.enabled = characterController.enabled;

    }
}
