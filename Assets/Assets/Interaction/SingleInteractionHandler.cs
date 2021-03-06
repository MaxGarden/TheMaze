﻿using UnityEngine;

public abstract class SingleInteractionHandler : InteractionHandler
{
    [SerializeField]
    private string m_interactionDescription = null;

    public override string CalculateInteractionDescription(InteractionContext context)
    {
        return m_interactionDescription;
    }
}