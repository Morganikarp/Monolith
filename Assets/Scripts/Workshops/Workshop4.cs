using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workshop4 : MonoBehaviour
{

    Vect3 targetPos = new(5,0,0);

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position = Vect3.Vect3ToUnity(Vect3.Lerp(Vect3.UnityToVect3(transform.position), targetPos, Time.deltaTime));
        }
    }
}
