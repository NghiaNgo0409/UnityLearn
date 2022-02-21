using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Tilemap themap;
    Vector3 bottomLeft;
    Vector3 topRight;

    float halfHeight;
    float halfWidth;
    // Start is called before the first frame update
    void Start()
    {
        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Camera.main.aspect;

        bottomLeft = themap.localBounds.min + new Vector3(halfWidth, halfHeight, transform.position.z);
        topRight = themap.localBounds.max + new Vector3(-halfWidth, -halfHeight, transform.position.z);

        PlayerController.instance.SetBound(themap.localBounds.min, themap.localBounds.max);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 pos = transform.position;
        pos = PlayerController.instance.transform.position;
        pos.z -= 10;
        transform.position = pos;

        LimitCamera();
    }

    void LimitCamera()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeft.x, topRight.x), Mathf.Clamp(transform.position.y, bottomLeft.y, topRight.y), transform.position.z);
    }
}
