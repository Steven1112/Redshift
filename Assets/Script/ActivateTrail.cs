using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTrail : MonoBehaviour {
    public float range = 35.0f;

    Rigidbody ownRb;

    void Start()
    {
        ownRb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, range);
        List<Rigidbody> rbs = new List<Rigidbody>();

        foreach (Collider c in cols)
        {
            Rigidbody rb = c.attachedRigidbody;
            if (rb != null && rb != ownRb && !rbs.Contains(rb))
            {
                rbs.Add(rb);
                // activate asteroid trail
                rb.gameObject.GetComponent<Trail>().trail.SetActive(true);

            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
