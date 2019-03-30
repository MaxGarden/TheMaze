using UnityEngine;

public class InteractiveObject : DynamicObject
{
    public InteractiveObjectTemplate Template { get; private set; }

    private Collider m_interactionCollider;
    public GameObject InteractionRoot => m_interactionCollider.gameObject;

    public override void Initialize(DynamicObjectTemplate template)
    {
        Template = (InteractiveObjectTemplate)template;
        m_interactionCollider = Instantiate(Template.InteractionColliderPrefab, transform);
    }
}