using System;
using System.Collections.Generic;
using UnityEngine;

public sealed class Inventory : MonoBehaviour, IInventoryInputHandler
{
    private readonly Dictionary<EquipmentTemplate.EquipmentType, Equipment> m_equipment = new Dictionary<EquipmentTemplate.EquipmentType, Equipment>();
    private readonly Dictionary<CollectibleTemplate, int> m_collectibles = new Dictionary<CollectibleTemplate, int>();

    public Equipment SelectedEquipment { get; private set; }

    private EquipmentTemplate.EquipmentType m_selectedEquipmentType = EquipmentTemplate.EquipmentType.Primary;
    public EquipmentTemplate.EquipmentType SelectedEquipmentType
    {
        get { return m_selectedEquipmentType; }
        set
        {
            m_selectedEquipmentType = value;
            RefreshSelectedEquipment();
        }
    }

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
        RefreshSelectedEquipment();
    }

    private void RefreshSelectedEquipment()
    {
        if (m_equipment.ContainsKey(SelectedEquipmentType))
            SelectedEquipment = m_equipment[SelectedEquipmentType];
    }

    void IInventoryInputHandler.ToggleEquipment()
    {
        switch(SelectedEquipmentType)
        {
            case EquipmentTemplate.EquipmentType.Primary:
                SelectedEquipmentType = EquipmentTemplate.EquipmentType.Secondary;
                break;
            case EquipmentTemplate.EquipmentType.Secondary:
                SelectedEquipmentType = EquipmentTemplate.EquipmentType.Primary;
                break;
            default:
                throw new InvalidOperationException("Unsupported equipment type!");
        }
    }

    void IInventoryInputHandler.DropEquipment()
    {
        //TODO
        m_equipment[SelectedEquipmentType] = null;
        RefreshSelectedEquipment();
    }
}