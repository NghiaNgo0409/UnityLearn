using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{
    [SerializeField] int breakableBlocks;

    public void CountBreakableBlock()
    {
        breakableBlocks++;
    }
}
