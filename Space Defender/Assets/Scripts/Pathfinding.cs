using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    [SerializeField] WayConfigSO wayConfig;
    List<Transform> waypoints;
    int waypointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        waypoints = wayConfig.GetWayPoints();
        transform.position = waypoints[waypointIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
