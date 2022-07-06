using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory.Data
{
    [CreateAssetMenu(fileName = "ItemDataConfig", menuName = "Config/ItemDataConfig")]
    public class ItemDataConfig : ScriptableObject
    {
        public int itemID;
        public ItemType itemType;
        public string itemName;
        public int buyGold;
        public int sellGold;
        public Sprite sprite;
        public string spritePath;
        public bool stackable;
        public string desc;
    }

    public enum ItemType
    {
        Equipment,
        Consumable,
    }
}