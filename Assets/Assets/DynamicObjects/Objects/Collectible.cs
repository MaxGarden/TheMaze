public sealed class Collectible : InventoryObject
{
    public new CollectibleTemplate Template => (CollectibleTemplate)base.Template;

    public override void Initialize(DynamicObjectTemplate template)
    {
        base.Initialize(template);

        ValidateTemplate<CollectibleTemplate>(template);
    }
}