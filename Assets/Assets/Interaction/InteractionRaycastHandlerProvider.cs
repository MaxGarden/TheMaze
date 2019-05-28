using UnityEngine;

public sealed class InteractionRaycastHandlerProvider : InteractionHandlerProvider
{
    [SerializeField]
    private float m_raycastDistance = 10.0f;

    [SerializeField]
    private int m_layerMask = 0;

    [SerializeField]
    private Transform m_originTransform = null;

    public override InteractionHandler ProvideHandler()
    {
        Debug.DrawRay(m_originTransform.position, m_originTransform.forward * m_raycastDistance);

        RaycastHit raycastResult;
        if (!Physics.Raycast(m_originTransform.position, m_originTransform.forward, out raycastResult, m_raycastDistance, m_layerMask))
            return null;

        return raycastResult.transform.GetComponentInParent<InteractionHandler>();
    }
}