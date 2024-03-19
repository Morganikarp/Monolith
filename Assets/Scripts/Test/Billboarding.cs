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

        if (Matrix3x3.GrandSum(RUFmat) != Matrix3x3.GrandSum(oldRUFmat))
        {
            for (int i = 0; i < ModelSpaceVertices.Length; i++)
            {
                AdjustedVerts[i] = Vect3.Vect3ToUnity(Matrix3x3.Mult(RUFmat, ModelSpaceVertices[i]));
            }

            MF.mesh.vertices = AdjustedVerts;
            MF.mesh.RecalculateNormals();
            MF.mesh.RecalculateBounds();

            oldRUFmat = RUFmat;
        }
    }
}
