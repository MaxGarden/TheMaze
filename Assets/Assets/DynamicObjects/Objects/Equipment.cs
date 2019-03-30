public abstract class Equipment : InventoryObject
{
    public new EquipmentTemplate Template { get; private set; }

    public override void Initialize(DynamicObjectTemplate template)
    {
        base.Initialize(template);

        Template = (EquipmentTemplate)template;
    }

    public abstract void Use();
}