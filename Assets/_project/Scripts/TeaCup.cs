using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeaCup : ParticleHitTrigger
{
    [Header("Tea cup water animation settings")]
    public float currentFillAmount = 0.0f;

    public float topPosition = 0.0571f;
    public float bottomPosition = 0.0052f;

    public AnimationCurve scaleCurve;
    public GameObject fillPlane;

    public Transform plate;
    public bool snappedToPlate = true;
    public float ySnapOffset = 0.002978086f;
    Rigidbody rb;

    /// <summary>
    /// This should be in a base class with supporting methods
    /// </summary>
    protected bool isGrabbed = false;

    public bool IsGrabbed
    {
        get
        {
            return isGrabbed;
        }
        set
        {
            isGrabbed = value;
        }
    }

    private void Start()
    {
        gameObject.AddComponent<XRObjectRespawn>();
        rb = GetComponent<Rigidbody>();

        RegisterCollisionCallback(OnCollisionDetected);
        AnimateFillPlane();
    }

    private void Update()
    {
        if(snappedToPlate)
        {
            snapToPlate();
        }
    }

    public void snapToPlate()
    {
        transform.position = new Vector3(plate.position.x, plate.position.y, plate.position.z);
        transform.rotation = plate.rotation;
        transform.position += transform.up * ySnapOffset;
        
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    public void OnCollisionDetected(GameObject otherObject)
    {
        if (otherObject.name == "TeaCup")
        {
            currentFillAmount += 0.1f;
            if(currentFillAmount > 1.0f)
            {
                currentFillAmount = 1.0f;
                // end of tutorial event?
            }
            AnimateFillPlane();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Plate" && IsGrabbed)
        {
            snappedToPlate = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Plate" && IsGrabbed)
        {
            snappedToPlate = false;
        }
    }

    protected void AnimateFillPlane()
    {
        float newScale = scaleCurve.Evaluate(currentFillAmount);
        float newPosition = Mathf.Lerp(bottomPosition, topPosition, currentFillAmount);
        fillPlane.transform.localScale = new Vector3(newScale, newScale, newScale);
        fillPlane.transform.localPosition = new Vector3(0, newPosition, 0);
    }
}
