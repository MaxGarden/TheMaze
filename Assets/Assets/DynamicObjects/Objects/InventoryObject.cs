using System;

public class InventoryObject : InteractiveObject
{
    protected override Type TemplateType => typeof(InventoryObjectTemplate);
    public new InventoryObjectTemplate Template => (InventoryObjectTemplate)base.Template;
}