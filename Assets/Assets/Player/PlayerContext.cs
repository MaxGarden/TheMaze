using System;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerContext : MonoBehaviour
{
    static public PlayerContext MainPlayer { get; private set; }

    public Inventory Inventory { get; private set; }
    public IInventoryInputHandler InventoryInputHandler => Inventory;

    private IList<IPlayerComponent> m_playerComponents = new List<IPlayerComponent>();

    private void EnsureComponents()
    {
        Inventory = EnsureComponent<Inventory>();
    }

    private void Awake()
    {
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

    private void Start()
    {
        foreach (var playerComponent in m_playerComponents)
            playerComponent.OnPlayerContextStart();
    }

    private T EnsureComponent<T>() where T : MonoBehaviour
    {
        var component = EnsureComponentInternal<T>();

        var playerComponent = component as IPlayerComponent;
        m_playerComponents.Add(playerComponent);

        return component;
    }

    private T EnsureComponentInternal<T>() where T : MonoBehaviour
    {
        var component = GetComponent<T>();
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