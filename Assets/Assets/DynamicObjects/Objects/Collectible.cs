public sealed class Collectible : InventoryObject
{
    public new CollectibleTemplate Template { get; private set; }

    public override void Initialize(DynamicObjectTemplate template)
    {
        base.Initialize(template);

        Template = (CollectibleTemplate)template;
    }
}