using UnityEngine;

[RequireComponent(typeof(Equipment))]
public sealed class EquipmentPickUpController : PickUpController
{
    private Equipment m_equipment;

    public override string PickUpName => m_equipment.Template.Name;

    private void Awake()
    {
        m_equipment = GetComponent<Equipment>();
    }

    public override void OnPickUp(Inventory inventory)
    {
        inventory.SetEquipment(m_equipment);
    }
}