using UnityEngine;

[CreateAssetMenu(fileName = "InteractiveObjectTemplate", menuName = "Templates/Interactive Object Template")]
public class InteractiveObjectTemplate : DynamicObjectTemplate
{
    [SerializeField]
    private string m_name = "Unknown";
    public string Name => m_name;

    [SerializeField]
    private Collider m_interactionColliderPrefab = null;
    public Collider InteractionColliderPrefab => m_interactionColliderPrefab;
}