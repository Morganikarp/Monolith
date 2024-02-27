using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workshop4 : MathsBase
{

    Vect3 targetPos = new(5,0,0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position = Vect3.Vect3ToUnity(Vect3.Lerp(Vect3.UnityToVect3(transform.position), targetPos, Time.deltaTime));
        }
    }
}
