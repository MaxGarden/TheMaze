using System;
using UnityEngine;

public sealed class ItemInstance : MonoBehaviour
{
    public ItemTemplate Template { get; private set; }

    public void Initialize(ItemTemplate template)
    {
        if (template)
            throw new InvalidOperationException("[ItemInstance.Initialize] Trying to initialized already initialized instance!");

        Template = template;
    }
}