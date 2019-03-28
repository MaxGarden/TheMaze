using UnityEngine;

public abstract class CollectibleTemplate : MonoBehaviour
{
    [SerializeField]
    private string m_name = "Unknown";
    public string Name => m_name;

    [SerializeField]
    private int m_collectIncrement = 1;
    public int CollectIncrement => m_collectIncrement;

    [SerializeField]
    private CollectibleInstance m_instancePrefab = null;
    public CollectibleInstance InstancePrefab => m_instancePrefab;
}