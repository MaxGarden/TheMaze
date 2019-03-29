using UnityEngine;

public abstract class DynamicObjectInstance : MonoBehaviour
{
    public abstract void Initialize(DynamicObjectTemplate template);
}