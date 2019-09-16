using System.Linq;
using UnityEngine;

public sealed class TriggerFinishTagCondition : GameplayWinCondition
{
    private bool m_triggered = false;
    private FinishTag[] m_registeredInFinishTags;

    public override string Objective => $"Find exit ({CalculatePlayerDistance()}m)";

    public override bool DetermineIfFulfilled() => m_triggered;

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

    private int CalculatePlayerDistance()
    {
        var player = PlayerContext.MainPlayer;
        if (!player)
            return 0;

        var playerPosition = player.transform.position;
        var playerFlatPosition = new Vector2(playerPosition.x, playerPosition.z);

        return m_registeredInFinishTags
            .Select(tag => tag.transform.position)
            .Select(tagPosition => new Vector2(tagPosition.x, tagPosition.z))
            .Min(tagFlatPosition => (int)Vector2.Distance(playerFlatPosition, tagFlatPosition));
    }
}