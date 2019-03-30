using UnityEngine;

public sealed class CollectibleTemplate : InventoryObjectTemplate
{
    [SerializeField]
    private int m_collectIncrement = 1;
    public int CollectIncrement => m_collectIncrement;
}