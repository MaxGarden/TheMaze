using UnityEngine;

public abstract class InteractionHandlersProvider : MonoBehaviour
{
    public abstract InteractionHandler ProvideHandler();
}
