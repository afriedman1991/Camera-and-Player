using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public Transform player;
    float heading = 0;

    void Update()
    {
        heading += Input.GetAxis("Mouse X") * Time.deltaTime * 180;
    }
}
