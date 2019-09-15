using System;

public abstract class UtilityEquipmentController : EquipmentControllerBase
{
    protected override Type DataModelType => typeof(UtilityEquipment);
    public new UtilityEquipment Equipment => (UtilityEquipment)base.Equipment;
    public new UtilityEquipmentTemplate EquipmentTemplate => Equipment.Template;
}