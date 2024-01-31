using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

class MakingCube : MathsBase
{
    public Material mat;
    Shape3D shape;
    MeshFilter MF;
    void Start()
    {
        GameObject Object = new GameObject();
        MF = Object.AddComponent<MeshFilter>();
        MeshRenderer MR = Object.AddComponent<MeshRenderer>();

        shape = new Shape3D(new Vect3(0,0,0), new Vect3(0, 0, 0), new Vect3(1, 1, 1), "Cube", null, null);

        MF.mesh.Clear();
        MF.mesh.vertices = Vect3.ConvertToUnity(shape.vertices);
        MF.mesh.triangles = shape.tris;
        MF.mesh.RecalculateNormals();
        MF.mesh.normals = Vect3.FindNormals(shape.vertices);
        MR.material = mat;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shape.SetPosition(new Vect3(0,5,0));
            MF.mesh.vertices = Vect3.ConvertToUnity(shape.vertices);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            shape.SetScale(new Vect3(2,2,2));
            MF.mesh.vertices = Vect3.ConvertToUnity(shape.vertices);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log(shape.FindMidpoint().x + " : " + shape.FindMidpoint().y + " : " + shape.FindMidpoint().z);
        }
    }

    void Gravity()
    {
        // (F)orce of gravity = ( (G)ravitational constant (6.67 x 10^-11) * (M)ass of earth (kg)) * (m)ass of object (kg) ) / r^2 (distance of object from earth^2 (m))
    }
}
