using UnityEngine;

[RequireComponent(typeof(CollectibleInstance))]
public sealed class CollectiblePickUpController : PickUpController
{
    private CollectibleInstance m_collectible;

    public override string PickUpName => m_collectible.Template.Name;

    private void Awake()
    {
        m_collectible = GetComponent<CollectibleInstance>();
    }

    public override void OnPickUp(Inventory inventory)
    {
        inventory.AddCollectible(m_collectible);
        Destroy(m_collectible.gameObject);
    }
}