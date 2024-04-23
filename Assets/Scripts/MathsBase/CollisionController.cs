using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    public List<GameObject> pObjectList = new List<GameObject>();
    public float radius;

    public bool hit;
    public Vector3 momentum;
    public Vector3 velocity;
    public float mass;

    void Start()
    {
        radius = transform.localScale.x / 2f;

        hit = false;
        momentum = Vector3.zero;
        velocity = Vector3.zero;
        mass = 1f;
    }

    void FixedUpdate()
    {
        pObjectList.AddRange(GameObject.FindGameObjectsWithTag("PhysicsObject"));

        foreach (GameObject obj in pObjectList) {
            if (obj != this.gameObject) {

                if (Intersection(obj) && !hit)
                {
                    CollisionController objCollision = obj.GetComponent<CollisionController>();

                    momentum = mass * velocity;
                    Vector3 objMomentum = objCollision.mass * objCollision.velocity;

                    Vector3 resultantMomentum = momentum + objMomentum;

                    velocity = resultantMomentum / mass;
                    objCollision.velocity = resultantMomentum / objCollision.mass;

                    if (velocity.magnitude > objCollision.velocity.magnitude && mass < objCollision.mass)
                    {
                        velocity *= -1;
                    }

                    else if (velocity.magnitude < objCollision.velocity.magnitude && mass > objCollision.mass)
                    {
                        objCollision.velocity *= -1;
                    }

                    Debug.Log(transform.name + ": " + velocity);
                    Debug.Log(obj.transform.name + ": " + objCollision.velocity);
                }

                if (Intersection(obj))
                {
                    hit = true;
                }

                else if (!Intersection(obj))
                {
                    hit = false;
                }
            }
        }

        pObjectList.Clear();

        transform.position += velocity * Time.deltaTime;

        velocity.x = velocity.x <= 0.05f && velocity.x >= -0.05f ? 0f : velocity.x;
        if (velocity.x != 0f)
        {
            velocity.x = velocity.x > 0f ? velocity.x -= 0.05f : velocity.x += 0.05f;
        }

        velocity.y = velocity.y <= 0.05f && velocity.y >= -0.05f ? 0f : velocity.y;
        if (velocity.y != 0f)
        {
            velocity.y = velocity.y > 0f ? velocity.y -= 0.05f : velocity.y += 0.05f;
        }

        velocity.z = velocity.z <= 0.05f && velocity.z >= -0.05f ? 0f : velocity.z;
        if (velocity.z != 0f)
        {
            velocity.z = velocity.z > 0f ? velocity.z -= 0.05f : velocity.z += 0.05f;
        }
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
