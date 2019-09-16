using UnityEngine;

public sealed class ObjectivesHUD : MonoBehaviour
{
    [SerializeField]
    private ObjectiveView m_currentObjectiveView = null;

    private void Update()
    {
        var gameplayController = GameplayController.Instance;
        if (!gameplayController)
            return;

        if (m_currentObjectiveView)
            m_currentObjectiveView.ObjectiveCondition = gameplayController.CurrentWinCondition as GameplayWinCondition;
    }
}