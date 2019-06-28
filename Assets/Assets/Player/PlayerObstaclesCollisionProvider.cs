using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerObstaclesCollisionProvider : MonoBehaviour
{
    [SerializeField]
    private string m_obstacleTag = "Obstacle";

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.CompareTag(m_obstacleTag))
            hit.transform.SendMessage("OnObstacleHit", gameObject);
    }
}