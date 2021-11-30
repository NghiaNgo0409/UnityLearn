using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] WayConfigSO currentWave;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        for(int i = 0; i < currentWave.GetEnemyCount(); i++)
        {
            Instantiate(currentWave.GetEnemy(i), currentWave.GetStartingWayPoint().position, Quaternion.identity, transform);
        }
    }

    public WayConfigSO GetCurrentWave()
    {
        return currentWave;
    }
}
