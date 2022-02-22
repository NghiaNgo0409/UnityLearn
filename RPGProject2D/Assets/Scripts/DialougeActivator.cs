using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougeActivator : MonoBehaviour
{
    bool canActivate;
    [SerializeField] string[] lines;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canActivate && Input.GetButtonDown("Fire1"))
        {
            DialogueManager.instance.ShowDialogue(lines);
            canActivate = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
        {
            canActivate = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player")
        {
            canActivate = false;
        }
    }
}
