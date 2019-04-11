using UnityEngine;

[RequireComponent(typeof(PickUpController))]
public class PickUpInteractionHandler : InteractionHandler
{
    private PickUpController m_pickUpController;

    [SerializeField]
    private string m_interactionPrefix = "pick up - ";

    public override string InteractionDescription => m_interactionPrefix + m_pickUpController.PickUpName;

    protected override void Awake()
    {
        base.Awake();
        m_pickUpController = GetComponent<PickUpController>();
    }

    public override void Interact(InteractionContext context)
    {
        m_pickUpController.OnPickUp(context.Inventory);
        PlayInteractionSound(m_pickUpController.PickUpSound);
    }
}