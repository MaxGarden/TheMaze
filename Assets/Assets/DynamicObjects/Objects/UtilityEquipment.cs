using System;

public class UtilityEquipment : Equipment
{
    protected override Type TemplateType => typeof(UtilityEquipmentTemplate);
    public new UtilityEquipmentTemplate Template => (UtilityEquipmentTemplate)base.Template;

    public float Durability { get; set; } = 0.0f;

    protected override void OnInitialize(EquipmentTemplate template)
    {
        Durability = Template.Durability;
    }
}