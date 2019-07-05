using UnityEngine;

[RequireComponent(typeof(DoorController))]
public sealed class DoorInteractionHandler : InteractionHandler
{
    [SerializeField]
    private string m_openDescription = "open";

    [SerializeField]
    private string m_closeDescription = "close";

    [SerializeField]
    private string m_unlockDescription = "Locked - requires {0} to open";

    public override bool IsCustomInteraction(InteractionContext context)
    {
        return m_doorController.IsLocked && !m_doorController.HasRequiredCollectibleToOpen(context.Inventory);
    }

    private DoorController m_doorController;

    public override string CalculateInteractionDescription(InteractionContext context)
    {
        if (!m_doorController.IsLocked || m_doorController.HasRequiredCollectibleToOpen(context.Inventory))
        {
            if (m_doorController.IsOpened)
                return m_closeDescription;
            else
                return m_openDescription;
        }
        else
            return string.Format(m_unlockDescription, m_doorController.RequiredCollectibleToOpen.Name);
    }

    public override void Interact(InteractionContext context)
    {
        m_doorController.Push(context.Inventory);
    }

    protected override void Awake()
    {
        base.Awake();

        m_doorController = GetComponent<DoorController>();
    }
}