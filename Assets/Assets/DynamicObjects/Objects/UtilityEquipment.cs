public class UtilityEquipment : Equipment
{
    public new UtilityEquipmentTemplate Template { get; private set; }

    public float Durability { get; set; } = 0.0f;

    protected override void OnInitialize(EquipmentTemplate template)
    {
        Template = (UtilityEquipmentTemplate)template;

        Durability = Template.Durability;
    }
}