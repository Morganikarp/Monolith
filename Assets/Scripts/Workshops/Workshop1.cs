using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MathsBase;

public class Workshop1 : MathsBase
{
    //Workshop 1
    public GameObject target;
    Vect3 targetPos;

    void Update()
    {
        targetPos = new Vect3(target.transform.position.x - transform.position.x, target.transform.position.y - transform.position.y, target.transform.position.z - transform.position.z);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position += Vect3.ConvertToUnity(targetPos);
        }
    }
}
