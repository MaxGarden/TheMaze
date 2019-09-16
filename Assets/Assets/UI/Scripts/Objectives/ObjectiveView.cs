using UnityEngine;
using UnityEngine.UI;

public sealed class ObjectiveView : MonoBehaviour
{
    [SerializeField]
    private Text m_objectiveText = null;

    public GameplayWinCondition ObjectiveCondition { get; set; }

    private void Update()
    {
        if(m_objectiveText)
            m_objectiveText.gameObject.SetActive(ObjectiveCondition);

        if (!ObjectiveCondition)
            return;

        if (m_objectiveText)
            m_objectiveText.text = ObjectiveCondition.Objective;
    }
}