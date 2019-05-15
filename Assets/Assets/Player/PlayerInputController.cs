﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public sealed class PlayerInputController : PlayerComponentBase
{
    [SerializeField]
    private string m_interactButtonName = "Interact";
    public string InteractButtonName => m_interactButtonName;

    [SerializeField]
    private string m_toggleEquipmentButtonName = "ToggleEquipment";
    public string ToggleEquipmentButtonName => m_toggleEquipmentButtonName;

    [SerializeField]
    private string m_dropEquipmentButtonName = "DropEquipment";
    public string DropEquipmentButtonName => m_dropEquipmentButtonName;

    [SerializeField]
    private string m_useEquipmentButtonName = "UseEquipment";
    public string UseEquipmentButtonName => m_useEquipmentButtonName;

    private Dictionary<string, Action> m_buttonHandlers;

    public PlayerInputController()
    {
        BuildButtonHandlers(out m_buttonHandlers);
    }

    private void BuildButtonHandlers(out Dictionary<string, Action> buttonHandlers)
    {
        buttonHandlers = new Dictionary<string, Action>()
        {
            {InteractButtonName, () => PlayerContext.InteractionInputHandler.Interact() },
            {ToggleEquipmentButtonName, () => PlayerContext.InventoryInputHandler.ToggleEquipment() },
            {DropEquipmentButtonName, () => PlayerContext.InventoryInputHandler.DropEquipment() },
            {UseEquipmentButtonName, () => PlayerContext.InventoryInputHandler.UseEquipment() },
        };
    }

    private void Update()
    {
        foreach(var entry in m_buttonHandlers)
        {
            if (CrossPlatformInputManager.GetButtonDown(entry.Key))
                entry.Value.Invoke();
        }
    }
}