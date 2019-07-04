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

        var health = Inventory.PlayerContext.Health;
        var missingHealth = health.MaximumHealth - health.CurrentHealth;
        var availableHealing = Math.Min(Equipment.Durability, EquipmentTemplate.UseCost);

        var healingValue = Math.Min(missingHealth, availableHealing);

        Equipment.Durability -= healingValue;
        health.Heal(healingValue);

        TryPlayInteractionSound(EquipmentTemplate.RegenerationSound);
    }
}