using System;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public sealed class PlayerInputController : PlayerComponentBase
{
    [SerializeField]
    private string m_interactButtonName = "Interact";
    public string InteractButtonName => m_interactButtonName;

    private Dictionary<string, Action> m_buttonHandlers;

    public PlayerInputController()
    {
        BuildButtonHandlers(out m_buttonHandlers);
    }

    private void BuildButtonHandlers(out Dictionary<string, Action> buttonHandlers)
    {
        buttonHandlers = new Dictionary<string, Action>()
        {
            {InteractButtonName, () => PlayerContext.InteractionInputHandler.Interact() }
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