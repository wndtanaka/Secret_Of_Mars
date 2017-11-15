using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveWithinBounds : MonoBehaviour
{
    public float movementSpeed = 30f;
    public float zoomSensitivity = 20f;
    public CameraBounds bounds;

    public Vector3 cameraRotation;
    
    //public RotationalAxis axis = RotationalAxis.MouseX;
    public float sensitivityX = 15f;
    public float sensitivityY = 15f;
    public float minimumY = -60f;
    public float maximumY = 60f;
    private float rotationY = 0;
    private float currentX = 0f;

    //public enum RotationalAxis
    //{
    //    MouseXandY = 0,
    //    MouseX = 1,
    //    MouseY = 2
    //} 

    private void Start()
    {
        cameraRotation = transform.localEulerAngles;
    }

    void Update()
    {
        Vector3 pos = transform.position;  // store position in smaller variable
        float inputH = Input.GetAxis("Horizontal");  // get input
        float inputV = Input.GetAxis("Vertical");

        Vector3 inputDir = new Vector3(inputH, 0f, inputV);  // store input in vector (for movement)
        pos += inputDir * movementSpeed * Time.deltaTime;

        float inputScroll = Input.GetAxis("Mouse ScrollWheel") * zoomSensitivity;  // get scroll wheel
        Vector3 scrollDir = transform.forward * inputScroll;
        pos += scrollDir;

        pos = bounds.GetAdjustedPos(pos);  // overwrite original position with adjustedPos
        transform.position = pos;

        if (Input.GetMouseButton(1))
        {
            currentX += Input.GetAxis("Mouse X") * sensitivityX * Time.deltaTime;
        }
        //if (axis == RotationalAxis.MouseX && Input.GetMouseButton(1))
        //{
        //    rotationY += Input.GetAxis("Mouse X") * sensitivityX;
        //    rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
        //    transform.localEulerAngles = new Vector3(cameraRotation.x, rotationY, 0);
        //    //transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
        //} 
    }
    private void LateUpdate()
    {
        //transform.LookAt(transform.position + Vector3.up);
        transform.RotateAround(Camera.main.transform.position , Vector3.down, currentX);
    }
}