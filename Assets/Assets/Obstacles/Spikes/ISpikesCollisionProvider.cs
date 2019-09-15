using System;
using UnityEngine;

public abstract class ISpikesCollisionProvider : MonoBehaviour
{
    public event Action<GameObject> OnCollision;

    protected void OnSpikesCollision(GameObject collider)
    {
        OnCollision?.Invoke(collider);
    }
}