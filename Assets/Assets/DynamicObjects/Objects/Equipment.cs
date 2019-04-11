using System;
using UnityEngine;

public abstract class Equipment : InventoryObject
{
    public enum EquipmentState
    {
        Idle,
        Stored,
        Equipped
    }

    public new EquipmentTemplate Template { get; private set; }

    public EquipmentController Controller { get; private set; }
    public GameObject EquipmentRoot => Controller.gameObject;

    private EquipmentState m_state = EquipmentState.Idle;
    public EquipmentState State
    {
        get { return m_state; }
        set
        {
            if (m_state == value)
                return;

            m_state = value;
            OnStateChanged();
        }
    }

    public override void Initialize(DynamicObjectTemplate template)
    {
        base.Initialize(template);

        Template = (EquipmentTemplate)template;

        var controllerPrefab = Template.ControllerPrefab;
        if (!controllerPrefab)
            throw new InvalidOperationException("Controller prefab cannot be null!");

        Controller = Instantiate(controllerPrefab, transform);
        Controller.Initialize(this);

        OnStateChanged();
    }

    public void Use()
    {
        Controller.OnUse();
    }

    private void OnStateChanged()
    {
        InteractionRoot.SetActive(State == EquipmentState.Idle);
        EquipmentRoot.SetActive(State == EquipmentState.Equipped);
    }
}