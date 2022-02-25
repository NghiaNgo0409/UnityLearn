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
    [SerializeField] GameObject[] windows;

    [Header("Stats Menu")]
    [SerializeField] Button[] buttons;
    [SerializeField] Text charName, hpTextStat, mpTextStat, strText, defText, equipWpn, wpnPower, equipArmor, armorPower, expNext; 
    [SerializeField] Image charImageStat;
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
                CloseMenu();
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

    public void ToggleWindows(int windowsIndex)
    {
        for(int i = 0; i < windows.Length; i++)
        {
            if(i == windowsIndex)
            {
                windows[i].SetActive(!windows[i].activeInHierarchy);
            }
            else
            {
                windows[i].SetActive(false);   
            }
        }
    }
    
    public void CloseMenu()
    {
        for(int i = 0; i < windows.Length; i++)
        {
            windows[i].SetActive(false);
        }

        GameManager.instance.isGameMenuActive = false;
        gameMenu.SetActive(false);
    }

    public void OpenStatMenu()
    {
        UpdateMenuStats();

        ButtonStats(0);
        
        for(int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponentInChildren<Text>().text = playerStats[i].playerName;
        }
    }

    public void ButtonStats(int index)
    {
        charName.text = playerStats[index].playerName;
        hpTextStat.text = "HP: " + playerStats[index].currentHp + "/" + playerStats[index].maxHP;
        mpTextStat.text = "MP: " + playerStats[index].currentMp + "/" + playerStats[index].maxMP;
        strText.text = "Strength: " + playerStats[index].strength;
        defText.text = "Defense: " + playerStats[index].defence;
        if(playerStats[index].equippedWeapon != "")
        {
            equipWpn.text = "Equipped Weapon: " + playerStats[index].equippedWeapon;
        }
        wpnPower.text = "Weapon Power: " + playerStats[index].weaponPwr;
        if(playerStats[index].equippedArmor != "")
        {
            equipArmor.text = "Equipped Armor: " + playerStats[index].equippedArmor;
        }
        armorPower.text = "Armor Power: " + playerStats[index].armorPwr;
        expNext.text = "Exp to next level: " + (playerStats[index].expToLevelUp[playerStats[index].playerLevel] - playerStats[index].currentExp);
    }
}
