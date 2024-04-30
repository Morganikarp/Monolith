using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboarding : MathsBase
{
    public GameObject Target;
    MeshFilter MF;

    Vector3[] AdjustedVerts;
    Vect3[] ModelSpaceVertices;

    Matrix3x3 RUFmat;
    Matrix3x3 oldRUFmat;

    void Start()
    {
        MF = GetComponent<MeshFilter>();

        ModelSpaceVertices = Vect3.UnityToVect3Array(MF.mesh.vertices);
        AdjustedVerts = new Vector3[ModelSpaceVertices.Length];
        oldRUFmat = Matrix3x3.Zero;
    }

    // Update is called once per frame
    void Update()
    {

        Vect3 Forward = Vect3.Normalize(Vect3.UnityToVect3(transform.position - Target.transform.position));
        Vect3 Right = Vect3.Normalize(Vect3.CrossProduct(Vect3.Up, Forward));
        Vect3 Up = Vect3.Normalize(Vect3.CrossProduct(Forward, Right));

        RUFmat = new(Right, Up, Forward);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("1: " + ModelSpaceVertices[0].x + "   " + ModelSpaceVertices[0].y + "   " + ModelSpaceVertices[0].z);
            //Debug.Log("2: " + ModelSpaceVertices[1].x + "   " + ModelSpaceVertices[1].y + "   " + ModelSpaceVertices[1].z);
            //Debug.Log("3: " + ModelSpaceVertices[2].x + "   " + ModelSpaceVertices[2].y + "   " + ModelSpaceVertices[3].z);
            //Debug.Log("4: " + ModelSpaceVertices[3].x + "   " + ModelSpaceVertices[3].y + "   " + ModelSpaceVertices[3].z);
            
            Debug.Log("Forward: " + Forward.x + "   " + Forward.y + "   " + Forward.z);
            Debug.Log("Right: " + Right.x + "   " + Right.y + "   " + Right.z);
            Debug.Log("Up: " + Up.x + "   " + Up.y + "   " + Up.z);
        }

        if (Matrix3x3.GrandSum(RUFmat) != Matrix3x3.GrandSum(oldRUFmat))
        {
            for (int i = 0; i < ModelSpaceVertices.Length; i++)
            {
                AdjustedVerts[i] = Vect3.Vect3ToUnity(Matrix3x3.Mult(RUFmat, ModelSpaceVertices[i]));
            }

            //MF.mesh.vertices = AdjustedVerts;
            MF.mesh.SetVertices(AdjustedVerts);
            MF.mesh.RecalculateNormals();
            MF.mesh.RecalculateBounds();

            oldRUFmat = RUFmat;
        }
    }
}
