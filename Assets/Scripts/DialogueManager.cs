using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Animator anim;
    
    private Queue<string> sentences;

    [SerializeField] private TPSCharacterController characterController;
    [SerializeField] private TPSCameraController cameraController;
    [SerializeField] private ActivateLookedAtObjects activateObj;

    private bool isDialogueBoxVisible;
    [SerializeField] private float typingSpeed=1f;

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        characterController = characterController.GetComponent<TPSCharacterController>();
        cameraController = cameraController.GetComponent<TPSCameraController>();
        activateObj = activateObj.GetComponent<ActivateLookedAtObjects>();
        sentences = new Queue<string>();
    }
    private void Update()
    {
        UpdatePlayer();
    }
    public void StartDialogue(Dialogue dialogue)
    {
        isDialogueBoxVisible = true;
        anim.SetBool("isOpen", isDialogueBoxVisible);
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
        //dialogueText.text = sentence;
        StopAllCoroutines();
        StartCoroutine(Type(sentence));
    }
    IEnumerator Type(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    private void EndDialogue()
    {
        Debug.Log("End of Dialogue");
        isDialogueBoxVisible = false;
        anim.SetBool("isOpen", isDialogueBoxVisible);
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

        characterController.enabled = !isDialogueBoxVisible;
        cameraController.enabled = characterController.enabled;
        activateObj.enabled = characterController.enabled;
    }
}
