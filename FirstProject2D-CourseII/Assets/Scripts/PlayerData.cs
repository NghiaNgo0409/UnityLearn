using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Tool/PlayerData")]
public class PlayerData : ScriptableObject
{

    [SerializeField]
    private float _speed;
    [SerializeField]
    private int _live;

    public float Speed { get => _speed; set => _speed = value; }
    public int Live { get => _live; set => _live = value; }


}
