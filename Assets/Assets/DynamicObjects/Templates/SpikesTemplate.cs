using UnityEngine;

[CreateAssetMenu(fileName = "SpikesTemplate", menuName = "Templates/Spikes Template")]
public sealed class SpikesTemplate : DynamicObjectTemplate
{
    [Header("Spikes")]

    [SerializeField]
    private ISpikesCollisionProvider m_collisionProviderPrefab = null;
    public ISpikesCollisionProvider CollisionProviderPrefab => m_collisionProviderPrefab;

    [SerializeField]
    private float m_collisionDamage = 30.0f;
    public float CollisionDamage => m_collisionDamage;

    [SerializeField]
    private float m_knockbackForce = 35.0f;
    public float KnockbackForce => m_knockbackForce;

    [SerializeField]
    private float m_collisionCooldownInSeconds = 0.5f;
    public float CollisionCooldownInSeconds => m_collisionCooldownInSeconds;

    [SerializeField]
    private float m_timeWhenShownInSeconds = 2.0f;
    public float TimeWhenShownInSeconds => m_timeWhenShownInSeconds;

    [SerializeField]
    private float m_timeWhenHiddenInSeconds = 2.0f;
    public float TimeWhenHiddenInSeconds => m_timeWhenHiddenInSeconds;

    [SerializeField]
    private AudioClip m_showSound = null;
    public AudioClip ShowSound => m_showSound;

    [SerializeField]
    private AudioClip m_hideSound = null;
    public AudioClip HideSound => m_hideSound;
}