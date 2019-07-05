using UnityEngine;

public class Spices : DynamicObject
{
    public SpicesTemplate Template { get; private set; }

    public bool AreShown { get; private set; } = true;

    private ISpicesCollisionProvider m_spicesCollisionProvider;
    private float m_lastCollisionTime = 0.0f;

    public override void Initialize(DynamicObjectTemplate template)
    {
        base.Initialize(template);

        Template = (SpicesTemplate)template;

        m_spicesCollisionProvider = Instantiate(Template.CollisionProviderPrefab, transform);
        m_spicesCollisionProvider.OnCollision += OnSpicesCollision;
    }

    private void OnDestroy()
    {
        if (m_spicesCollisionProvider)
            m_spicesCollisionProvider.OnCollision -= OnSpicesCollision;
    }

    public void Show()
    {
        AreShown = true;
    }

    public void Hide()
    {
        AreShown = false;
    }

    private void OnSpicesCollision(GameObject gameObject)
    {
        if (!AreShown)
            return;

        if (Time.time - m_lastCollisionTime < Template.CollisionCooldownInSeconds)
            return;

        m_lastCollisionTime = Time.time;

        var playerContext = gameObject.GetComponent<PlayerContext>();
        if (playerContext)
            OnSpicesCollisionWithPlayer(playerContext);
    }

    private void OnSpicesCollisionWithPlayer(PlayerContext playerContext)
    {
        playerContext.Health.Damage(Template.CollisionDamage);

        var firstPersonController = playerContext.FirstPersonController;
        var playerMoveDirection = firstPersonController.LastNonZeroMoveDirection;
        firstPersonController.ResetMoveDirection();

        playerContext.KnockbackController.Knockback(new Vector3(-playerMoveDirection.x, -0.5f, -playerMoveDirection.z), Template.KnockbackForce);
    }
}