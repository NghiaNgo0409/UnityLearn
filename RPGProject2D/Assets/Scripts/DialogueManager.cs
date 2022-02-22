using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    [SerializeField] Text dialogueText;
    [SerializeField] Text nameText;
    [SerializeField] GameObject dialogueBox;
    [SerializeField] GameObject nameBox;
    [SerializeField] string[] dialogueLines;
    [SerializeField] int currentLine;
    bool justStarted; //Make sure the dialogue has just started and do not skip dialogue
    private void Awake() {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && !justStarted)
        {
            currentLine++;
            if(currentLine >= dialogueLines.Length)
            {
                dialogueBox.SetActive(false);
            }
            else
            {
                dialogueText.text = dialogueLines[currentLine];
            }
        }
        else
        {
            justStarted = false;
        }
    }

    public void ShowDialogue(string[] lines)
    {
        dialogueLines = lines;
        currentLine = 0;
        dialogueText.text = lines[0];
        dialogueBox.SetActive(true);
        justStarted = true;
    }
}
