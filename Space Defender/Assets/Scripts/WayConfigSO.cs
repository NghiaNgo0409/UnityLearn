using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Way Config", fileName = "New Way Config")]
public class WayConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float timeBetweenEnemySpawn;
    [SerializeField] float timeVariances;
    [SerializeField] float minimunTimeSpawn;

    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemy(int index)
    {
        return enemyPrefabs[index];
    }

    public Transform GetStartingWayPoint()
    {
        return pathPrefab.GetChild(0);
    }

    public List<Transform> GetWayPoints()
    {
        List<Transform> waypoints = new List<Transform>();
        foreach(Transform waypoint in pathPrefab)
        {
            waypoints.Add(waypoint);
        }
        return waypoints;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public float GetRandomTimeSpawn()
    {
        float spawnTime = Random.Range(timeBetweenEnemySpawn - timeVariances, timeBetweenEnemySpawn + timeVariances);
        return Mathf.Clamp(spawnTime, minimunTimeSpawn, float.MaxValue);
    }
}
