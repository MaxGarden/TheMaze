using System;
using UnityEngine;

public abstract class ISpicesCollisionProvider : MonoBehaviour
{
    public event Action<GameObject> OnCollision;

    protected void OnSpicesCollision(GameObject collider)
    {
        OnCollision?.Invoke(collider);
    }
}