using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRObjectRespawn : MonoBehaviour
{
    Vector3 startingPosition;
    Vector3 startingRotation;

    Rigidbody rb;

    void Start()
    {
        startingPosition = transform.position;
        startingRotation = transform.eulerAngles;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        CheckWorldBoundsAndRespawn();
    }

    public void CheckWorldBoundsAndRespawn()
    {
        if (!GameManager.instance.IsInWorldBounds(transform.position))
        {
            transform.position = startingPosition;
            transform.eulerAngles = startingRotation;
            if(rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
    }
}
