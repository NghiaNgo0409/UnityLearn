using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    public GameObject gameMenu;
    PlayerStats[] playerStats;
    [SerializeField] Text[] hpText, mpText, levelText, expText, nameText;
    [SerializeField] Slider[] expBar;
    [SerializeField] Image[] charImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire2"))
        {
            if(gameMenu.activeInHierarchy)
            {
                GameManager.instance.isGameMenuActive = false;
                gameMenu.SetActive(false);
            }
            else
            {
                GameManager.instance.isGameMenuActive = true;
                UpdateMenuStats();
                gameMenu.SetActive(true);
            }
        }
    }

    public void UpdateMenuStats()
    {
        playerStats = GameManager.instance.playerStats;
        Debug.Log(playerStats.Length);

        for(int i = 0; i < playerStats.Length; i++)
        {
            hpText[i].text = "HP: " + playerStats[i].currentHp + "/" + playerStats[i].maxHP;
            mpText[i].text = "MP: " + playerStats[i].currentMp + "/" + playerStats[i].maxMP;
            levelText[i].text = "Level: " + playerStats[i].playerLevel;
            nameText[i].text = playerStats[i].playerName;
            expText[i].text = "" + playerStats[i].currentExp + "/" + playerStats[i].expToLevelUp[playerStats[i].playerLevel];
            expBar[i].maxValue = playerStats[i].expToLevelUp[playerStats[i].playerLevel];
            expBar[i].value = playerStats[i].currentExp;
        }
    }
}
