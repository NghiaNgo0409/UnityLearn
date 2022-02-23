using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{   
    [SerializeField] int playerLevel = 1;
    [SerializeField] int currentExp;
    [SerializeField] int maxLevel = 100;
    [SerializeField] int[] expToLevelUp;
    [SerializeField] int baseExp = 1000;
    [SerializeField] int currentHp;
    [SerializeField] int maxHP = 1000;
    [SerializeField] int currentMp;
    [SerializeField] int maxMP = 1000;
    [SerializeField] int damage;
    [SerializeField] int defence;
    [SerializeField] int weaponPwr;
    [SerializeField] int armorPwr;
    [SerializeField] string equippedWeapon;
    [SerializeField] string equippedArmor;
    [SerializeField] Sprite characterImage;


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
        if(currentExp > expToLevelUp[playerLevel])
        {
            currentExp -= expToLevelUp[playerLevel];
            playerLevel++;
        }
    }
}
