using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboarding : MathsBase
{
    public GameObject Target;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vect3 distanceDif = Vect3.UnityToVect3(transform.position - Target.transform.position);
//        Vect3 R = Vect3.

    }
}
