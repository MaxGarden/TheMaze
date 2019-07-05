using System;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public sealed class PlayerContext : MonoBehaviour
{
    static public PlayerContext MainPlayer { get; private set; }

    public Health Health { get; private set; }
    public KnockbackController KnockbackController { get; private set; }
    public FirstPersonController FirstPersonController { get; private set; }

    public Inventory Inventory { get; private set; }
    public IInventoryInputHandler InventoryInputHandler => Inventory;

    public InteractionController InteractionController { get; private set; }
    public IInteractionInputHandler InteractionInputHandler => InteractionController;

    public DisplayController DisplayController { get; private set; }
    public IDisplayInputHandler DisplayInputHandler => DisplayController;

    public PlayerInputController InputController { get; private set; }

    private IList<IPlayerComponent> m_playerComponents = new List<IPlayerComponent>();

    private void EnsureComponents()
    {
        Health = EnsureComponent<Health>();
        KnockbackController = EnsureComponent<KnockbackController>();
        FirstPersonController = EnsureComponent<FirstPersonController>();
        Inventory = EnsureComponent<Inventory>();
        InteractionController = EnsureComponent<InteractionController>();
        InputController = EnsureComponent<PlayerInputController>();
        DisplayController = EnsureComponent<DisplayController>();
    }

    private void Awake()
    {
        Initialize();

        if (MainPlayer)
            throw new InvalidOperationException("More than one main player!");

        MainPlayer = this;
    }

    private void OnDestroy()
    {
        MainPlayer = null;
    }

    private void Initialize()
    {
        EnsureComponents();

        foreach (var playerComponent in m_playerComponents)
            playerComponent.OnPlayerContextInitialized(this);
    }

    private T EnsureComponent<T>() where T : MonoBehaviour
    {
        var component = EnsureComponentInternal<T>();

        if (component is IPlayerComponent playerComponent)
            m_playerComponents.Add(playerComponent);

        return component;
    }

    private T EnsureComponentInternal<T>() where T : MonoBehaviour
    {
        var component = GetComponentInChildren<T>();
        if (!component)
            component = CreatePersistent<T>();

        if (!component)
            throw new InvalidOperationException("Cannot create player context's component");

        return component;
    }

    private T CreatePersistent<T>() where T : MonoBehaviour
    {
        return gameObject.AddComponent<T>();
    }
}