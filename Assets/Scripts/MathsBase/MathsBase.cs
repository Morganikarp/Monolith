using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UIElements;

public class MathsBase : MonoBehaviour
{
    public class Vect2
    {
        // Type definition
        public float x; public float y;
        public Vect2(float xVal, float yVal) // Define Vect2
        {x = xVal;y = yVal;}

        public static Vect2 Zero = new Vect2(0, 0);

        //Functions
        public static Vector2 Vect2ToUnity(Vect2 Vect) // Convert custom Vect2 to Vector2
        { return new Vector2(Vect.x, Vect.y); }
        public static Vect2 UnityToVect2(Vector2 Vect) // Convert Vector2 to custom Vect2
        { return new Vect2(Vect.x, Vect.y); }

        public static float Mag(Vect2 Vect)  // Vect2 Magnitude
        {return Vect.x * Vect.x + Vect.y * Vect.y;}

        public static float ToRadian(Vect2 Vect) // Convert a Vect2 to a radian angle
        {return MathF.Atan(Vect.y / Vect.x);}

        public static float ToDegree(Vect2 Vect) // Convert a Vect2 to a degree angle (converts radian angle to degrees)
        { return MathF.Atan(Vect.y / Vect.x) * (180 / MathF.PI);}

        public static Vect2 RadianToDirVect(float angle) // Convert a radian angle to a unit-length Vect2
        {return new Vect2(MathF.Cos(angle), MathF.Sin(angle));}
        public static Vect2 DegreeToDirVect(float angle) // Convert a radian angle to a unit-length Vect2 (converts degree input to radian before processing)
        {return new Vect2(MathF.Cos(angle * (MathF.PI / 180)), MathF.Sin(angle * (MathF.PI / 180))); }

        public static Vect2 Add(Vect2 Vec1, Vect2 Vec2) // Vect2 Addition
        {return new Vect2(Vec1.x - Vec2.x, Vec1.y - Vec2.y);}

        public static Vect2 Sub(Vect2 Vec1, Vect2 Vec2) // Vect2 Subtraction
        {return new Vect2(Vec1.x - Vec2.x, Vec1.y - Vec2.y);}

        public static Vect2 Mult(Vect2 Vec1, Vect2 Vec2) // Vect2 Multiplication
        {return new Vect2(Vec1.x * Vec2.x, Vec1.y * Vec2.y);}

        public static Vect2 Div(Vect2 Vec1, Vect2 Vec2) // Vect2 Division
        {return new Vect2(Vec1.x / Vec2.x, Vec1.y / Vec2.y);}

        public static Vect2 ApplyScalar(Vect2 Vec1, float Scl) //Application of scalar to Vect2
        { return new Vect2(Vec1.x * Scl, Vec1.y * Scl); }

        public static Vect2 ApplyDivisor(Vect2 Vec1, float Scl) //Application of divisor to Vect2
        { return new Vect2(Vec1.x / Scl, Vec1.y / Scl); }

        public static Vect2 DuoMidpoint(Vect2 Vec1, Vect2 Vec2)
        {return new Vect2((Vec1.x + Vec2.x) / 2, (Vec1.x + Vec2.x) / 2);} // Midpoint of two Vect2's

        public static Vect2 Normalize(Vect2 Vec1) // Normalize Vect2
        { return ApplyDivisor(Vec1, Mag(Vec1)); }

        public static float DotProduct(Vect2 Vec1, Vect2 Vec2, bool Normalised)
        {
            Vect2 v1 = Vec1;
            Vect2 v2 = Vec2;

            if (!Normalised)
            {
                v1 = Normalize(Vec1);
                v2 = Normalize(Vec2);
            }

            return (v1.x * v2.x) + (v1.y * v2.y);
        }

        public static Vect2 Lerp(Vect2 CurrentPos, Vect2 DesiredPos, float stepVal)
        {
            return Vect2.ApplyScalar(CurrentPos, (1 - stepVal)) + Vect2.ApplyScalar(CurrentPos, stepVal);
        }

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
        public Vect3(float xVal, float yVal, float zVal) // Define Vect3
        {x = xVal;y = yVal;z = zVal;}

        public static Vect3 Zero = new Vect3(0, 0, 0);
        public static Vect3 Forward = new Vect3(0, 0, 1);
        public static Vect3 Up = new Vect3(0, 1, 0);
        public static Vect3 Right = new Vect3(1, 0, 0);

        // Functions
        public static Vector3 Vect3ToUnity(Vect3 Vect) // Convert custom Vect3 to Vector3
        { return new Vector3(Vect.x, Vect.y, Vect.z);}

        public static Vector3[] Vect3ToUnityArray(Vect3[] Vect) // Convert array of custom Vect3 to Vector3 array
        {
            Vector3[] result = new Vector3[Vect.Length];
            for (int i = 0; i < Vect.Length; i++)
            {
                result[i] = new Vector3(Vect[i].x, Vect[i].y, Vect[i].z);
            }
            return result;
        }

        public static Vect3 UnityToVect3(Vector3 Vect) // Convert Vector3 to custom Vect3
        { return new Vect3(Vect.x, Vect.y, Vect.z); }

        public static Vect3[] UnityToVect3Array(Vector3[] Vect) // Convert array of custom Vect3 to Vector3 array
        {
            Vect3[] result = new Vect3[Vect.Length];
            for (int i = 0; i < Vect.Length; i++)
            {
                result[i] = new Vect3(Vect[i].x, Vect[i].y, Vect[i].z);
            }
            return result;
        }

        public static float Mag(Vect3 Vect) // Vect3 Magnitude
        {return MathF.Sqrt(Vect.x * Vect.x + Vect.y * Vect.y + Vect.z * Vect.z);}

        public static float ToRadian(Vect3 Vect) // Convert a Vect3 to a radian angle
        { return MathF.Atan(Vect.y / Vect.x / Vect.z);}

        public static float ToDegree(Vect3 Vect) // Convert a Vect3 to a degree angle (converts radian angle to degrees)
        { return MathF.Atan(Vect.y / Vect.x / Vect.z) * (180 / MathF.PI);}

        public static Vect3 EulerAnglesToDirVect(Vect3 Vect) //Converts a Vect3 euler angle into a Vect3 directional vector (converts degree angles to radians before processing)
        {
            Vect3 result = Zero;
            Vect3 adjustedVect = ApplyScalar(Vect, (MathF.PI / 180));

            result.z = MathF.Cos(adjustedVect.y) * MathF.Cos(adjustedVect.x);
            result.y = MathF.Sin(adjustedVect.x);
            result.x = MathF.Cos(adjustedVect.x) * MathF.Sin(adjustedVect.y);

            // X axis (Pitch) : Left/Right
            // Y axis (Yaw) : Up/Down
            // Z axis (Roll) : Forward/Back

            // Standard order of euler angles in Vect3:
                // Forward/Back : Cos( Yaw ) * Cos ( Pitch )
                // Up/Down : Sin ( Pitch )
                // Foward/Back : Cos ( Pitch ) * Sin ( Yaw )

            return result;
        }

        public static Vect3 Add(Vect3 Vec1, Vect3 Vec2) // Vect3 Addition
        {return new Vect3(Vec1.x + Vec2.x, Vec1.y + Vec2.y, Vec1.z + Vec2.z);}

        public static Vect3 Sub(Vect3 Vec1, Vect3 Vec2) // Vect3 Subtraction
        {return new Vect3(Vec1.x - Vec2.x, Vec1.y - Vec2.y, Vec1.z - Vec2.z);}

        public static Vect3 Mult(Vect3 Vec1, Vect3 Vec2) // Vect3 Multiplication
        {return new Vect3(Vec1.x * Vec2.x, Vec1.y * Vec2.y, Vec1.z * Vec2.z);}

        public static Vect3 Div(Vect3 Vec1, Vect3 Vec2) // Vect3 Division
        {return new Vect3(Vec1.x / Vec2.x, Vec1.y / Vec2.y, Vec1.z / Vec2.z);}

        public static Vect3 ApplyScalar(Vect3 Vec1, float Scl) //Application of scalar to Vect3
        {return new Vect3(Vec1.x * Scl, Vec1.y * Scl, Vec1.z * Scl);}

        public static Vect3 ApplyDivisor(Vect3 Vec1, float Scl) //Application of divisor to Vect3
        { return new Vect3(Vec1.x / Scl, Vec1.y / Scl, Vec1.z / Scl); }

        public static Vect3 DuoMidpoint(Vect3 Vec1, Vect3 Vec2)
        { return new Vect3((Vec1.x + Vec2.x) / 2, (Vec1.y + Vec2.y) / 2, (Vec1.z + Vec2.z) / 2); } // Midpoint of two Vect3's

        public static Vect3 ArrayMidpoint(Vect3[] VecArray) // Midpoint of array of Vect3's
        {
            float xPos = 0; float yPos = 0; float zPos = 0;
            for (int i = 0; i < VecArray.Length; i++) { xPos += VecArray[i].x; yPos += VecArray[i].y; zPos += VecArray[i].z; }
            return new Vect3(xPos / VecArray.Length, yPos / VecArray.Length, zPos / VecArray.Length);
        }

        public static Vect3 Normalize(Vect3 Vec1) // Normalize Vect3
        { return ApplyDivisor(Vec1, Mag(Vec1)); }

        public static Vector3[] FindNormals(Vect3[] VecArray)
        {
            Vector3[] result = new Vector3[VecArray.Length];
            //Vect3[] vectCollect = new Vect3[4];
            //int VectsCheck = 0;
            //int normalCount = 0;
            for (int i = 0; i < VecArray.Length; i++)
            {
                result[i] = Vect3.Vect3ToUnity(VecArray[i]) - new Vector3(.5f, .5f, .5f);
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

        public static float DotProduct(Vect3 Vec1, Vect3 Vec2, bool Normalised)
        {
            Vect3 v1 = Vec1;
            Vect3 v2 = Vec2;

            if (!Normalised)
            {
                v1 = Normalize(Vec1);
                v2 = Normalize(Vec2);
            }

            return (v1.x * v2.x) + (v1.y * v2.y) + (v1.z * v2.z);
        }

        public static Vect3 CrossProduct(Vect3 Vec1,  Vect3 Vec2)
        {
            Vect3 result = new(0, 0, 0);

            result.x = Vec1.y * Vec2.z - Vec1.z * Vec2.y;
            result.y = Vec1.z * Vec2.x - Vec1.x * Vec2.z;
            result.z = Vec1.x * Vec2.y - Vec1.y * Vec2.x;

            return result;
        }
        public static Vect3 Lerp(Vect3 CurrentPos, Vect3 DesiredPos, float stepVal)
        {
            return Vect3.ApplyScalar(CurrentPos, (1 - stepVal)) + Vect3.ApplyScalar(DesiredPos, stepVal);
        }

        // Setting Operators
        public static Vect3 operator +(Vect3 Vec1, Vect3 Vec2)
        { return Add(Vec1, Vec2); }
        public static Vect3 operator -(Vect3 Vec1, Vect3 Vec2)
        { return Sub(Vec1, Vec2); }
        public static Vect3 operator *(Vect3 Vec1, Vect3 Vec2)
        { return Mult(Vec1, Vec2); }
        public static Vect3 operator *(Vect3 Vec1, float Scl)
        { return ApplyScalar(Vec1, Scl); }
        public static Vect3 operator /(Vect3 Vec1, Vect3 Vec2)
        {return Div(Vec1, Vec2);}
        public static Vect3 operator /(Vect3 Vec1, float Scl)
        {return ApplyDivisor(Vec1, Scl); }
    }

    public class Matrix3x3
    {
        public float[,] values;
        public Matrix3x3(Vect3 col1, Vect3 col2, Vect3 col3)
        {
            values = new float[3, 3];

            values[0, 0] = col1.x;
            values[1, 0] = col1.y;
            values[2, 0] = col1.z;

            values[0, 1] = col2.x;
            values[1, 1] = col2.y;
            values[2, 1] = col2.z;

            values[0, 2] = col3.x;
            values[1, 2] = col3.y;
            values[2, 2] = col3.z;
        }

        public static Matrix3x3 Zero = new Matrix3x3(Vect3.Zero, Vect3.Zero, Vect3.Zero);

        public static float GrandSum(Matrix3x3 mat)
        {
            float result = 0f;

            for (int i = 0; i < 3; i++) // for each row
            {
                for (int j = 0; j < 3; j++) // for each column
                {
                    result += mat.values[j, i];
                }
            }

            return result;
        }

        public static Matrix3x3 Mult(Matrix3x3 mat1, Matrix3x3 mat2)
        {
            Matrix3x3 result = Zero;

            for (int i = 0; i < 3; i++) // for each row
            {
                for (int j = 0; j < 3; j++) // for each column
                {
                    result.values[j, i] = mat1.values[j, 0] * mat2.values[0, i] +
                        mat1.values[j, 1] * mat2.values[1, i] +
                        mat1.values[j, 2] * mat2.values[2, i];
                }
            }

            return result;
        }

        public static Vect3 Mult(Matrix3x3 mat, Vect3 vec)
        {
            Vect3 result = Vect3.Zero;

            result.x = mat.values[0, 0] * vec.x +
                       mat.values[0, 1] * vec.y +
                       mat.values[0, 2] * vec.z;

            result.y = mat.values[1, 0] * vec.x +
                       mat.values[1, 1] * vec.y +
                       mat.values[1, 2] * vec.z;

            result.z = mat.values[2, 0] * vec.x +
                       mat.values[2, 1] * vec.y +
                       mat.values[2, 2] * vec.z;

            return result;
        }

        public static Matrix3x3 RollMat(float angle)
        {
            Matrix3x3 result = new(new Vect3(MathF.Cos(angle), MathF.Sin(angle), 0),
                                   new(-MathF.Sin(angle), MathF.Cos(angle), 0),
                                   new(0, 0, 1));

            return result;
        }

        public static Matrix3x3 PitchMat(float angle)
        {
            Matrix3x3 result = new(new Vect3(1, 0, 0),
                                   new(0, MathF.Cos(angle), MathF.Sin(angle)),
                                   new(0, -MathF.Sin(angle), MathF.Cos(angle)));

            return result;
        }

        public static Matrix3x3 YawMat(float angle)
        {
            Matrix3x3 result = new(new Vect3(MathF.Cos(angle), 0, -MathF.Sin(angle)),
                                   new(0, 1, 0),
                                   new(MathF.Sin(angle), 0, MathF.Cos(angle)));

            return result;
        }

        public static Vector3[] RotateVectices(Vector3[] vertices, float angle)
        {
            return null;
        }

    }

    public class Vect4
    {
        // Type definition
        public float x; public float y; public float z; public float w;
        public Vect4(float xVal, float yVal, float zVal, float wVal) // Define Vect4
        { x = xVal; y = yVal; z = zVal; w = wVal; }

        public static Vect4 Zero = new Vect4(0, 0, 0, 0);

        // Functions
        public static Vector4 Vect4ToUnity(Vect4 Vect) // Convert custom Vect3 to Vector3
        { return new Vector4(Vect.x, Vect.y, Vect.z, Vect.w); }
        public static Vect4 UnityToVect4(Vector4 Vect) // Convert Vector3 to custom Vect3
        { return new Vect4(Vect.x, Vect.y, Vect.z, Vect.w); }

        public static Vector4[] ConvertToUnityArray(Vect4[] Vect) // Convert array of custom Vect3 to Vector3 array
        {
            Vector4[] result = new Vector4[Vect.Length];
            for (int i = 0; i < Vect.Length; i++)
            {
                result[i] = new Vector4(Vect[i].x, Vect[i].y, Vect[i].z, Vect[i].w);
            }
            return result;
        }

        public static float Mag(Vect4 Vect) // Vect3 Magnitude
        { return MathF.Sqrt(Vect.x * Vect.x + Vect.y * Vect.y + Vect.z * Vect.z + Vect.w * Vect.w); }

        public static Vect4 Add(Vect4 Vec1, Vect4 Vec2) // Vect3 Addition
        { return new Vect4(Vec1.x + Vec2.x, Vec1.y + Vec2.y, Vec1.z + Vec2.z, Vec1.w + Vec2.w); }

        public static Vect4 Sub(Vect4 Vec1, Vect4 Vec2) // Vect3 Subtraction
        { return new Vect4(Vec1.x - Vec2.x, Vec1.y - Vec2.y, Vec1.z - Vec2.z, Vec1.w - Vec2.w); }

        public static Vect4 Mult(Vect4 Vec1, Vect4 Vec2) // Vect3 Multiplication
        { return new Vect4(Vec1.x * Vec2.x, Vec1.y * Vec2.y, Vec1.z * Vec2.z, Vec1.w * Vec2.w); }

        public static Vect4 Div(Vect4 Vec1, Vect4 Vec2) // Vect3 Division
        { return new Vect4(Vec1.x / Vec2.x, Vec1.y / Vec2.y, Vec1.z / Vec2.z, Vec1.w / Vec2.w); }

        public static Vect4 ApplyScalar(Vect4 Vec1, float Scl) //Application of scalar to Vect3
        { return new Vect4(Vec1.x * Scl, Vec1.y * Scl, Vec1.z * Scl, Vec1.w * Scl); ; }

        public static Vect4 ApplyDivisor(Vect4 Vec1, float Scl) //Application of divisor to Vect3
        { return new Vect4(Vec1.x / Scl, Vec1.y / Scl, Vec1.z / Scl, Vec1.w / Scl); }

        public static Vect4 DuoMidpoint(Vect4 Vec1, Vect4 Vec2)
        { return new Vect4((Vec1.x + Vec2.x) / 2, (Vec1.y + Vec2.y) / 2, (Vec1.z + Vec2.z) / 2, (Vec1.w + Vec2.w) / 2); } // Midpoint of two Vect3's

        public static Vect4 ArrayMidpoint(Vect4[] VecArray) // Midpoint of array of Vect3's
        {
            float xPos = 0; float yPos = 0; float zPos = 0; float wPos = 0;
            for (int i = 0; i < VecArray.Length; i++) { xPos += VecArray[i].x; yPos += VecArray[i].y; zPos += VecArray[i].z; }
            return new Vect4(xPos / VecArray.Length, yPos / VecArray.Length, zPos / VecArray.Length, wPos / VecArray.Length);
        }


        // Setting Operators
        public static Vect4 operator +(Vect4 Vec1, Vect4 Vec2)
        { return Add(Vec1, Vec2); }
        public static Vect4 operator -(Vect4 Vec1, Vect4 Vec2)
        { return Sub(Vec1, Vec2); }
        public static Vect4 operator *(Vect4 Vec1, Vect4 Vec2)
        { return Mult(Vec1, Vec2); }
        public static Vect4 operator *(Vect4 Vec1, float Scl)
        { return ApplyScalar(Vec1, Scl); }
        public static Vect4 operator /(Vect4 Vec1, Vect4 Vec2)
        { return Div(Vec1, Vec2); }
        public static Vect4 operator /(Vect4 Vec1, float Scl)
        { return ApplyDivisor(Vec1, Scl); }
    }

    public class Matrix4x4
    {
        public float[,] values;
        public Matrix4x4(Vect4 col1, Vect4 col2, Vect4 col3, Vect4 col4) 
        {
            values = new float[4, 4];

            values[0, 0] = col1.x;
            values[1, 0] = col1.y;
            values[2, 0] = col1.z;
            values[3, 0] = col1.w;

            values[0, 1] = col2.x;
            values[1, 1] = col2.y;
            values[2, 1] = col2.z;
            values[3, 1] = col2.w;

            values[0, 2] = col3.x;
            values[1, 2] = col3.y;
            values[2, 2] = col3.z;
            values[3, 2] = col3.w;
            
            values[0, 3] = col4.x;
            values[1, 3] = col4.y;
            values[2, 3] = col4.z;
            values[3, 3] = col4.w;
        }

        public Matrix4x4(Vect3 col1, Vect3 col2, Vect3 col3, Vect3 col4)
        {
            values = new float[4, 4];

            values[0, 0] = col1.x;
            values[1, 0] = col1.y;
            values[2, 0] = col1.z;
            values[3, 0] = 0;

            values[0, 1] = col2.x;
            values[1, 1] = col2.y;
            values[2, 1] = col2.z;
            values[3, 1] = 0;

            values[0, 2] = col3.x;
            values[1, 2] = col3.y;
            values[2, 2] = col3.z;
            values[3, 2] = 0;

            values[0, 3] = col4.x;
            values[1, 3] = col4.y;
            values[2, 3] = col4.z;
            values[3, 3] = 1;
        }

        public static Matrix4x4 Zero = new Matrix4x4(Vect4.Zero, Vect4.Zero, Vect4.Zero, Vect4.Zero);
        public static Matrix4x4 RotMat = new Matrix4x4(new Vect3(1,0,0), new(0,1,0), new(0,0,1), Vect3.Zero);

        public static float GrandSum(Matrix4x4 mat)
        {
            float result = 0f;

            for (int i = 0; i < 4; i++) // for each row
            {
                for (int j = 0; j < 4; j++) // for each column
                {
                    result += mat.values[j, i];
                }
            }

            return result;
        }

        public static Matrix4x4 Mult(Matrix4x4 mat1, Matrix4x4 mat2)
        {
            Matrix4x4 result = Matrix4x4.Zero;

            for (int i = 0; i < 4; i++) // for each row
            {
                for (int j = 0; j < 4; j++) // for each column
                {
                    result.values[j, i] = mat1.values[j, 0] * mat2.values[0, i] +
                        mat1.values[j, 1] * mat2.values[1, i] +
                        mat1.values[j, 2] * mat2.values[2, i] +
                        mat1.values[j, 3] * mat2.values[3, i];
                }
            }

            return result;
        }

        public static Vect4 Mult(Matrix4x4 mat, Vect4 vec)
        {
            Vect4 result = Vect4.Zero;

            result.x = mat.values[0, 0] * vec.x +
                       mat.values[0, 1] * vec.y +
                       mat.values[0, 2] * vec.z +
                       mat.values[0, 3] * vec.w;

            result.y = mat.values[1, 0] * vec.x +
                       mat.values[1, 1] * vec.y +
                       mat.values[1, 2] * vec.z +
                       mat.values[1, 3] * vec.w;

            result.z = mat.values[2, 0] * vec.x +
                       mat.values[2, 1] * vec.y +
                       mat.values[2, 2] * vec.z +
                       mat.values[2, 3] * vec.w;

            result.w = mat.values[3, 0] * vec.x +
                       mat.values[3, 1] * vec.y +
                       mat.values[3, 2] * vec.z +
                       mat.values[3, 3] * vec.w;

            return result;
        }

        public static Vect3 Mult(Matrix4x4 mat, Vect3 vec)
        {
            Vect3 result = Vect3.Zero;

            result.x = mat.values[0, 0] * vec.x +
                       mat.values[0, 1] * vec.y +
                       mat.values[0, 2] * vec.z;

            result.y = mat.values[1, 0] * vec.x +
                       mat.values[1, 1] * vec.y +
                       mat.values[1, 2] * vec.z;

            result.z = mat.values[2, 0] * vec.x +
                       mat.values[2, 1] * vec.y +
                       mat.values[2, 2] * vec.z;

            return result;
        }

        public static Matrix4x4 RollMat(float Angle)
        {
            float angle = Angle * (MathF.PI / 180);

            Matrix4x4 result = new(new Vect3(MathF.Cos(angle), MathF.Sin(angle), 0), 
                                   new(-MathF.Sin(angle), MathF.Cos(angle), 0),
                                   new(0, 0, 1),
                                   new(0, 0, 0));

            return result;
        }

        public static Matrix4x4 PitchMat(float Angle)
        {
            float angle = Angle * (MathF.PI / 180);

            Matrix4x4 result = new(new Vect3(1, 0, 0),
                                   new(0, MathF.Cos(angle), MathF.Sin(angle)),
                                   new(0, -MathF.Sin(angle), MathF.Cos(angle)),
                                   new(0, 0, 0));

            return result;
        }

        public static Matrix4x4 YawMat(float Angle)
        {
            float angle = Angle * (MathF.PI / 180);

            Matrix4x4 result = new(new Vect3(MathF.Cos(angle), 0, -MathF.Sin(angle)),
                                   new(0, 1, 0),
                                   new(MathF.Sin(angle), 0, MathF.Cos(angle)),
                                   new(0, 0, 0));

            return result;
        }

        public static Vector3[] RotateVectices(Vector3[] vertices, float angle)
        {
            return null;
        }

    }

    public class Shape3D
    {
        public string shape; public Vect3[] vertices; public int[] tris; public Vect3 midpoint;
        public Shape3D(Vect3 Position, Vect3 Rotation, Vect3 Scale, string Preset, Vect3[] ObjVertices, int[] AssociatedTris)
        {
            // Set the origin position, then make the vertices around it
            switch (Preset)
            {
                case "Cube":
                    Vect3 localPos = new Vect3(Scale.x / 2, Scale.y / 2, Scale.z / 2);

                    vertices = new Vect3[] {
                        new Vect3(0, 0, 0), new Vect3(0, 0, 1), new Vect3(0, 1, 1), new Vect3(0, 1, 0),
                        new Vect3(1, 0, 0), new Vect3(1, 0, 1), new Vect3(1, 1, 1), new Vect3(1, 1, 0),
                        };

                    tris = new int[] {
                        5, 6, 2, 5, 2, 1,
                        4, 5, 1, 4, 1, 0,
                        0, 1, 2, 0, 2, 3,
                        3, 2, 6, 3, 6, 7,
                        7, 6, 5, 7, 5, 4,
                        0, 3, 7, 0, 7, 4
                        };
                    break;
                default:
                    vertices = ObjVertices;
                    tris = AssociatedTris;
                    break;
            }

            SetPosition(Position);
            SetRotation(Rotation);
            SetScale(Scale);
            FindMidpoint();
        }

        public void SetPosition(Vect3 Pos)
        {
            foreach (Vect3 v in vertices)
            {
                v.x += Pos.x; v.y += Pos.y; v.z += Pos.z;
            }
        }

        public void SetRotation(Vect3 Rot)
        {
            foreach (Vect3 v in vertices)
            {
                v.x += Rot.x; v.y += Rot.y; v.z += Rot.z;
            }
        }

        public void SetScale(Vect3 Scl)
        {
            foreach (Vect3 v in vertices)
            {
                v.x *= Scl.x; v.y *= Scl.y; v.z *= Scl.z;
            }
        }

        public Vect3 FindMidpoint()
        {
            Vect3 collectingVect = new Vect3(0, 0, 0);
            foreach (Vect3 v in vertices)
            {
                collectingVect += v;
            }
            return new Vect3(collectingVect.x / vertices.Length, collectingVect.y / vertices.Length, collectingVect.z / vertices.Length);
        }
    }
}