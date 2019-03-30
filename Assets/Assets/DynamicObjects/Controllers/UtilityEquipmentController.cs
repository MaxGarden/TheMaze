public abstract class UtilityEquipmentController : EquipmentController
{
    public UtilityEquipment Equipment { get; private set; }

    public sealed override void Initialize(Equipment equipment)
    {
        Equipment = (UtilityEquipment)equipment;
    }
}