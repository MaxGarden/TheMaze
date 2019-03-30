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

    private EquipmentController m_controller;
    public GameObject EquipmentRoot => m_controller.gameObject;

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
        m_controller = Instantiate(Template.ControllerPrefab, transform);
        m_controller.Initialize(this);
    }

    public void Use()
    {
        m_controller.OnUse();
    }

    private void OnStateChanged()
    {
        InteractionRoot.SetActive(State == EquipmentState.Idle);
        EquipmentRoot.SetActive(State == EquipmentState.Equipped);
    }
}