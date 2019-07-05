using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Spices))]
[RequireComponent(typeof(Animator))]
public sealed class SpicesController : ControllerBase
{
    [SerializeField]
    private string m_showTriggerName = "Show";

    [SerializeField]
    private string m_hideTriggerName = "Hide";

    private Spices m_spices;
    private Animator m_animator;

    private SpicesTemplate SpicesTemplate => m_spices.Template;

    protected override void Awake()
    {
        base.Awake();

        m_spices = GetComponent<Spices>();
        m_animator = GetComponent<Animator>();
    }

    private void Start()
    {
        StartCoroutine(SpicesCoroutine());
    }

    public void Show()
    {
        if (m_spices.AreShown)
            return;

        m_spices.Show();

        m_animator.SetTrigger(m_showTriggerName);
        TryPlayInteractionSound(SpicesTemplate.ShowSound);
    }

    public void Hide()
    {
        if (!m_spices.AreShown)
            return;

        m_spices.Hide();

        m_animator.SetTrigger(m_hideTriggerName);
        TryPlayInteractionSound(SpicesTemplate.HideSound);
    }

    private IEnumerator SpicesCoroutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(SpicesTemplate.TimeWhenShownInSeconds);
            Hide();
            yield return new WaitForSeconds(SpicesTemplate.TimeWhenHiddenInSeconds);
            Show();
        }
    }
}