using UnityEngine;

[CreateAssetMenu(fileName = "CollectibleTemplate", menuName = "Templates/Collectible Template")]
public sealed class CollectibleTemplate : InventoryObjectTemplate
{
    [Header("Collectible")]

    [SerializeField]
    private int m_collectIncrement = 1;
    public int CollectIncrement => m_collectIncrement;
}