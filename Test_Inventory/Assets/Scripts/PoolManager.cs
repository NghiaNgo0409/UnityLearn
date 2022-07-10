using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField] GameObject cube;
    public int size;

    public static PoolManager instance;
    public bool isReady;
    public Queue<GameObject> poolObjs = new Queue<GameObject>();

    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        GenerateObj(size);
        isReady = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateObj(int size)
    {
        for (int i = 0; i < size; i++)
        {
            var obj = Instantiate(cube);
            obj.SetActive(false);
            poolObjs.Enqueue(obj);
        }
    }

    public GameObject SpawnObject(Vector3 pos)
    {
        if(poolObjs.Count > 0)
        {
            var cube = poolObjs.Dequeue();
            cube.transform.position = pos;
            cube.transform.rotation = Quaternion.identity;
            cube.SetActive(true);
            return cube;   
        }
        else
        {
            GenerateObj(15);
            return SpawnObject(pos);
        }
    }

    public void DespawnObject(GameObject obj)
    {
        obj.transform.position = Vector3.zero;
        obj.SetActive(false);
        poolObjs.Enqueue(obj);
    }
}
