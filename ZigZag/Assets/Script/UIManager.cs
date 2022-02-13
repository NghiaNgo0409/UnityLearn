using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] Text tapText;
    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] Text scoreText;
    [SerializeField] Text bestScore1;
    [SerializeField] Text bestScore2;
    

    private void Awake() {
        if(instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        bestScore2.text = "High Score: " + PlayerPrefs.GetInt("highscore");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart()
    {
        tapText.gameObject.SetActive(false);
        startPanel.GetComponent<Animator>().Play("StartPanelSlide");
    }

    public void GameOver()
    {
        scoreText.text = PlayerPrefs.GetInt("score").ToString();
        bestScore1.text = PlayerPrefs.GetInt("highscore").ToString();
        gameOverPanel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
