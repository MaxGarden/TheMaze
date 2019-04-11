public abstract class UtilityEquipmentController : EquipmentControllerBase
{
    public new UtilityEquipment Equipment { get; private set; }
    public new UtilityEquipmentTemplate EquipmentTemplate => Equipment.Template;

    public override void Initialize(Equipment equipment)
    {
        base.Initialize(equipment);

        Equipment = (UtilityEquipment)equipment;
    }
}