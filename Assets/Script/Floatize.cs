using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floatize : MonoBehaviour {
    public Vector3 size = Vector3.zero;

    Rigidbody ownRb;

    void Start()
    {
        ownRb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Collider[] cols = Physics.OverlapBox(transform.position,size,Quaternion.identity);
        List<Rigidbody> rbs = new List<Rigidbody>();

        foreach (Collider c in cols)
        {
            Rigidbody rb = c.attachedRigidbody;
            if (rb != null && rb != ownRb && !rbs.Contains(rb))
            {
                rbs.Add(rb);
                rb.AddForce(-Physics.gravity * rb.mass);
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position,size*2);
    }
}
