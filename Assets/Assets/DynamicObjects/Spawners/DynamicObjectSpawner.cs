using UnityEngine;

public sealed class DynamicObjectSpawner : MonoBehaviour
{
    [SerializeField]
    private DynamicObjectTemplate m_template = null;

    private void OnEnable()
    {
        SpawnObject();
    }

    private void SpawnObject()
    {
        var instance = Instantiate(m_template.InstancePrefab, transform);
        instance.Initialize(m_template);
    }
}