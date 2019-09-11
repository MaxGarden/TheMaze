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

    public new EquipmentTemplate Template => (EquipmentTemplate)base.Template;

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

    protected abstract void OnInitialize(EquipmentTemplate template);

    public sealed override void Initialize(DynamicObjectTemplate template)
    {
        base.Initialize(template);

        ValidateTemplate<EquipmentTemplate>(template);

        OnInitialize(Template);

        var controllerPrefab = Template.ControllerPrefab;
        if (!controllerPrefab)
            throw new InvalidOperationException("Controller prefab cannot be null!");

        Controller = Instantiate(controllerPrefab, transform);
        Controller.Initialize(this);

        OnStateChanged();
    }

    private void OnStateChanged()
    {
        InteractionRoot.SetActive(State == EquipmentState.Idle);
        EquipmentRoot.SetActive(State == EquipmentState.Equipped);
    }
}