using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

class MakingCube : MathsBase
{
    void Start()
    {
        GameObject Object = new GameObject();
        MeshFilter MF = Object.AddComponent<MeshFilter>();
        MeshRenderer MR = Object.AddComponent<MeshRenderer>();

        Shape3D shape = new Shape3D("Cube", null, null);

        MF.mesh.Clear();
        MF.mesh.vertices = Shape3D.ConvertToUnity(shape.vertices);
        MF.mesh.triangles = shape.tris;
        MF.mesh.RecalculateNormals();

    }
}
