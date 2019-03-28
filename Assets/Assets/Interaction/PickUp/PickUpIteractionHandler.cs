using UnityEngine;

[RequireComponent(typeof(PickUpController))]
public class PickUpIteractionHandler : InteractionHandler
{
    private PickUpController m_pickUpController;

    [SerializeField]
    private string m_interactionPrefix = "pick up - ";

    [SerializeField]
    private AudioClip m_pickUpSound = null;

    public override string InteractionDescription => m_interactionPrefix + m_pickUpController.PickUpName;

    protected override void Awake()
    {
        base.Awake();
        m_pickUpController = GetComponent<PickUpController>();
    }

    public override void Interact(InteractionContext context)
    {
        PlayInteractionSound(m_pickUpSound);
        m_pickUpController.OnPickUp(context.Inventory);
    }
}
