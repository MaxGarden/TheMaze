public class Door : InteractiveObject
{
    public new DoorTemplate Template { get; private set; }

    public bool IsLocked { get; private set; } = true;
    public bool IsOpened { get; private set; } = false;

    public override void Initialize(DynamicObjectTemplate template)
    {
        base.Initialize(template);

        Template = (DoorTemplate)template;

        IsLocked = !!Template.RequiredCollectibleToOpen;
    }

    public void Unlock()
    {
        IsLocked = false;
    }

    public void Open()
    {
        if (IsLocked || IsOpened)
            return;

        IsOpened = true;
    }

    public void Close()
    {
        if (!IsOpened)
            return;

        IsOpened = false;
    }
}