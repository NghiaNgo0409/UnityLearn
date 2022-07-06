using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inventory.Data;

namespace Inventory.Logic
{
    public class InventoryController : MonoBehaviour
    {
        public ConsumableDataConfig[] consumableDataConfigs;
        public EquipmentDataConfig[] equipmentDataConfigs;

        public RectTransform content;
        public ItemController itemPrefab;
        // Start is called before the first frame update
        void Start()
        {
            int itemIndex = 0;
            foreach(var data in consumableDataConfigs)
            {
                var item = Instantiate(itemPrefab, content);
                item.Setup(data, itemIndex);
                itemIndex++;
            }

            foreach(var data in equipmentDataConfigs)
            {
                var item = Instantiate(itemPrefab, content);
                item.Setup(data, itemIndex);
                itemIndex++;
            }
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
