using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory.Data
{
    [CreateAssetMenu(fileName = "EquipmentDataConfig", menuName = "Config/EquipmentDataConfig")]
    public class EquipmentDataConfig : ItemDataConfig
    {
        public int damage;
        public int defense;
        public int durable;
    }
}
