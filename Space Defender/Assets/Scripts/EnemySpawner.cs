using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WayConfigSO> wayConfigs;
    WayConfigSO currentWave;
    [SerializeField] float timeBetweenPaths;
    [SerializeField] bool isLooping;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemyWave());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemyWave()
    {
        do
        {
            foreach(WayConfigSO wave in wayConfigs)
            {
                currentWave = wave;
                for(int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(currentWave.GetEnemy(i), currentWave.GetStartingWayPoint().position, Quaternion.Euler(0,0,180), transform);
                    yield return new WaitForSeconds(currentWave.GetRandomTimeSpawn());
                }
                yield return new WaitForSeconds(timeBetweenPaths);
            }
        }
        while(isLooping);
    }

    public WayConfigSO GetCurrentWave()
    {
        return currentWave;
    }
}
