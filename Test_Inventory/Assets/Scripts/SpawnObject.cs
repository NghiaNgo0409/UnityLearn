using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] GameObject cube;
    WaitForSeconds waitingTime = new WaitForSeconds(.2f);
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawningObject());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawningObject()
    {
        yield return new WaitUntil(() => PoolManager.instance.isReady);
        while(true)
        {
            yield return waitingTime;
            PoolManager.instance.SpawnObject(Vector3.zero);
        }
    }
}
