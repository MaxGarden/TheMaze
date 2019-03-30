using UnityEngine;

[RequireComponent(typeof(Collectible))]
public sealed class CollectiblePickUpController : PickUpController
{
    private Collectible m_collectible;

    public override string PickUpName => m_collectible.Template.Name;

    private void Awake()
    {
        m_collectible = GetComponent<Collectible>();
    }

    public override void OnPickUp(Inventory inventory)
    {
        inventory.AddCollectible(m_collectible);
        Destroy(m_collectible.gameObject);
    }
}