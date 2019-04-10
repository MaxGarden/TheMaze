using System.Collections.Generic;
using UnityEngine;

public sealed class Inventory : MonoBehaviour, IInventoryInputHandler
{
    private readonly Dictionary<EquipmentTemplate.EquipmentType, Equipment> m_equipment = new Dictionary<EquipmentTemplate.EquipmentType, Equipment>();
    private readonly Dictionary<CollectibleTemplate, int> m_collectibles = new Dictionary<CollectibleTemplate, int>();

    public void AddCollectible(Collectible collectible)
    {
        var template = collectible.Template;
        if (!m_collectibles.ContainsKey(template))
            m_collectibles.Add(template, 0);

        m_collectibles[template] += template.CollectIncrement;
    }

    public void SetEquipment(Equipment equipment)
    {
        m_equipment[equipment.Template.Type] = equipment;
    }
}