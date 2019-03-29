using UnityEngine;

public sealed class CollectibleTemplate : DynamicObjectTemplate
{
    [SerializeField]
    private int m_collectIncrement = 1;
    public int CollectIncrement => m_collectIncrement;
}