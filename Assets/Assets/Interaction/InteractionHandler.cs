using UnityEngine;

public abstract class InteractionHandler : MonoBehaviour
{
    public abstract string InteractionDescription { get; }

    public abstract bool Interact(InteractionContext context);
}