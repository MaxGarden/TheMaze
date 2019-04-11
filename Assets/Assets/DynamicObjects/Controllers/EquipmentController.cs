using UnityEngine;

public abstract class EquipmentController : MonoBehaviour
{
    public abstract void Initialize(Equipment equipment);

    public abstract void OnUse();
    public abstract void OnDrop(Inventory inventory);
}