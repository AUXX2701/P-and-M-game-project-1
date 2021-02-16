using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsCam : MonoBehaviour
{
    public float MouseSensitivity = 100f;

    public Transform PlayerBody; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("MouseX") * MouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("MouseY") * MouseSensitivity * Time.deltaTime;

        PlayerBody.Rotate(Vector3.up * mouseX);
    }
}
