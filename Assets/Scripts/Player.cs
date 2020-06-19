using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Objects
    public Transform camPivot;
    float heading = 0;
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
    float accel = 2;

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
        heading += Input.GetAxis("Mouse X") * Time.deltaTime * 180;
        camPivot.rotation = Quaternion.Euler(0, heading, 0);

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
        Vector3 intent = camF * input.y + camR * input.x;

        velocity = Vector3.Lerp(velocity, intent * speed, accel * Time.deltaTime);

        mover.Move(velocity * Time.deltaTime);
    }
}
