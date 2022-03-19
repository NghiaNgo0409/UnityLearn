using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Win_Controller : MonoBehaviour
{
    [SerializeField] GameObject winCanvas;
    // Start is called before the first frame update
    void Start()
    {
        winCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            Debug.Log("Winnnnnnnnn");
            winCanvas.SetActive(true) ;
        }
    }

    public void OnPlayAgainButtonClicked()
    {
        Debug.Log("Play again");
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
    }
}
