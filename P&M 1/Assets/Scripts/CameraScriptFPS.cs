using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScriptFPS : MonoBehaviour
{
    //Var
    float rotationOnX;
    float MouseSensitivity = 90f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //mouse Input
        float mouseY = Input.GetAxis("MouseY") * Time.deltaTime * MouseSensitivity;
        float mouseX = Input.GetAxis("MouseX") * Time.deltaTime * MouseSensitivity;

        //Rotate Cam up + down
        rotationOnX -= mouseY;
        rotationOnX = Mathf.Clamp(rotationOnX, -90f, 90f);
        transform.localEulerAngles = new Vector3(rotationOnX, 0f, 0f);
    }
}
