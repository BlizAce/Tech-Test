using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTrigger : MonoBehaviour
{
    public delegate void CollisionCallback(GameObject otherObject);
    public event CollisionCallback OnCollisionCallback;

    private void OnParticleCollision(GameObject other)
    {
        if (OnCollisionCallback != null)
        {
            OnCollisionCallback(other);
        }
    }
}
