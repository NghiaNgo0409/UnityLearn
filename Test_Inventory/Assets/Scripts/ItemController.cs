using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inventory.Data;
using UnityEngine.UI;
using TMPro;

namespace Inventory.Logic
{
    public class ItemController : MonoBehaviour
    {
        [Header("UI")]
        public Image itemImage;
        public TMP_Text txtItemName;
        public RectTransform tooltip;
        public TMP_Text txtDesc;
        public int[] posXToolTip;
        [Header("Item data")]
        public ItemType itemData;
        EquipmentDataConfig equipData;
        ConsumableDataConfig consumeData;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        public void Setup(ItemDataConfig data, int itemIndex)
        {
            itemData = data.itemType;
            if(data.itemType == ItemType.Equipment)
            {
                equipData = data as EquipmentDataConfig;
                txtItemName.SetText(equipData.itemName);
                txtDesc.SetText($"{equipData.desc} \n" +
                $"Damage {equipData.damage} \n" +
                $"Durable {equipData.durable}");
            }
            else if(data.itemType == ItemType.Consumable)
            {
                consumeData = data as ConsumableDataConfig;
                txtItemName.SetText(consumeData.itemName + "x10");
                if(consumeData.itemID == 1001)
                {
                    txtDesc.SetText($"{consumeData.desc} \n" +
                    $"HP restore {consumeData.consumeValue}");
                }
                else if(consumeData.itemID == 1002)
                {
                    txtDesc.SetText($"{consumeData.desc} \n" +
                    $"MP restore {consumeData.consumeValue}");
                }
            }
            itemImage.sprite = data.sprite;

            var newPos = new Vector2(posXToolTip[itemIndex], tooltip.anchoredPosition.y);
            tooltip.anchoredPosition = newPos;
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void OnPointerEnter()
        {
            tooltip.gameObject.SetActive(true);
        }

        public void OnPointerExit()
        {
            tooltip.gameObject.SetActive(false);
        }

        public void OnPointerDown()
        {
            Debug.Log("Use this one");
        }
    }
}
