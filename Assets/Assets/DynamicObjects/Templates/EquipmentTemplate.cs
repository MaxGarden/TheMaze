using UnityEngine;

public class EquipmentTemplate : InventoryObjectTemplate
{
    public enum EquipmentType
    {
        Primary,
        Secondary
    }

    [SerializeField]
    private EquipmentType m_type = EquipmentType.Primary;
    public EquipmentType Type => m_type;
}