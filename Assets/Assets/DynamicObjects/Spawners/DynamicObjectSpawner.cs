using UnityEngine;

public sealed class DynamicObjectSpawner : MonoBehaviour
{
    [SerializeField]
    private DynamicObjectTemplate m_template = null;

    [SerializeField]
    private DynamicObject m_objectPrefab = null;

    private void Start()
    {
        SpawnObject();
    }

    private void SpawnObject()
    {
        var instance = Instantiate(m_objectPrefab, transform);
        instance.Initialize(m_template);
    }
}