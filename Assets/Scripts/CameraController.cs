using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float pitch = 2f;
    public float zoomSensitivity = 10f;
    public float minZoom = 5f;
    public float maxZoom = 20f;
    public float sensitivityX = 100f;
    public float panSpeed = 30f;
    public float panBorder = 10f;

    private float currentZoom = 10f;
    private float currentX = 0f;

    public Camera cam;
    float shakeAmount;

    private void Update()
    {
        CameraFollow();
        //CameraPan();
    }

    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Shake(0.1f, 0.2f);
        LateCameraFollow();
    }
    public void CameraFollow()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSensitivity;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        if (Input.GetMouseButton(2))
        {
            currentX += Input.GetAxis("Mouse X") * sensitivityX * Time.deltaTime;
        }
    }
    public void LateCameraFollow()
    {
        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position + Vector3.up * pitch);
        transform.RotateAround(target.position, Vector3.up, currentX);
    }
    public void Shake(float amount, float length)
    {
        shakeAmount = amount;

        InvokeRepeating("StartShake", 0f, 0.01f);
        Invoke("StopShake", length);
    }
    void StartShake()
    {
        if (shakeAmount >= 0)
        {
            Vector3 camPos = cam.transform.position;

            float shakeX = Random.Range(-1, 1) * shakeAmount * 5 - shakeAmount;
            float shakeY = Random.Range(-1, 1) * shakeAmount * 5 - shakeAmount;
            camPos.x += shakeX;
            camPos.y += shakeY;

            cam.transform.position = camPos;
        }
    }
    void StopShake()
    {
        CancelInvoke("StartShake");
        cam.transform.localPosition = offset;
    }
    //public void CameraPan()
    //{
    //    if (Input.mousePosition.y >= Screen.height - panBorder)
    //    {
    //        transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
    //    }
    //    if (Input.mousePosition.y <= panBorder)
    //    {
    //        transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
    //    }
    //    if (Input.mousePosition.x >= Screen.width - panBorder)
    //    {
    //        transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
    //    }
    //    if (Input.mousePosition.x <= panBorder)
    //    {
    //        transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
    //    }
    //}
}
