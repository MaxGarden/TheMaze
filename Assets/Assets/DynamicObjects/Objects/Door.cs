﻿using System;

public class Door : InteractiveObject
{
    protected override Type TemplateType => typeof(DoorTemplate);
    public new DoorTemplate Template => (DoorTemplate)base.Template;

    public bool IsLocked { get; private set; } = true;
    public bool IsOpened { get; private set; } = false;

    public override void Initialize(DynamicObjectTemplate template)
    {
        base.Initialize(template);

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