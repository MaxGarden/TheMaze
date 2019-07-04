using System;
using System.Collections.Generic;
using UnityEngine;

public sealed class Inventory : MonoBehaviour, IInventoryInputHandler, IPlayerComponent
{
    public PlayerContext PlayerContext { get; private set; }

    public Dictionary<CollectibleTemplate, int> Collectibles { get; } = new Dictionary<CollectibleTemplate, int>();
    public Dictionary<EquipmentTemplate.EquipmentType, Equipment> Equipment { get; } = new Dictionary<EquipmentTemplate.EquipmentType, Equipment>();

    public event Action OnEquipmentChanged;
    public event Action OnCollectiblesChanged;

    private Equipment m_selectedEquipment;
    public Equipment SelectedEquipment
    {
        get { return m_selectedEquipment; }
        private set
        {
            m_selectedEquipment?.Controller.OnStored();
            m_selectedEquipment = value;
            m_selectedEquipment?.Controller.OnEquipped();
        }
    }

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
        if (!Collectibles.ContainsKey(template))
            Collectibles.Add(template, 0);

        Collectibles[template] += template.CollectIncrement;

        OnCollectiblesChanged?.Invoke();
    }

    public void SetEquipment(Equipment equipment)
    {
        var type = equipment.Template.Type;

        DropEquipment(type);
        Equipment[type] = equipment;
        equipment.Controller.OnPickedUp(this);
        RefreshEquipment();
    }

    private void RefreshEquipment()
    {
        if (Equipment.ContainsKey(SelectedEquipmentType))
            SelectedEquipment = Equipment[SelectedEquipmentType];

        OnEquipmentChanged?.Invoke();
    }

    private void DropEquipment(EquipmentTemplate.EquipmentType type)
    {
        Equipment selectedEquipment;
        if (!Equipment.TryGetValue(type, out selectedEquipment))
            return;

        if (!selectedEquipment)
            return;

        Equipment[type] = null;
        RefreshEquipment();
        selectedEquipment.Controller.OnDrop();
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
        RefreshEquipment();
    }

    void IInventoryInputHandler.DropEquipment()
    {
        DropEquipment(SelectedEquipmentType);
    }

    void IInventoryInputHandler.UseEquipment()
    {
        SelectedEquipment?.Controller?.OnUse();
    }

    void IPlayerComponent.OnPlayerContextInitialized(PlayerContext context)
    {
        PlayerContext = context;
    }
}