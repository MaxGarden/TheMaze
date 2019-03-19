using UnityEngine;

public sealed class InteractionRaycastHandlerProvider : InteractionHandlerProvider
{
    [SerializeField]
    private float m_raycastDistance = 10.0f;

    [SerializeField]
    private Transform m_originTransform = null;

    public override InteractionHandler ProvideHandler()
    {
        Debug.DrawRay(m_originTransform.position, m_originTransform.forward * m_raycastDistance);

        RaycastHit raycastResult;
        if (!Physics.Raycast(m_originTransform.position, m_originTransform.forward, out raycastResult, m_raycastDistance))
            return null;

        return raycastResult.transform.GetComponent<InteractionHandler>();
    }
}