using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    [SerializeField] WayConfigSO wayConfig;
    List<Transform> waypoints;
    // Start is called before the first frame update
    void Start()
    {
        waypoints = wayConfig.GetWayPoints();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
