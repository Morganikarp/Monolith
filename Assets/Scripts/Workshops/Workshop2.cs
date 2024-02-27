using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workshop2 : MathsBase
{
    //Workshop 2
    public GameObject target;
    Vect3 targetPos;
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            targetPos = new Vect3(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-5, 5));
            target.transform.position = Vect3.Vect3ToUnity(targetPos);
        }

        Vect3 tarPos = new(target.transform.position.x , target.transform.position.y, target.transform.position.z);
        Vect3 chaPos = new(transform.position.x , transform.position.y, transform.position.z);

        Vect3 distDifVec = Vect3.Normalize(tarPos - chaPos);
        float distDifMag = Vect3.Mag(tarPos - chaPos);

        Vect3 haha = Vect3.ApplyScalar(distDifVec, 5* distDifMag * Time.deltaTime);

        transform.position = Vect3.Vect3ToUnity(chaPos + haha);

        //float answer = Vect2.DotProduct(new Vect2(25, 70), new Vect2(-25, -70), false);

        //Debug.Log(answer);

    }
}