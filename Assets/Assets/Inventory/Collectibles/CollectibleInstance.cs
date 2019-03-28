using System;
using UnityEngine;

public sealed class CollectibleInstance : MonoBehaviour
{
    public CollectibleTemplate Template { get; private set; }

    public void Initialize(CollectibleTemplate template)
    {
        if (template)
            throw new InvalidOperationException("[CollectibleInstance.Initialize] Trying to initialized already initialized instance!");

        Template = template;
    }
}