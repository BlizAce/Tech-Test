using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeaPot : MonoBehaviour
{
    // Store a particle system
    [SerializeField]
    ParticleSystem teaStream;

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

    public AnimationCurve flowCurve;

    private void Start()
    {
        gameObject.AddComponent<XRObjectRespawn>();
    }

    private void Update()
    {
        if (isGrabbed)
        {
            AdjustFlowRate();
        }
        else
        {
            SetTeaStreamRate(0);
        }
    }

    public void AdjustFlowRate()
    {
        SetTeaStreamRate(1 - transform.up.y);
    }
    public void SetTeaStreamRate(float y)
    {
        var emission = teaStream.emission;
        emission.rateOverTime = flowCurve.Evaluate(y);
    }
}
