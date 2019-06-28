using System;
using UnityEngine;

public class InteractiveObject : DynamicObject
{
    public InteractiveObjectTemplate Template { get; private set; }

    private Collider m_interactionCollider;
    public GameObject InteractionRoot => m_interactionCollider.gameObject;

    public override void Initialize(DynamicObjectTemplate template)
    {
        base.Initialize(template);

        Template = (InteractiveObjectTemplate)template;

        var interactionColliderPrefab = Template.InteractionColliderPrefab;
        if (!interactionColliderPrefab)
            throw new InvalidOperationException("Interaction collider prefab cannot be null!");

        m_interactionCollider = Instantiate(Template.InteractionColliderPrefab, transform);
    }
}