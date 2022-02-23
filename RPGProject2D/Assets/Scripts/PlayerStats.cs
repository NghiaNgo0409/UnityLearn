using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{   
    [SerializeField] int playerLevel;
    [SerializeField] int currentExp;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
