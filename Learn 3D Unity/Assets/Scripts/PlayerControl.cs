using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    private static PlayerControl instance;

    [SerializeField] CharacterController _charControl;
    [SerializeField] float _movementSpeed;
    [SerializeField] Camera _environmentCamera;

    [SerializeField] float _mouseSensitive;

    float _horizontalAngle;
    float _verticleAngle;

    public static PlayerControl Instance { get => instance;}

    void Awake() 
    {
        if(instance == null)
        {
            instance = this;
        }    
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
        UpdateRotation();
    }

    private void UpdateRotation()
    {
        var lookX = Input.GetAxis("Mouse X");
        var lookY = Input.GetAxis("Mouse Y");

        //Debug.Log($"mouse X: {lookX} mouse y: {lookY}");

        // Xoay truc ngang.
        // Thay doi goc dua tren truc ngang cua con chuot.
        _horizontalAngle += lookX * _mouseSensitive;
        // Lay eulerAngles ra de gan y = _horizontalAngle.
        Vector3 eulerAngles = transform.rotation.eulerAngles;
        eulerAngles.y = _horizontalAngle;
        // Gan lai gia tri eulerAngles da dc thay doi y vao lai transform.rotation
        transform.rotation = Quaternion.Euler(eulerAngles);

        // Xoay truc doc.
        _verticleAngle -= lookY * _mouseSensitive;
        _verticleAngle = Mathf.Clamp(_verticleAngle, -90f, 90f);
        var camAngles = _environmentCamera.transform.rotation.eulerAngles;
        camAngles.x = _verticleAngle;
        _environmentCamera.transform.rotation = Quaternion.Euler(camAngles);
    }

    private void UpdateMovement()
    {
        var directionX = Input.GetAxis("Horizontal");
        var directionY = Input.GetAxis("Vertical");

        //Vector3 direction = new Vector3(directionX, 0f, directionY);
        var direction = transform.forward * directionY + transform.right * directionX;
        //_charControl.Move(direction * Time.deltaTime * _movementSpeed);
        _charControl.SimpleMove(direction * _movementSpeed);
    }

    [ContextMenu("Test_Clamp")]
    void Test_Clamp()
    {
        var value = Mathf.Clamp(100, -90f, 90f);
        Debug.Log(value);
    }
}
