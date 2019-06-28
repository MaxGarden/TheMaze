using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ColliderSpicesCollisionProvider : ISpicesCollisionProvider
{
    private void OnObstacleHit(GameObject gameObject)
    {
        OnSpicesCollision(gameObject);
    }
}