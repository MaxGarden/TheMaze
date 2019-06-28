using System;
using UnityEngine;

public abstract class DynamicObject : MonoBehaviour
{
    public bool IsInitialized { get; private set; } = false;

    public virtual void Initialize(DynamicObjectTemplate template)
    {
        if (IsInitialized)
            throw new InvalidOperationException("Object has been already initialized!");

        IsInitialized = true;
    }
}