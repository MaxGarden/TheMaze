using UnityEngine;
using UnityEngine.UI;

public sealed class InteractionVisualization : MonoBehaviour
{
    [SerializeField]
    private string m_interactionHintPrefix = null;

    [SerializeField]
    private Text m_interactionText = null;

    [SerializeField]
    private InteractionController m_interactionController = null;

    private void Update()
    {
        m_interactionText.text = CalculateInteractionText();
    }

    private string CalculateInteractionText()
    {
        if (m_interactionController.IsInteractionPossible)
            return m_interactionHintPrefix + m_interactionController.InteractionDescription;

        return string.Empty;
    }
}