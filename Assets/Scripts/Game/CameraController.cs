using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MathsBase
{

    float posAngle;
    float rotationAngle;
    float angle;
    float finalAngle;
    float speed = 5;
    float targetDif = 0.01f;
    Vector3 targetPos;
    bool moving = false;

    void Start()
    {
        posAngle = -90;
        rotationAngle = 0;
        angle = -90;
        finalAngle = 0;

        transform.position = new(20 * MathF.Cos(angle * (MathF.PI / 180)), 20, 20 * MathF.Sin(angle * (MathF.PI / 180)));
        transform.rotation = Quaternion.Euler(10, rotationAngle, 0);
    }

    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            posAngle += 90f;
            rotationAngle -= 90f;
            moving = true;
        }
        
        if (Input.GetKeyDown("q"))
        {
            posAngle -= 90f;
            rotationAngle += 90f;
            moving = true;
        }

        if (moving)
        {
            angle = Mathf.Lerp(angle, posAngle, Time.deltaTime * speed);
            targetPos = new(20 * MathF.Cos(angle * (MathF.PI / 180)), 20, 20 * MathF.Sin(angle * (MathF.PI / 180)));
            transform.position = targetPos;


            finalAngle = Mathf.Lerp(finalAngle, rotationAngle, Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(10, finalAngle, 0);

            ReachedTarget();

        }
    }

    void ReachedTarget()
    {
        int loops = (int)rotationAngle / 360;

        if (rotationAngle < 0)
        {
            if ((rotationAngle - targetDif) < (transform.eulerAngles.y - 360) + (360 * loops) && (transform.eulerAngles.y - 360) + (360 * loops) < (rotationAngle + targetDif))
            {
                transform.rotation = Quaternion.Euler(10, rotationAngle, 0);
                transform.position = new(20 * MathF.Cos(posAngle * (MathF.PI / 180)), 20, 20 * MathF.Sin(posAngle * (MathF.PI / 180))); ;
                moving = false;
            }
        }
        else
        {
            if ((rotationAngle - targetDif) < transform.eulerAngles.y + (360 * loops) && transform.eulerAngles.y + (360 * loops) < (rotationAngle + targetDif))
            {
                transform.rotation = Quaternion.Euler(10, rotationAngle, 0);
                transform.position = new(20 * MathF.Cos(posAngle * (MathF.PI / 180)), 20, 20 * MathF.Sin(posAngle * (MathF.PI / 180))); ;
                moving = false;
            }
        }

        // doesnt work for rotations at 0 when rotationAngle is below 0
    }
}
