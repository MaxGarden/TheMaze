using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public sealed class PushInteractionHandler : SingleInteractionHandler
{
    [SerializeField]
    private float m_pushForce = 10.0f;

    [SerializeField]
    private AudioClip m_pushSound = null;

    private Rigidbody m_rigidBody;

    protected override void Awake()
    {
        base.Awake();

        m_rigidBody = GetComponent<Rigidbody>();
    }

    public override void Interact(InteractionContext context)
    {
        PlayInteractionSound(m_pushSound);

        m_rigidBody.AddForce(context.PerformerTransform.forward * m_pushForce);
    }
}