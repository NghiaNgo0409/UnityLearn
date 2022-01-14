using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{

    [SerializeField] int camera2DZoomSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Camera.main.orthographic)
        {
            if(Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                Camera.main.orthographicSize -= camera2DZoomSpeed * Time.deltaTime;
            }
            if(Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                Camera.main.orthographicSize += camera2DZoomSpeed * Time.deltaTime;
            }
        }
    }
}
