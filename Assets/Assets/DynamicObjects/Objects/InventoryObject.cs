public class InventoryObject : InteractiveObject
{
    public new InventoryObjectTemplate Template => (InventoryObjectTemplate)base.Template;

    public override void Initialize(DynamicObjectTemplate template)
    {
        base.Initialize(template);

        ValidateTemplate<InventoryObjectTemplate>(Template);
    }
}