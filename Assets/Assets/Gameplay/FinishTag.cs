using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public sealed class FinishTag : MonoBehaviour
{
    public event Action OnTriggered;

    private void OnObstacleHit(GameObject gameObject)
    {
        if (gameObject.GetComponent<PlayerContext>() == PlayerContext.MainPlayer)
            OnTriggered?.Invoke();
    }
}