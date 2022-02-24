using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public string playerName;   
    public int playerLevel = 1;
    public int currentExp;
    public int maxLevel = 100;
    public int[] expToLevelUp;
    public int baseExp = 1000;
    public int currentHp;
    public int maxHP = 1000;
    public int currentMp;
    public int maxMP = 1000;
    [SerializeField] int strength;
    [SerializeField] int defence;
    [SerializeField] int weaponPwr;
    [SerializeField] int armorPwr;
    [SerializeField] string equippedWeapon;
    [SerializeField] string equippedArmor;
    public Sprite characterImage;


    // Start is called before the first frame update
    void Start()
    {
        expToLevelUp = new int[maxLevel];
        expToLevelUp[1] = baseExp;

        for(int i = 2; i < expToLevelUp.Length; i++)
        {
            expToLevelUp[i] = Mathf.FloorToInt(expToLevelUp[i-1] * 1.05f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            AddExp(500);
        }
    }

    public void AddExp(int expToAdd)
    {
        currentExp += expToAdd;
        if(playerLevel < maxLevel)
        {
            if(currentExp >= expToLevelUp[playerLevel])
            {
                currentExp -= expToLevelUp[playerLevel];
                playerLevel++;

                if(playerLevel % 2 == 0)
                {
                    strength++;
                }
                else
                {
                    defence++;
                }

                maxHP = Mathf.FloorToInt(maxHP * 1.05f);
                currentHp = maxHP;

                maxMP = Mathf.FloorToInt(maxMP * 1.05f);
                currentMp = maxMP;
            }
        }

        if(playerLevel >= maxLevel)
        {
            currentExp = 0;
        }
    }
}
