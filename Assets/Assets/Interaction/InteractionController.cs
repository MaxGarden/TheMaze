using UnityEngine;

[RequireComponent(typeof(InteractionHandlersProvider))]
public sealed class InteractionController : MonoBehaviour
{
    private InteractionHandlersProvider m_interactionHandlersProvider;

    private void Awake()
    {
        m_interactionHandlersProvider = GetComponent<InteractionHandlersProvider>();
    }

    private void Update()
    {
        m_interactionHandlersProvider.ProvideHandler();
    }
}
