using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(InteractionHandlerProvider))]
public sealed class InteractionController : MonoBehaviour, IInteractionInputHandler
{
    [SerializeField]
    private Inventory m_inventory = null;

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

    void IInteractionInputHandler.Interact()
    {
        if (!m_possibleInteraction)
            return;

        m_possibleInteraction.Interact(CreateInteractionContext());
    }

    private InteractionContext CreateInteractionContext()
    {
        return new InteractionContext()
        {
            PerformerTransform = transform,
            Inventory = m_inventory
        };
    }
}