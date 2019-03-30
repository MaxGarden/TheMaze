public sealed class UtilityEquipment : Equipment
{
    public new UtilityEquipmentTemplate Template { get; private set; }

    public float Durability { get; set; } = 0.0f;

    public override void Initialize(DynamicObjectTemplate template)
    {
        base.Initialize(template);

        Template = (UtilityEquipmentTemplate)template;

        Durability = Template.Durability;
    }
}