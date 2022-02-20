using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpeedSetting", menuName = "Tools/SpeedSetting")]
public class SpeedSetting : ScriptableObject
{
    [SerializeField] private float speed;
    public float Speed { get => speed; set => speed = value; }
    
}
