using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboarding : MathsBase
{
    public GameObject Target;
    MeshFilter MF;
    Vect3[] ModelVertices;
    Vector3[] adjustedVerts;


    Vector3[] ModelSpaceVertices;

    void Start()
    {
        MF = GetComponent<MeshFilter>();

        ModelSpaceVertices = MF.mesh.vertices;
    }

    // Update is called once per frame
    void Update()
    {

        //Vect3 Forward = Vect3.UnityToVect3(transform.position - Target.transform.position);
        //Vect3 Right = Vect3.CrossProduct(Vect3.Up, Forward);
        //Vect3 Up = Vect3.CrossProduct(Forward, Right);

        //Matrix3x3 transformMat = new(Right, Up, Forward);

        //Vect3 worldVect = Matrix3x3.Mult(transformMat, Vect3.UnityToVect3(transform.position));

        //ModelVertices = Vect3.UnityToVect3Array(MF.mesh.vertices);

        //adjustedVerts = new Vector3[ModelVertices.Length];

        Vector3[] TransformedVertices = new Vector3[ModelSpaceVertices.Length];

        Matrix4x4 rotMatrix = Matrix4x4.RotMat;

        //Matrix4x4 rolledMat = Matrix4x4.RollMat(Vect3.ToRadian(Right));
        //Matrix4x4 pitchedMat = Matrix4x4.PitchMat(Vect3.ToRadian(Forward));
        //Matrix4x4 yawedMat = Matrix4x4.YawMat(Vect3.ToRadian(Up));

        for (int i = 0; i < TransformedVertices.Length; i++)
        {
            //Vector3 RolledVert = Vect3.Vect3ToUnity(Matrix4x4.Mult(rolledMat, ModelVertices[i]));
            //Vector3 PitchedVert = Vect3.Vect3ToUnity(Matrix4x4.Mult(pitchedMat, Vect3.UnityToVect3(RolledVert)));
            //Vector3 YawedVert = Vect3.Vect3ToUnity(Matrix4x4.Mult(yawedMat, Vect3.UnityToVect3(PitchedVert)));
            //adjustedVerts[i] = YawedVert;

            //TransformedVertices[i] = Vect3.Vect3ToUnity(Matrix4x4.Mult(rotMatrix, ModelVertices[i]));

            TransformedVertices[i] = Vect3.Vect3ToUnity(Matrix4x4.Mult(rotMatrix, Vect3.UnityToVect3(ModelSpaceVertices[i])));
        }

        MF.mesh.vertices = TransformedVertices;
        MF.mesh.RecalculateNormals();
        MF.mesh.RecalculateBounds();
    }
}
