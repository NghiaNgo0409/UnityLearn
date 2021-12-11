using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberWizard : MonoBehaviour
{
    [SerializeField] int min;
    [SerializeField] int max;
    int guess;

    [SerializeField] TextMeshProUGUI guessText;
    // Start is called before the first frame update
    void Start()
    {
        NextGuess();
    }

    void NextGuess()
    {
        guess = Random.Range(min, max);
        guessText.text = guess.ToString();
    }

}
