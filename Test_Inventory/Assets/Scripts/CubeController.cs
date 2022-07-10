using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable() 
    {
        StartCoroutine(Hide());
    }

    private void OnDisable() 
    {
        
    }

    IEnumerator Hide()
    {
        yield return new WaitForSeconds(15f);
        PoolManager.instance.DespawnObject(gameObject);
    }
}
