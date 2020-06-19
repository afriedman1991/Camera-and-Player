using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Objects
    public Transform cam;
    CharacterController mover;

    // Camera
    Vector3 camF;
    Vector3 camR;

    // Input
    Vector2 input;

    // Physics
    Vector3 intent;
    Vector3 velocity;
    float speed = 5;
    float acc = 8;
    float turnSpeed = 5;

    void Start()
    {
        mover = GetComponent<CharacterController>();
    }

    void Update()
    {
        DoInput();
        CalculateCamera();
        DoMove();
    }

    void DoInput()
    {
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        input = Vector2.ClampMagnitude(input, 1);
    }

    void CalculateCamera()
    {
        camF = cam.forward;
        camR = cam.right;

        camF.y = 0;
        camR.y = 0;
        camF = camF.normalized;
        camR = camR.normalized;
    }

    void DoMove()
    {
        intent = camF * input.y + camR * input.x;

        if (input.magnitude > 0)
        {
            Quaternion rot = Quaternion.LookRotation(intent);
            transform.rotation = Quaternion.Lerp(transform.rotation, rot, turnSpeed * Time.deltaTime);
        }

        velocity = Vector3.Lerp(velocity, transform.forward * input.magnitude * speed, acc * Time.deltaTime);

        mover.Move(velocity * Time.deltaTime);
    }
}
