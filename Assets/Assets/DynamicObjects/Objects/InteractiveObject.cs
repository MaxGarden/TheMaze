
public class InteractiveObject : DynamicObject
{
    public InteractiveObjectTemplate Template { get; private set; }

    public override void Initialize(DynamicObjectTemplate template)
    {
        Template = (InteractiveObjectTemplate)template;
        Instantiate(Template.ColliderPrefab, transform);
    }
}