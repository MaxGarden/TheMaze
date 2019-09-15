using System;
using UnityEngine;

public abstract class EquipmentControllerBase : EquipmentController
{
    public Equipment Equipment { get; private set; }
    public EquipmentTemplate EquipmentTemplate => Equipment.Template;

    public Transform OriginalEquipmentParentTransform { get; private set; }

    protected Inventory Inventory { get; private set; }

    protected abstract Type DataModelType { get; }

    [SerializeField]
    private float m_dropThrowForce = 8.0f;

    public override void Initialize(Equipment equipment)
    {
        if(!DataModelType.IsAssignableFrom(equipment.GetType()))
            throw new InvalidOperationException("Invalid data model type!");

        Equipment = equipment;
        OriginalEquipmentParentTransform = Equipment.transform.parent.transform;
    }

    public sealed override void OnPickedUp(Inventory inventory)
    {
        Inventory = inventory;

        Equipment.transform.SetParent(Inventory.transform, false);
        Equipment.transform.localPosition = Vector3.zero;

        Equipment.State = Equipment.EquipmentState.Stored;
        NotifyStateChanged();
    }

    public sealed override void OnDrop()
    {
        TryPlayInteractionSound(EquipmentTemplate.DropSound);

        var inventoryTransform = transform.parent.transform;
        var forwardDirection = transform.parent.transform.TransformDirection(Vector3.forward);
        var dropPosition = inventoryTransform.position + forwardDirection;

        Equipment.transform.SetParent(OriginalEquipmentParentTransform.transform, false);

        Equipment.transform.localPosition = Vector3.zero;
        Equipment.transform.position = dropPosition;
        Equipment.State = Equipment.EquipmentState.Idle;

        Inventory = null;
        NotifyStateChanged();

        var rigidbody = Equipment.InteractionRoot.GetComponent<Rigidbody>();
        if (!rigidbody)
            return;

        rigidbody.velocity = Vector3.zero;
        rigidbody.rotation = Quaternion.identity;
        rigidbody.position = dropPosition;
        rigidbody.AddRelativeForce(forwardDirection * m_dropThrowForce, ForceMode.Impulse);
    }

    public sealed override void OnEquipped()
    {
        Equipment.State = Equipment.EquipmentState.Equipped;
        NotifyStateChanged();
    }

    public sealed override void OnStored()
    {
        Equipment.State = Equipment.EquipmentState.Stored;
        NotifyStateChanged();
    }

    private void NotifyStateChanged()
    {
        OnStateChanged(Equipment.State);
    }

    protected virtual void OnStateChanged(Equipment.EquipmentState state)
    {
        //to override
    }
}