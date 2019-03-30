public class InventoryObject : InteractiveObject
{
    public new InventoryObjectTemplate Template { get; private set; }

    public override void Initialize(DynamicObjectTemplate template)
    {
        base.Initialize(template);

        Template = (InventoryObjectTemplate)template;
    }
}