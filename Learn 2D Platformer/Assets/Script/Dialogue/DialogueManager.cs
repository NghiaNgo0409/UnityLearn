using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Queue<string> sentencesQ;

    public Text dialogueText;

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        sentencesQ = new Queue<string>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDialogue(Dialogue dialogue)
    {
        anim.SetBool("isOpen", true);

        sentencesQ.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentencesQ.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentencesQ.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentencesQ.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeCharacter(sentence));
    }

    IEnumerator TypeCharacter(string sentence)
    {
        dialogueText.text = "";
        foreach (char character in sentence.ToCharArray())
        {
            dialogueText.text += character;
            yield return null;
        }
    }

    void EndDialogue()
    {
        anim.SetBool("isOpen", false);
    }
}
