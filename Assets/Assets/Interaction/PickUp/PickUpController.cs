using UnityEngine;

public abstract class PickUpController : MonoBehaviour
{
    public abstract string PickUpName { get; }
    public abstract AudioClip PickUpSound { get; }

    public abstract void OnPickUp(Inventory inventory);
}