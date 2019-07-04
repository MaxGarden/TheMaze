using System;

public sealed class MedkitController : UtilityEquipmentController
{
    public new Medkit Equipment { get; private set; }
    public new MedkitTemplate EquipmentTemplate => Equipment.Template;

    public override void Initialize(Equipment equipment)
    {
        base.Initialize(equipment);

        Equipment = (Medkit)equipment;
    }

    public override void OnUse()
    {
        if (!Inventory || Equipment.Durability <= 0.0f)
            return;

        if(Equipment.Heal(Inventory.PlayerContext.Health))
            TryPlayInteractionSound(EquipmentTemplate.RegenerationSound);
    }
}