using UnityEngine;

public abstract class EquipmentTemplate : InventoryObjectTemplate
{
    public enum EquipmentType
    {
        Primary,
        Secondary
    }

    [Header("Equipment")]

    [SerializeField]
    private AudioClip m_dropSound = null;
    public AudioClip DropSound => m_dropSound;

    [SerializeField]
    private EquipmentType m_type = EquipmentType.Primary;
    public EquipmentType Type => m_type;

    [SerializeField]
    private EquipmentController m_controllerPrefab = null;
    public EquipmentController ControllerPrefab => m_controllerPrefab;
}