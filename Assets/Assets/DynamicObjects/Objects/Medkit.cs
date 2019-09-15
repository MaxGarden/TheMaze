using System;

public sealed class Medkit : UtilityEquipment
{
    protected override Type TemplateType => typeof(MedkitTemplate);
    public new MedkitTemplate Template => (MedkitTemplate)base.Template;

    public bool Heal(Health health)
    {
        var missingHealth = health.MaximumHealth - health.CurrentHealth;
        var availableHealing = Math.Min(Durability, Template.UseCost);

        var healingValue = Math.Min(missingHealth, availableHealing);

        if (healingValue <= 0.0f)
            return false;

        Durability -= healingValue;
        health.Heal(healingValue);
        return true;
    }
}