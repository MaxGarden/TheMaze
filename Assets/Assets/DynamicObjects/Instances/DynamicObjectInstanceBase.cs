using System;

public abstract class DynamicObjectInstanceBase<TemplateType> : DynamicObjectInstance
    where TemplateType : DynamicObjectTemplate
{
    public TemplateType Template { get; private set; }

    public sealed override void Initialize(DynamicObjectTemplate template)
    {
        Template = template as TemplateType;
        if (!Template)
            throw new ArgumentException("Invalid type of template!");

        OnInitialized();
    }

    protected virtual void OnInitialized()
    {
        //to override
    }
}