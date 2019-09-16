using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public sealed class CollectCollectiblesCondition : GameplayWinCondition
{
    public override int Priority => base.Priority + 1;

    [SerializeField]
    private CollectibleTemplate m_collectibleTemplate = null;
    public CollectibleTemplate CollectibleTemplate
    {
        get { return m_collectibleTemplate; }
        set
        {
            m_collectibleTemplate = value;
            GatherCollectibles();
        }
    }

    [SerializeField]
    private int m_requiredCollectiblesCount;
    public int RequiredCollectiblesCount
    {
        get { return Mathf.Min(m_requiredCollectiblesCount, m_collectibles.Count()); }
        set { m_requiredCollectiblesCount = value; }
    }

    public override string Objective => $"Find {CollectedCollectiblesCount}/{RequiredCollectiblesCount} instances of {CollectibleName} ({CalculatePlayerDistance()}m)";

    private readonly List<Collectible> m_collectibles = new List<Collectible>();

    private string CollectibleName
    {
        get
        {
            if (!CollectibleTemplate)
                return "null";

            return CollectibleTemplate.Name;
        }
    }

    private int CollectedCollectiblesCount
    {
        get
        {
            if (!CollectibleTemplate)
                return 0;

            var inventory = Inventory;
            if (!inventory)
                return 0;

            int collectiblesCount;
            if (!inventory.Collectibles.TryGetValue(CollectibleTemplate, out collectiblesCount))
                return 0;

            return collectiblesCount;
        }
    }

    private Inventory Inventory
    {
        get
        {
            var mainPlayer = PlayerContext.MainPlayer;
            if (!mainPlayer)
                return null;

            return mainPlayer.Inventory;
        }
    }

    protected override void RegisterEvents()
    {
        base.RegisterEvents();

        var inventory = Inventory;
        if(inventory)
            inventory.OnCollectiblesChanged += RecalculateFulfillment;

        StartCoroutine(GatherCollectiblesCoroutine());
    }

    protected override void UnregisterEvents()
    {
        var inventory = Inventory;
        if (inventory)
            inventory.OnCollectiblesChanged -= RecalculateFulfillment;

        base.UnregisterEvents();
    }

    public override bool DetermineIfFulfilled() => CollectedCollectiblesCount >= RequiredCollectiblesCount;

    private IEnumerator GatherCollectiblesCoroutine()
    {
        yield return null;
        GatherCollectibles();
    }

    private void GatherCollectibles()
    {
        m_collectibles.Clear();

        if (!CollectibleTemplate)
            return;

        m_collectibles.AddRange(FindObjectsOfType<Collectible>()
            .Where(collectible => collectible && collectible.Template == CollectibleTemplate));
    }

    private int CalculatePlayerDistance()
    {
        var player = PlayerContext.MainPlayer;
        if (!player)
            return 0;

        var playerPosition = player.transform.position;
        var playerFlatPosition = new Vector2(playerPosition.x, playerPosition.z);

        m_collectibles.RemoveAll(collectible => !collectible);

        if (!m_collectibles.Any())
        {
            RecalculateFulfillment();
            return -1;
        }

        return m_collectibles
            .Select(collectible => collectible.transform.position)
            .Select(collectiblePosition => new Vector2(collectiblePosition.x, collectiblePosition.z))
            .Min(collectibleFlatPosition => (int)Vector2.Distance(playerFlatPosition, collectibleFlatPosition));
    }
}