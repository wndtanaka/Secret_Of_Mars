using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Camera cam;
    float shakeAmount;
    // Use this for initialization
    void Awake()
    {
        // cam = Camera.main;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Shake(1f,0.1f);
    }
    public void Shake(float amount, float length)
    {
        shakeAmount = amount;

        InvokeRepeating("StartShake", 0f, 0.01f);
        Invoke("StopShake", length);
        Debug.Log("Shake Please");

    }
    void StartShake()
    {
        if (shakeAmount > 0)
        {
            Vector3 camPos = cam.transform.position;

            float shakeX = Random.value * shakeAmount * 2 - shakeAmount;
            float shakeY = Random.value * shakeAmount * 2 - shakeAmount;
            camPos.x += shakeX;
            camPos.y += shakeY;

            cam.transform.position = camPos;
        }
    }
    void StopShake()
    {
        CancelInvoke("StartShake");
        cam.transform.localPosition = Vector3.zero;
    }
}
