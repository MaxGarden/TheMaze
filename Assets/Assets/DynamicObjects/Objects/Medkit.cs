public sealed class Medkit : UtilityEquipment
{
    public new MedkitTemplate Template { get; private set; }

    protected override void OnInitialize(EquipmentTemplate template)
    {
        base.OnInitialize(template);

        Template = (MedkitTemplate)template;
    }
}