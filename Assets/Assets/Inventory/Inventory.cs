using System;
using System.Collections.Generic;
using UnityEngine;

public sealed class Inventory : MonoBehaviour, IInventoryInputHandler
{
    private readonly Dictionary<EquipmentTemplate.EquipmentType, Equipment> m_equipment = new Dictionary<EquipmentTemplate.EquipmentType, Equipment>();
    private readonly Dictionary<CollectibleTemplate, int> m_collectibles = new Dictionary<CollectibleTemplate, int>();

    public event Action OnEquipmentChanged;
    public event Action OnCollectiblesChanged;

    public Equipment SelectedEquipment { get; private set; }

    private EquipmentTemplate.EquipmentType m_selectedEquipmentType = EquipmentTemplate.EquipmentType.Primary;
    public EquipmentTemplate.EquipmentType SelectedEquipmentType
    {
        get { return m_selectedEquipmentType; }
        set
        {
            m_selectedEquipmentType = value;
            RefreshEquipment();
        }
    }

    public void AddCollectible(Collectible collectible)
    {
        var template = collectible.Template;
        if (!m_collectibles.ContainsKey(template))
            m_collectibles.Add(template, 0);

        m_collectibles[template] += template.CollectIncrement;

        OnCollectiblesChanged?.Invoke();
    }

    public void SetEquipment(Equipment equipment)
    {
        var type = equipment.Template.Type;

        DropEquipment(type);
        m_equipment[type] = equipment;
        RefreshEquipment();
    }

    private void RefreshEquipment()
    {
        if (m_equipment.ContainsKey(SelectedEquipmentType))
            SelectedEquipment = m_equipment[SelectedEquipmentType];

        OnEquipmentChanged?.Invoke();
    }

    private void DropEquipment(EquipmentTemplate.EquipmentType type)
    {
        Equipment selectedEquipment;
        if (!m_equipment.TryGetValue(type, out selectedEquipment))
            return;

        if (!selectedEquipment)
            return;

        selectedEquipment.Controller.OnDrop(this);
        m_equipment[type] = null;
        RefreshEquipment();
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
        DropEquipment(SelectedEquipmentType);
    }
}