public sealed class DeathCondition : GameplayFailCondition
{
    private Health Health => PlayerContext.MainPlayer ? PlayerContext.MainPlayer.Health : null;

    public override bool DetermineIfFulfilled()
    {
        return Health.CurrentHealth <= 0.0f;
    }

    protected override void RegisterEvents()
    {
        base.RegisterEvents();

        Health.OnHealthChanged += RecalculateFulfillment;
    }

    protected override void UnregisterEvents()
    {
        if(Health)
            Health.OnHealthChanged -= RecalculateFulfillment;

        base.UnregisterEvents();
    }
}