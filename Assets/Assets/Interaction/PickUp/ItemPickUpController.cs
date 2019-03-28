using UnityEngine;

[RequireComponent(typeof(ItemInstance))]
public sealed class ItemPickUpController : PickUpController
{
    private ItemInstance m_item;

    public override string PickUpName => m_item.Template.Name;

    private void Awake()
    {
        m_item = GetComponent<ItemInstance>();
    }

    public override void OnPickUp(Inventory inventory)
    {
        inventory.SetItem(m_item);
        Destroy(m_item.gameObject);
    }
}