using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WayConfigSO> wayConfigs;
    WayConfigSO currentWave;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemy()
    {
        for(int i = 0; i < currentWave.GetEnemyCount(); i++)
        {
            Instantiate(currentWave.GetEnemy(i), currentWave.GetStartingWayPoint().position, Quaternion.identity, transform);
            yield return new WaitForSeconds(currentWave.GetRandomTimeSpawn());
        }
    }

    public WayConfigSO GetCurrentWave()
    {
        return currentWave;
    }
}
