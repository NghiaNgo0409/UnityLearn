using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory.Data
{
    [CreateAssetMenu(fileName = "ConsumableDataConfig", menuName = "Config/ConsumableDataConfig")]
    public class ConsumableDataConfig : ItemDataConfig
    {
        public int consumeValue;
    }
}
