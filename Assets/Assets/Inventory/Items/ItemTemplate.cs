using UnityEngine;

public abstract class ItemTemplate : MonoBehaviour
{
    public enum ItemType
    {
        Primary,
        Secondary
    }

    [SerializeField]
    private ItemType m_type = ItemType.Primary;
    public ItemType Type => m_type;

    [SerializeField]
    private string m_name = "Unknown";
    public string Name => m_name;

    [SerializeField]
    private ItemInstance m_instancePrefab = null;
    public ItemInstance InstancePrefab => m_instancePrefab;
}