using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ColliderSpikesCollisionProvider : ISpikesCollisionProvider
{
    private void OnObstacleHit(GameObject gameObject)
    {
        OnSpikesCollision(gameObject);
    }
}