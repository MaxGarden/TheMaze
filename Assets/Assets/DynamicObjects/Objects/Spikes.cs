using UnityEngine;

public class Spikes : DynamicObject
{
    public SpikesTemplate Template { get; private set; }

    public bool AreShown { get; private set; } = true;

    private ISpikesCollisionProvider m_spikesCollisionProvider;
    private float m_lastCollisionTime = 0.0f;

    public override void Initialize(DynamicObjectTemplate template)
    {
        base.Initialize(template);

        Template = (SpikesTemplate)template;

        m_spikesCollisionProvider = Instantiate(Template.CollisionProviderPrefab, transform);
        m_spikesCollisionProvider.OnCollision += OnSpikesCollision;
    }

    private void OnDestroy()
    {
        if (m_spikesCollisionProvider)
            m_spikesCollisionProvider.OnCollision -= OnSpikesCollision;
    }

    public void Show()
    {
        AreShown = true;
    }

    public void Hide()
    {
        AreShown = false;
    }

    private void OnSpikesCollision(GameObject gameObject)
    {
        if (!AreShown)
            return;

        if (Time.time - m_lastCollisionTime < Template.CollisionCooldownInSeconds)
            return;

        m_lastCollisionTime = Time.time;

        var playerContext = gameObject.GetComponent<PlayerContext>();
        if (playerContext)
            OnSpikesCollisionWithPlayer(playerContext);
    }

    private void OnSpikesCollisionWithPlayer(PlayerContext playerContext)
    {
        playerContext.Health.Damage(Template.CollisionDamage);

        var firstPersonController = playerContext.FirstPersonController;
        var playerMoveDirection = firstPersonController.LastNonZeroMoveDirection;
        firstPersonController.ResetMoveDirection();

        playerContext.KnockbackController.Knockback(new Vector3(-playerMoveDirection.x, -0.5f, -playerMoveDirection.z), Template.KnockbackForce);
    }
}