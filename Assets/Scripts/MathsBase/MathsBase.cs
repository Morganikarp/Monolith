using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class MathsBase : MonoBehaviour
{
    public class Vect2
    {
        // Type definition
        public float x; public float y;
        public Vect2(float xVal, float yVal) // Define Vector2
        {x = xVal;y = yVal;}

        //Functions
        public static float Mag(Vect2 Vect)  // Vector2 Magnitude
        {return MathF.Sqrt(MathF.Pow(Vect.x, 2) + MathF.Pow(Vect.y, 2));}

        public static Vect2 Add(Vect2 Vec1, Vect2 Vec2) // Vector2 Addition
        {return new Vect2(Vec1.x - Vec2.x, Vec1.y - Vec2.y);}

        public static Vect2 Sub(Vect2 Vec1, Vect2 Vec2) // Vector2 Subtraction
        {return new Vect2(Vec1.x - Vec2.x, Vec1.y - Vec2.y);}

        public static Vect2 Mult(Vect2 Vec1, Vect2 Vec2) // Vector2 Multiplication
        {return new Vect2(Vec1.x * Vec2.x, Vec1.y * Vec2.y);}

        public static Vect2 Div(Vect2 Vec1, Vect2 Vec2) // Vector2 Division
        {return new Vect2(Vec1.x / Vec2.x, Vec1.y / Vec2.y);}

        public static Vect2 DuoMidpoint(Vect2 Vec1, Vect2 Vec2)
        {return new Vect2((Vec1.x + Vec2.x) / 2, (Vec1.x + Vec2.x) / 2);} // Midpoint of two Vector2's

        // Setting Operators
        public static Vect2 operator +(Vect2 Vec1, Vect2 Vec2)
        { return Add(Vec1, Vec2); }
        public static Vect2 operator -(Vect2 Vec1, Vect2 Vec2)
        { return Sub(Vec1, Vec2); }
        public static Vect2 operator *(Vect2 Vec1, Vect2 Vec2)
        { return Mult(Vec1, Vec2); }
        public static Vect2 operator /(Vect2 Vec1, Vect2 Vec2)
        { return Div(Vec1, Vec2); }
    }

    public class Vect3
    {
        // Type definition
        public float x; public float y; public float z;
        public Vect3(float xVal, float yVal, float zVal) // Define Vector3
        {x = xVal;y = yVal;z = zVal;}

        // Functions
        public static Vector3 ConvertToUnity(Vect3 Vect) // Convert custom Vect3 to Vector3
        { return new Vector3(Vect.x, Vect.y, Vect.z);}

        public static float Mag(Vect3 Vect) // Vector3 Magnitude
        {return MathF.Sqrt(MathF.Pow(Vect.x, 2) + MathF.Pow(Vect.y, 2) + MathF.Pow(Vect.z, 2));}

        public static Vect3 Add(Vect3 Vec1, Vect3 Vec2) // Vector3 Addition
        {return new Vect3(Vec1.x + Vec2.x, Vec1.y + Vec2.y, Vec1.z + Vec2.z);}

        public static Vect3 Sub(Vect3 Vec1, Vect3 Vec2) // Vector3 Subtraction
        {return new Vect3(Vec1.x - Vec2.x, Vec1.y - Vec2.y, Vec1.z - Vec2.z);}

        public static Vect3 Mult(Vect3 Vec1, Vect3 Vec2) // Vector3 Multiplication
        {return new Vect3(Vec1.x * Vec2.x, Vec1.y * Vec2.y, Vec1.z * Vec2.z);}

        public static Vect3 Div(Vect3 Vec1, Vect3 Vec2) // Vector3 Division
        {return new Vect3(Vec1.x / Vec2.x, Vec1.y / Vec2.y, Vec1.z / Vec2.z);}

        public static Vect3 DuoMidpoint(Vect3 Vec1, Vect3 Vec2)
        { return new Vect3((Vec1.x + Vec2.x) / 2, (Vec1.x + Vec2.x) / 2, (Vec1.z + Vec2.z) / 2); } // Midpoint of two Vector3's

        public static Vect3 ArrayMidpoint(Vect3[] VecArray) // Midpoint of array of Vector3's
        {
            float xPos = 0; float yPos = 0; float zPos = 0;
            for (int i = 0; i < VecArray.Length; i++) { xPos += VecArray[i].x; yPos += VecArray[i].y; zPos += VecArray[i].z; }
            return new Vect3(xPos / VecArray.Length, yPos / VecArray.Length, zPos / VecArray.Length);
        }

        public static Vector3[] FindNormals(Vect3[] VecArray)
        {
            Vector3[] result = new Vector3[VecArray.Length];
            //Vect3[] vectCollect = new Vect3[4];
            //int VectsCheck = 0;
            //int normalCount = 0;
            for (int i = 0; i < VecArray.Length; i++)
            {
                result[i] = Vect3.ConvertToUnity(VecArray[i]) - new Vector3(.5f, .5f, .5f);
                //if (VectsCheck == 3)
                //{
                //    result[normalCount] = Vect3.ConvertToUnity(VecArray) - new Vector3(.5f, .5f, .5f);
                //    vectCollect = new Vect3[4];
                //    normalCount++;
                //    VectsCheck = 0;
                //}
                //else
                //{
                //    vectCollect[VectsCheck] = VecArray[i];
                //    VectsCheck++;
                //}

                //VecArray[i] = Midpoint of face - Midpoint (of object)
            }
            return result;
        }

        public static Vector3[] ConvertToUnity(Vect3[] Vect) // Convert array of Vect3's to Unity Vector3's
        {
            Vector3[] result = new Vector3[Vect.Length];
            for (int i = 0; i < Vect.Length; i++)
            {
                result[i] = new Vector3(Vect[i].x, Vect[i].y, Vect[i].z);
            }
            return result;
        }

        // Setting Operators
        public static Vect3 operator +(Vect3 Vec1, Vect3 Vec2)
        { return Add(Vec1, Vec2); }
        public static Vect3 operator -(Vect3 Vec1, Vect3 Vec2)
        { return Sub(Vec1, Vec2); }
        public static Vect3 operator *(Vect3 Vec1, Vect3 Vec2)
        { return Mult(Vec1, Vec2); }
        public static Vect3 operator /(Vect3 Vec1, Vect3 Vec2)
        {return Div(Vec1, Vec2);}
    }

    public class Shape3D
    {
        public string shape; public Vect3[] vertices; public int[] tris;
        public Shape3D(string Preset, Vect3[] ObjVertices, int[] AssociatedTris)
        {
            switch (Preset)
            {
                case "Cube":
                    vertices = new Vect3[] {
                        new Vect3(1, 0, 1), new Vect3(1, 1, 1), new Vect3(0, 1, 1), new Vect3(0, 0, 1),
                        new Vect3(1, 0, 0), new Vect3(1, 0, 1), new Vect3(0, 0, 1), new Vect3(0, 0, 0),
                        new Vect3(0, 0, 0), new Vect3(0, 0, 1), new Vect3(0, 1, 1), new Vect3(0, 1, 0),
                        new Vect3(0, 1, 0), new Vect3(0, 1, 1), new Vect3(1, 1, 1), new Vect3(1, 1, 0),
                        new Vect3(1, 1, 0), new Vect3(1, 1, 1), new Vect3(1, 0, 1), new Vect3(1, 0, 0),
                        new Vect3(0, 0, 0), new Vect3(0, 1, 0), new Vect3(1, 1, 0), new Vect3(1, 0, 0)
                        };
                    tris = new int[] {
                        0, 1, 2, 0, 2, 3,
                        4, 5, 6, 4, 6, 7,
                        8, 9, 10, 8, 10, 11,
                        12, 13, 14, 12, 14, 15,
                        16, 17, 18, 16, 18, 19,
                        20, 21, 22, 20, 22, 23
                    };

                    //vertices = new Vect3[] {
                    //    new Vect3(0, 0, 0), new Vect3(0, 0, 1), new Vect3(0, 1, 1), new Vect3(0, 1, 0),
                    //    new Vect3(1, 0, 0), new Vect3(1, 0, 1), new Vect3(1, 1, 1), new Vect3(1, 1, 0),
                    //    };
                    //tris = new int[] {
                    //    5, 6, 2, 5, 2, 1,
                    //    4, 5, 1, 4, 1, 0,
                    //    0, 1, 2, 0, 2, 3,
                    //    3, 2, 4, 3, 4, 7,
                    //    7, 6, 5, 7, 5, 4,
                    //    0, 3, 6, 0, 6, 4
                    //    };

                    break;

                default:
                    vertices = ObjVertices;
                    tris = AssociatedTris;
                    break;
            }
        }
    }
}