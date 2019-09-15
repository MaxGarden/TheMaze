using System;

public sealed class MedkitController : UtilityEquipmentController
{
    protected override Type DataModelType => typeof(Medkit);
    public new Medkit Equipment => (Medkit)base.Equipment;
    public new MedkitTemplate EquipmentTemplate => Equipment.Template;

    public override void OnUse()
    {
        if (!Inventory || Equipment.Durability <= 0.0f)
            return;

        if(Equipment.Heal(Inventory.PlayerContext.Health))
            TryPlayInteractionSound(EquipmentTemplate.RegenerationSound);
    }
}