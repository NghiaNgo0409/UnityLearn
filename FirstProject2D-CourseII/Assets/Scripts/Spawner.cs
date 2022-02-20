using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _itemPrefabs;
    [SerializeField]
    private GameObject[] _damagePrefabs;
    [SerializeField]
    private float _spawnIntervalTime;

    private float _time;

    // Start is called before the first frame update
    void Start()
    {
        _spawnIntervalTime = Random.Range(1f, 3f);
        Spawn();
        _time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
        //Debug.Log($"Time: {_time}");
        if (_time >= _spawnIntervalTime)
        {
            Spawn();
            _spawnIntervalTime = Random.Range(1f, 3f);
            _time = 0f;
        }
    }

    public void Spawn()
    {
        int randNumber = Random.Range(0, 101);
        if (randNumber >= 50)
        {
            int rand = Random.Range(0, _itemPrefabs.Length);
            float randX = Random.Range(-7.5f, 7.5f);
            float randY = Random.Range(5f, 8f);
            Instantiate(_itemPrefabs[rand], new Vector2(randX, randY), _itemPrefabs[rand].transform.rotation);
        }
        else
        {
            int rand = Random.Range(0, _damagePrefabs.Length);
            float randX = Random.Range(-7.5f, 7.5f);
            float randY = Random.Range(5f, 8f);
            Instantiate(_damagePrefabs[rand], new Vector2(randX, randY), _damagePrefabs[rand].transform.rotation);
        }
    }
}
