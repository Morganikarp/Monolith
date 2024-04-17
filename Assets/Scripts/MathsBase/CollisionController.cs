using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{

    public List<GameObject> pObjectList = new List<GameObject>();
    public float radius;

    // Start is called before the first frame update
    void Start()
    {
        radius = transform.localScale.x / 2f;
    }

    // Update is called once per frame
    void Update()
    {
        pObjectList.AddRange(GameObject.FindGameObjectsWithTag("PhysicsObject"));

        foreach (GameObject obj in pObjectList)
        {
            //if (Intersection(obj))
            //{

            //}
            if (obj != this.gameObject)
            {
                Debug.Log(transform.name + ": " + Intersection(obj));
            }
        }

        pObjectList.Clear();
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
