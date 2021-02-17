using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //var
    public CharacterController control;

    public float speed = 12f;
    public float gravity = -9.81f;

    public float jumpheight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public Vector3 Crouch;
    public Vector3 UnCrouched;

    Vector3 velocity;
    bool isGrounded;

    void Start()
    {
        Crouch = new Vector3(1f, 0.5f, 1f);
        UnCrouched = new Vector3(1f, 1.5f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        //gravity
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        //jump
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpheight * -2f * gravity);
        }
        //basic movement
        float X = Input.GetAxis("Horizontal");
        float Z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * X + transform.forward * Z;

        control.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        control.Move(velocity * Time.deltaTime);

        //sprint
        if(Input.GetKey(KeyCode.Q) == true && Input.GetKey(KeyCode.W) == true && isGrounded)
        {
            speed = 20f;
            gameObject.transform.localScale = UnCrouched;

        }
        //crouch
        if (Input.GetKey(KeyCode.LeftControl) == true && Input.GetKey(KeyCode.W) == true && isGrounded)
        {
            speed = 7f;
            gameObject.transform.localScale = Crouch;

        }

        //normal
        else if (Input.GetKey(KeyCode.W) == true && Input.GetKey(KeyCode.LeftControl) == false && Input.GetKey(KeyCode.Q) == false && isGrounded)
        {
            speed = 12f;
            gameObject.transform.localScale = UnCrouched;
        }
    }
}
