using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

[RequireComponent(typeof(CharacterController))]
public sealed class KnockbackController : MonoBehaviour
{
    [SerializeField]
    private float m_mass = 3.0f;

    [SerializeField]
    private float m_dampingFactor = 5.0f;

    private Vector3 m_impact = Vector3.zero;
    private CharacterController m_characterController;
    private FirstPersonController m_firstPersonController;

    private void Awake()
    {
        m_characterController = GetComponent<CharacterController>();
    }

    public void Knockback(Vector3 direction, float force)
    {
        m_impact += direction.normalized * force / m_mass;
    }

    private void FixedUpdate()
    {
        if (m_impact.magnitude > 0.2f)
            m_characterController.Move(m_impact * Time.deltaTime);

        m_impact = Vector3.Lerp(m_impact, Vector3.zero, m_dampingFactor * Time.deltaTime);
    }
}