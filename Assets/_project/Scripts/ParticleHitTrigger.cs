using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ParticleTrigger;

public class ParticleHitTrigger : MonoBehaviour
{
    [SerializeField]
    ParticleTrigger particleCollisionCallback;

    protected void RegisterCollisionCallback(ParticleTrigger.CollisionCallback  callback )
    {
        if (particleCollisionCallback != null)
        {
            particleCollisionCallback.OnCollisionCallback += callback;
        }
    }
}
