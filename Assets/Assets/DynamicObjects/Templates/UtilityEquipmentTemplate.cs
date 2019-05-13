using UnityEngine;

[CreateAssetMenu(fileName = "UtilityEquipmentTemplate", menuName = "Templates/Utility Equipment Template")]
public class UtilityEquipmentTemplate : EquipmentTemplate
{
    [Header("Utility equipment")]

    [SerializeField]
    private float m_durability = 100.0f;
    public float Durability => m_durability;

    [SerializeField]
    private float m_useCost = 5.0f;
    public float UseCost => m_useCost;
}