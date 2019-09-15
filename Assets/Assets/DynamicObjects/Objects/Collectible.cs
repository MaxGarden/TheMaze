using System;

public sealed class Collectible : InventoryObject
{
    protected override Type TemplateType => typeof(CollectibleTemplate);
    public new CollectibleTemplate Template => (CollectibleTemplate)base.Template;
}