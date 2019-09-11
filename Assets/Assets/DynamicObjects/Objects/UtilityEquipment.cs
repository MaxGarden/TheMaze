public class UtilityEquipment : Equipment
{
    public new UtilityEquipmentTemplate Template => (UtilityEquipmentTemplate)base.Template;

    public float Durability { get; set; } = 0.0f;

    protected override void OnInitialize(EquipmentTemplate template)
    {
        ValidateTemplate<UtilityEquipmentTemplate>(template);

        Durability = Template.Durability;
    }
}