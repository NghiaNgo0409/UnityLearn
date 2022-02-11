using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] GameObject platformPrefabs;
    float size;
    Vector3 lastPos;
    // Start is called before the first frame update
    void Start()
    {
        lastPos = platformPrefabs.transform.position;
        size = platformPrefabs.transform.localScale.x;
        InvokeRepeating("SpawnPlatform", 0.1f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnPlatform()
    {
        int rand = Random.Range(0, 6);
        if(rand <= 2)
        {
            SpawnX();
        }
        else
        {
            SpawnZ();
        }
    }

    void SpawnX()
    {
        Vector3 currentPos = lastPos;
        currentPos.x += size;
        lastPos = currentPos;
        Instantiate(platformPrefabs, currentPos, Quaternion.identity);
    }

    void SpawnZ()
    {
        Vector3 currentPos = lastPos;
        currentPos.z += size;
        lastPos = currentPos;
        Instantiate(platformPrefabs, currentPos, Quaternion.identity);
    }
}
