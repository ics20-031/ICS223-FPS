using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float sensitivityHoriz = 9.0f;
    public float sensitivityVert = 9.0f;

    public float minVert = -45.0f;
    public float maxVert = 45.0f;

    private float rotationX = 0.0f;

    public float speed = 9.0f;
    public float horizMove;
    public float vertMove;

    CharacterController character;

    public enum RotationAxes
    {
        MouseXAndY,
        MouseX,
        MouseY
    }

    void Start()
    {
    }

    public RotationAxes axes = RotationAxes.MouseXAndY;

    // Update is called once per frame
    void Update()
    {

        // camera rotation
        if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * sensitivityHoriz);
        } 
        else if (axes == RotationAxes.MouseY)
        {
            rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            rotationX = Mathf.Clamp(rotationX, minVert, maxVert);
            transform.localEulerAngles = new Vector3(rotationX, 0, 0);
        }
        else
        {
            transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * sensitivityHoriz);

            rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            rotationX = Mathf.Clamp(rotationX, minVert, maxVert);

            float deltaHoriz = Input.GetAxis("Mouse X") * sensitivityHoriz;
            float rotationY = transform.localEulerAngles.y + deltaHoriz;

            transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
        }


    }
}
