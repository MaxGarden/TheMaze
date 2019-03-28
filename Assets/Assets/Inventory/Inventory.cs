using System;
using System.Collections.Generic;
using UnityEngine;

public sealed class Inventory : MonoBehaviour
{
    private readonly Dictionary<ItemTemplate.ItemType, ItemInstance> m_items = new Dictionary<ItemTemplate.ItemType, ItemInstance>();
    private readonly Dictionary<CollectibleTemplate, int> m_collectibles = new Dictionary<CollectibleTemplate, int>();

    public void AddCollectible(CollectibleInstance collectible)
    {
        var template = collectible.Template;
        if (!m_collectibles.ContainsKey(template))
            m_collectibles.Add(template, 0);

        m_collectibles[template] += template.CollectIncrement;
    }

    public void SetItem(ItemInstance item)
    {
        m_items[item.Template.Type] = item;
    }
}