using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationAxis : MonoBehaviour
{
    [SerializeField] Vector3 _axis;
    [SerializeField] float _rotSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(_axis, _rotSpeed);
    }

    [ContextMenu("PrintRot")]
    void PrintRot()
    {
        Debug.Log($"Rotation quartenion: {transform.rotation}");
        Debug.Log($"Rotation euler: {transform.rotation.eulerAngles}");

        // From euler to Quaternion.
        Vector3 eulerRot = new Vector3(0f, 90f, 0f);
        var eulerConverted = Quaternion.Euler(eulerRot);
        transform.rotation = eulerConverted;

        // From quaternion to euler.
        var euler = transform.rotation.eulerAngles;
    }
}
