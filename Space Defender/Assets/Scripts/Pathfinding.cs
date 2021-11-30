using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    EnemySpawner currentWave;
    WayConfigSO wayConfig;
    List<Transform> waypoints;
    int waypointIndex = 0;
    void Awake() 
    {
        currentWave = FindObjectOfType<EnemySpawner>();    
    }
    // Start is called before the first frame update
    void Start()
    {
        wayConfig = currentWave.GetCurrentWave();
        waypoints = wayConfig.GetWayPoints();
        transform.position = waypoints[waypointIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        FindPath();
    }
    
    void FindPath()
    {
        if(waypointIndex < waypoints.Count)
        {
            Vector3 targetPosition = waypoints[waypointIndex].position;
            float delta = wayConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, delta);
            if(transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
