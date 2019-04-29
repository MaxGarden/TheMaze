using UnityEngine;

public abstract class EquipmentController : MonoBehaviour
{
    public abstract void Initialize(Equipment equipment);

    public abstract void OnPickedUp(Inventory inventory);
    public abstract void OnDrop();

    public abstract void OnEquipped();
    public abstract void OnStored();

    public abstract void OnUse();
}