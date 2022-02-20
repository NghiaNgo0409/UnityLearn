using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    public string myName;
    public int a;
    public int b;

    public float meters = 1.85F;

    [SerializeField]
    private int salary = 5000;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello world!!!");
        Debug.Log($"Hello {myName}!!!");    // Hay ghi kiểu này.
        Debug.Log("Hello " + myName);
        Debug.LogFormat("Hello {0}", myName);

        Debug.Log($"{a} + {b} = {a + b}");
        Debug.Log($"meters = {meters}");

        Debug.Log($"Salary: {salary}$");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Hello Long");
    }
}
