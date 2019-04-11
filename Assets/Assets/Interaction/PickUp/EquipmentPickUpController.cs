using UnityEngine;

[RequireComponent(typeof(Equipment))]
public sealed class EquipmentPickUpController : PickUpController
{
    private Equipment m_equipment;

    public override string PickUpName => m_equipment.Template.Name;
    public override AudioClip PickUpSound => m_equipment.Template.PickUpSound;

    private void Awake()
    {
        m_equipment = GetComponent<Equipment>();
    }

    public override void OnPickUp(Inventory inventory)
    {
        inventory.SetEquipment(m_equipment);
        m_equipment.State = Equipment.EquipmentState.Stored;
    }
}