using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera _Camera;
    private float xRotation = 0f;

    public float xSensitivity = 30f;
    public float ySensitivity = 30f;


    public void ProcessLook(Vector2 Input)
    {
        float MouseX = Input.x;
        float MouseY = Input.y;

        //Calculate camera rotation for looking up and down
        xRotation -= (MouseY * Time.deltaTime) * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        //Apply this to camera transform
        _Camera.transform.localRotation = Quaternion.Euler(xRotation, transform.rotation.y, transform.rotation.z);

        //Calculate camera rotation for looking left and right
        transform.Rotate(Vector3.up * (MouseX * Time.deltaTime) * xSensitivity);
    }
}
