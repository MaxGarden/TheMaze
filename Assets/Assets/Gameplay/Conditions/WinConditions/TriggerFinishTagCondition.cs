public sealed class TriggerFinishTagCondition : GameplayWinCondition
{
    private bool m_triggered = false;
    private FinishTag[] m_registeredInFinishTags;

    public override bool DetermineIfFulfilled()
    {
        return m_triggered;
    }

    protected override void RegisterEvents()
    {
        base.RegisterEvents();

        m_registeredInFinishTags = FindObjectsOfType<FinishTag>();

        foreach (var finishTag in m_registeredInFinishTags)
            finishTag.OnTriggered += OnTriggered;
    }

    protected override void UnregisterEvents()
    {
        foreach (var finishTag in m_registeredInFinishTags)
            finishTag.OnTriggered -= OnTriggered;

        base.UnregisterEvents();
    }

    private void OnTriggered()
    {
        m_triggered = true;
        RecalculateFulfillment();
    }
}