﻿using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(InteractionHandlerProvider))]
public sealed class InteractionController : MonoBehaviour
{
    const string s_interactButtonName = "Interact";

    private InteractionHandlerProvider m_interactionHandlersProvider;
    private InteractionHandler m_possibleInteraction;

    public bool IsInteractionPossible => m_possibleInteraction;
    public string InteractionDescription => m_possibleInteraction ? m_possibleInteraction.InteractionDescription : string.Empty;

    private void Awake()
    {
        m_interactionHandlersProvider = GetComponent<InteractionHandlerProvider>();
    }

    private void FixedUpdate()
    {
        m_possibleInteraction = m_interactionHandlersProvider.ProvideHandler();
    }

    private void Update()
    {
        HandleInteraction();
    }

    private void HandleInteraction()
    {
        if (!CrossPlatformInputManager.GetButtonDown(s_interactButtonName))
            return;

        if (!m_possibleInteraction)
            return;

        m_possibleInteraction.Interact(CreateInteractionContext());
    }

    private InteractionContext CreateInteractionContext()
    {
        return new InteractionContext()
        {
            PerformerTransform = transform
        };
    }
}