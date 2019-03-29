using UnityEngine;

public sealed class ItemTemplate : DynamicObjectTemplate
{
    public enum ItemType
    {
        Primary,
        Secondary
    }

    [SerializeField]
    private ItemType m_type = ItemType.Primary;
    public ItemType Type => m_type;
}