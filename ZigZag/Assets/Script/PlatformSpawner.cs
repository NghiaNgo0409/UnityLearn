using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] GameObject platformPrefabs;
    [SerializeField] GameObject diamondPrefabs;
    float size;
    Vector3 lastPos;
    // Start is called before the first frame update
    void Start()
    {
        lastPos = platformPrefabs.transform.position;
        size = platformPrefabs.transform.localScale.x;
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

        int rand = Random.Range(0, 4);
        if(rand < 1)
        {
            Instantiate(diamondPrefabs, new Vector3(currentPos.x, currentPos.y + 1.5f, currentPos.z), diamondPrefabs.transform.rotation);
        }
    }

    void SpawnZ()
    {
        Vector3 currentPos = lastPos;
        currentPos.z += size;
        lastPos = currentPos;
        Instantiate(platformPrefabs, currentPos, Quaternion.identity);
    }

    public void TurnOnSpawnPlatform()
    {
        InvokeRepeating("SpawnPlatform", 0.1f, 0.1f);
    }

    public void TurnOffSpawnPlatform()
    {
        StopCoroutine("SpawnPlatform");
    }
}
