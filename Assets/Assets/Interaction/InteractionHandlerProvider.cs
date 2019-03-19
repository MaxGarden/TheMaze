using UnityEngine;

public abstract class InteractionHandlerProvider : MonoBehaviour
{
    public abstract InteractionHandler ProvideHandler();
}