using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workshop3 : MonoBehaviour
{
    float Spd = 5;

    // Update is called once per frame
    void Update()
    {
        Vect3 eulAng = new Vect3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);
        Vect3 forwardDirection = Vect3.EulerAnglesToDirVect(eulAng, true);

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vect3.Vect3ToUnity(forwardDirection) * Spd * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= Vect3.Vect3ToUnity(forwardDirection) * Spd * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vect3.Vect3ToUnity(Vect3.CrossProduct(new(0,1,0), forwardDirection)) * Spd * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= Vect3.Vect3ToUnity(Vect3.CrossProduct(new(0, 1, 0), forwardDirection)) * Spd * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.eulerAngles += new Vector3(0f, (3f * Time.deltaTime) * (180 / MathF.PI), 0f);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            transform.eulerAngles -= new Vector3(0f, (3f * Time.deltaTime) * (180 / MathF.PI), 0f);
        }

    }
}
