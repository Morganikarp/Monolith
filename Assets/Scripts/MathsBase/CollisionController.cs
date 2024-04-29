using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    public List<GameObject> pObjectList = new List<GameObject>();
    public float radius;

    public bool Live;

    public bool Impulse;
    public Vector3 ImpulseForce;
    public Vector3 Acceleration;
    public Vector3 Velocity;
    public Vector3 Momentum;
    public float Mass;
    public float Density;

    public float timeOverlapsed;

    public bool EnableGravity;

    public bool OriginalCollision;

    void Start()
    {
        radius = transform.localScale.x / 2f;

        Live = false;

        Impulse = false;
        ImpulseForce = Vector3.zero;
        Acceleration = Vector3.zero;
        Velocity = Vector3.zero;
        Momentum = Vector3.zero;
        Mass = 10f;

        timeOverlapsed = 0;

        OriginalCollision = true;
    }
    void Update()
    {
            //Force = new Vector3(0f, -9.81f * Mass, 0f);

            //if (Impulse)
            //{
            //    Impulse = false;

            //}

            //Acceleration = Force / Mass;

            //Velocity = Acceleration * timeOverlapsed;

            //transform.position += Velocity * Time.deltaTime;

            //Momentum = Mass * Velocity;

        timeOverlapsed += Time.deltaTime;

            //Vector3 GravForce = new Vector3(0f, -9.81f * Mass, 0f);
            //Vector3 GravAcc = GravForce / Mass;
            //Vector3 GravVelo = GravAcc / Time.deltaTime;

        if (Impulse)
        {
            Impulse = false;
    
            Vector3 ImpAcc = ImpulseForce / Mass;
            Velocity += ImpAcc / Time.deltaTime;
        }


        if (EnableGravity)
        {
            // Gravity
            Acceleration = new Vector3(0f, -9.81f, 0f);
        
            // terminal velocity equation:
            // V = sqrRt( 2 * Weight / Drag Co * density * frontal area )

            float terminalVelocity = MathF.Sqrt( 2 * ( Mass * -9.81f ) / 0.47f * Density * (MathF.PI * radius * radius));
            if (terminalVelocity <= Velocity.y)
            {

            }

            // Air Res
            //Vector3 AirAcc = new Vector3(0.5f * 1.2f * (Mathf.PI * radius * radius) * 0.47f * (Velocity.x * Velocity.x), -0.5f * 1.2f * (Mathf.PI * radius * radius) * 0.47f * (Velocity.y * Velocity.y), 0.5f * 1.2f * (Mathf.PI * radius * radius) * 0.47f * (Velocity.z * Velocity.z)) / Mass;
            //Velocity += AirAcc / Time.deltaTime;

        }

        Velocity += Acceleration * Time.deltaTime;

        transform.position += Velocity * Time.deltaTime;

        pObjectList.AddRange(GameObject.FindGameObjectsWithTag("PhysicsObject"));

        foreach (GameObject obj in pObjectList)
        {
            if (obj != this.gameObject)
            {
                if (Intersection(obj))
                {
                    if (OriginalCollision)
                    {
                        Vector3 collisionNormal = Vector3.Normalize(obj.transform.position - transform.position);

                        CollisionController objCollision = obj.GetComponent<CollisionController>();;

                        Momentum = Mass * Velocity;
                        objCollision.Momentum = objCollision.Mass * objCollision.Velocity;

                        Vector3 resultantMomentum = Momentum + objCollision.Momentum;

                        // this intial velocity + this final velocity = obj initial velocity + obj final velocity
                        Vector3 tempV = Velocity - objCollision.Velocity;


                        Vector3 thisFinalV = (resultantMomentum - tempV) / (2 * Mass);
                        Vector3 objFinalV = Velocity + thisFinalV - objCollision.Velocity;

                        Velocity = thisFinalV;
                        objCollision.Velocity = objFinalV.magnitude * collisionNormal;


                        //Vector3 a = (resultantMomentum / Mass) / Time.deltaTime;
                        ////Vector3 f = a / Time.deltaTime;
                        //ImpulseForce = a * Mass;
                        //Impulse = true;

                        //Velocity = resultantMomentum / Mass;

                        // momentum = mass * velocity
                        // momentum / mass = velocity

                        // accerlation = velocity / time

                        //Debug.Log(transform.name);
                        //Debug.Log("Velocity: " + Velocity);
                        //Debug.Log("Momentum: " + Momentum);
                        //Debug.Log("Res Momentum: " + resultantMomentum);
                        //Debug.Log("Acceleration: " + a);
                        //Debug.Log("Force: " + ImpulseForce);
                        //Debug.Break();

                        ////Debug.Log("Resultant mo: " + a);

                        //a = (resultantMomentum / objCollision.Mass) / Time.deltaTime;
                        ////f = a / Time.deltaTime;
                        //objCollision.ImpulseForce = a * objCollision.Mass;
                        //objCollision.Impulse = true;

                        //objCollision.Velocity = resultantMomentum / objCollision.Mass;



                        //Velocity = resultantMomentum / mass;
                        //objCollision.Velocity = resultantMomentum / objCollision.mass;

                        //if (Velocity > objCollision.Velocity && mass < objCollision.mass)
                        //{
                        //    Velocity *= -1;
                        //}

                        //else if (Velocity < objCollision.Velocity && mass > objCollision.mass)
                        //{
                        //    objCollision.Velocity *= -1;
                        //}

                        OriginalCollision = false;
                        objCollision.OriginalCollision = false;

                        //Debug.Break();
                        //Debug.Log("Resultant mo: " + resultantMomentum);
                        //Debug.Log(transform.name + ": " + Velocity);
                        //Debug.Log(obj.transform.name + ": " + objCollision.Velocity);
                    }

                    else if (!OriginalCollision)
                    {
                        OriginalCollision = true;
                        CollisionController objCollision = obj.GetComponent<CollisionController>();
                        objCollision.OriginalCollision = true;
                    }
                }
            }
        }

        pObjectList.Clear();


    }
    void FixedUpdate()
    {

        //if (Velocity.magnitude != 0)
        //{
        //    //Debug.Break();
        //}

        //if (EnableGravity)
        //{
        //    Force += new Vector3(0f, -9.81f * Mass, 0f);
        //}

        //float AirResX = -0.5f * 1.2f * (Mathf.PI * radius * radius) * 0.47f * (Velocity.x * Velocity.x);
        //float AirResY = -0.5f * 1.2f * (Mathf.PI * radius * radius) * 0.47f * (Velocity.y * Velocity.y);
        //float AirResZ = -0.5f * 1.2f * (Mathf.PI * radius * radius) * 0.47f * (Velocity.z * Velocity.z);

        //Vector3 AirRes = new Vector3(-0.5f * 1.2f * (Mathf.PI * radius * radius) * 0.47f * (Velocity.x * Velocity.x, -0.5f * 1.2f * (Mathf.PI * radius * radius) * 0.47f * (Velocity.y * Velocity.y, -0.5f * 1.2f * (Mathf.PI * radius * radius) * 0.47f * (Velocity.z * Velocity.z));

        //if (Velocity.x != 0)
        //{
        //    Acceleration.x += AirRes.x / Mass;
        //}

        //if (Velocity.y != 0)
        //{
        //    Acceleration.y = AirRes.y / Mass;
        //}

        //if (Velocity.z != 0)
        //{
        //    Acceleration.z = AirRes.z / Mass;
        //}

        //Force += new Vector3(-0.5f * 1.2f * (Mathf.PI * radius * radius) * 0.47f * (Velocity.x * Velocity.x), -0.5f * 1.2f * (Mathf.PI * radius * radius) * 0.47f * (Velocity.y * Velocity.y), -0.5f * 1.2f * (Mathf.PI * radius * radius) * 0.47f * (Velocity.z * Velocity.z));

        //Velocity.x = Velocity.x <= 0.5f && Velocity.x >= -0.5f ? 0f : Velocity.x;
        //if (Velocity.x != 0f)
        //{
        //    Force.x = Velocity.x > 0f ? Force.x += -0.5f * 1.2f * (Mathf.PI * radius * radius) * 0.47f * (Velocity.x * Velocity.x) : Force.x -= -0.5f * 1.2f * (Mathf.PI * radius * radius) * 0.47f * (Velocity.x * Velocity.x);
        //}

        ////Velocity.y = Velocity.y <= 0.5f && Velocity.y >= -0.5f ? 0f : Velocity.y;
        //if (Velocity.y != 0f)
        //{
        //    Force.y = Velocity.y > 0f ? Force.y += -0.5f * 1.2f * (Mathf.PI * radius * radius) * 0.47f * (Velocity.y * Velocity.y) : Force.y -= -0.5f * 1.2f * (Mathf.PI * radius * radius) * 0.47f * (Velocity.y * Velocity.y);
        //}

        ////Velocity.z = Velocity.z <= 0.5f && Velocity.z >= -0.5f ? 0f : Velocity.z;
        //if (Velocity.z != 0f)
        //{
        //    Force.z = Velocity.z > 0f ? Force.z += -0.5f * 1.2f * (Mathf.PI * radius * radius) * 0.47f * (Velocity.z * Velocity.z) : Force.z -= -0.5f * 1.2f * (Mathf.PI * radius * radius) * 0.47f * (Velocity.z * Velocity.z);
        //}

        //if (Force.x != 0f) {
        //    //Force.x = Velocity.x > 0f ? Force.x += -0.5f * 1.2f * (Mathf.PI * radius * radius) * 0.47f * (Velocity.x * Velocity.x) : Force.x -= -0.5f * 1.2f * (Mathf.PI * radius * radius) * 0.47f * (Velocity.x * Velocity.x);
        //}

        //if (Force.y > 0f) {
        //    //Force.y = Velocity.y > 0f ? Force.y += -0.5f * 1.2f * (Mathf.PI * radius * radius) * 0.47f * (Velocity.y * Velocity.y) : Force.y -= -0.5f * 1.2f * (Mathf.PI * radius * radius) * 0.47f * (Velocity.y * Velocity.y);
        //    Force.y += -0.5f * 1.2f * (Mathf.PI * radius * radius) * 0.47f * (Velocity.y * Velocity.y);
        //    Debug.Log(-0.5f * 1.2f * (Mathf.PI * radius * radius) * 0.47f * (Velocity.y * Velocity.y));
        //    //Debug.Break();
        //}

        //if (Force.y < 0f)
        //{
        //    //Force.y = Velocity.y > 0f ? Force.y += -0.5f * 1.2f * (Mathf.PI * radius * radius) * 0.47f * (Velocity.y * Velocity.y) : Force.y -= -0.5f * 1.2f * (Mathf.PI * radius * radius) * 0.47f * (Velocity.y * Velocity.y);
        //    Force.y -= -0.5f * 1.2f * (Mathf.PI * radius * radius) * 0.47f * (Velocity.y * Velocity.y);
        //}

        //if (Force.z != 0f) {
        //    //Force.z = Velocity.z > 0f ? Force.z += -0.5f * 1.2f * (Mathf.PI * radius * radius) * 0.47f * (Velocity.z * Velocity.z) : Force.z -= -0.5f * 1.2f * (Mathf.PI * radius * radius) * 0.47f * (Velocity.z * Velocity.z);
        //}

        //Debug.Log("Time passed: " + Time.deltaTime + "    Force: " + Force + "    Acc: " + Acceleration + "    Vel: " + Velocity);

        //Force.x = Force.x <= 0.05f && Force.x >= -0.05f ? 0f : Force.x;
        //if (Force.x != 0f)
        //{
        //    Force.x = Force.x > 0f ? Force.x -= 0.05f : Force.x += 0.05f;
        //}

        //Force.y = Force.y <= 0.05f && Force.y >= -0.05f ? 0f : Force.y;
        //if (Force.y != 0f)
        //{
        //    Force.y = Force.y > 0f ? Force.y -= 0.05f : Force.y += 0.05f;
        //}

        //Force.z = Force.z <= 0.05f && Force.z >= -0.05f ? 0f : Force.z;
        //if (Force.z != 0f)
        //{
        //    Force.z = Force.z > 0f ? Force.z -= 0.05f : Force.z += 0.05f;
        //}


    }

    bool Intersection(GameObject obj)
    {
        Vector3 distVect = obj.transform.position - transform.position;
        float distMagVect = distVect.magnitude;

        CollisionController objColCon = obj.GetComponent<CollisionController>();
        float objRad = objColCon.radius;

        float CombRadSq = radius + objRad;
        CombRadSq *= CombRadSq;

        return distMagVect <= CombRadSq;
    }
}
