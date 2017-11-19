using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveWithinBounds : MonoBehaviour
{
    public float movementSpeed = 30f;
    public float zoomSensitivity = 20f;
    public CameraBounds bounds;

    public Vector3 cameraRotation;

    public RotationalAxis axis = RotationalAxis.MouseX;
    public float sensitivityX = 15f;
    public float sensitivityY = 15f;
    public bool invertY = false;
    public bool invertX = false;
    private float rotationY = 0;
    private float rotationX = 0;
    private float currentX = 0f;

    public enum RotationalAxis
    {
        MouseXandY = 0,
        MouseX = 1,
        MouseY = 2
    }

    private void Start()
    {
        cameraRotation = transform.eulerAngles;
    }

    void Update()
    {
        Vector3 pos = transform.position;  // store position in smaller variable
        float inputH = Input.GetAxis("Horizontal");  // get input
        float inputV = Input.GetAxis("Vertical");

        Vector3 inputDir = new Vector3(inputH, 0, inputV);  // store input in vector (for movement)
        inputDir = transform.TransformDirection(inputDir);
        pos += inputDir * movementSpeed * Time.deltaTime;

        float inputScroll = Input.GetAxis("Mouse ScrollWheel") * zoomSensitivity;  // get scroll wheel
        Vector3 scrollDir = Camera.main.transform.forward * inputScroll;
        pos += scrollDir;

        pos = bounds.GetAdjustedPos(pos);  // overwrite original position with adjustedPos
        transform.position = pos;

        if (Input.GetMouseButton(1))
        {
            currentX += Input.GetAxis("Mouse X") * sensitivityX * Time.deltaTime;
        }
        if (Input.GetMouseButton(1))
        {
            float inputX = Input.GetAxis("Mouse X");
            float inputY = Input.GetAxis("Mouse Y");

            // Ternary Operator <condition> ? <statement a> : <statement b>
            inputX = invertX ? -inputX : inputX;
            inputY = invertY ? -inputY : inputY;

            rotationY += inputX * sensitivityX;

            rotationX += inputY * sensitivityY;

            switch (axis)
            {
                case RotationalAxis.MouseXandY:
                    transform.eulerAngles = new Vector3(rotationX, rotationY, 0);
                    break;
                case RotationalAxis.MouseX:
                    transform.eulerAngles = new Vector3(cameraRotation.x, rotationY, 0);
                    break;
                case RotationalAxis.MouseY:
                    transform.eulerAngles = new Vector3(rotationX, cameraRotation.y, 0);
                    break;
                default:
                    break;
            }
        }
    }

}