using UnityEngine;

public abstract class DynamicObjectTemplate : MonoBehaviour
{
    [SerializeField]
    private string m_name = "Unknown";
    public string Name => m_name;

    [SerializeField]
    private DynamicObjectInstance m_instancePrefab = null;
    public DynamicObjectInstance InstancePrefab => m_instancePrefab;
}