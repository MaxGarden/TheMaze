using UnityEngine;

public abstract class PlayerComponentBase : MonoBehaviour, IPlayerComponent
{
    public PlayerContext PlayerContext { get; private set; }

    void IPlayerComponent.OnPlayerContextInitialized(PlayerContext context)
    {
        PlayerContext = context;
    }
}