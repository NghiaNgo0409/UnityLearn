using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalScoreText;
    // Start is called before the first frame update
    void Start()
    {
        finalScoreText = GetComponentInChildren<TextMeshProUGUI>();
    }
}
