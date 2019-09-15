using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Spikes))]
[RequireComponent(typeof(Animator))]
public sealed class SpikesController : ControllerBase
{
    [SerializeField]
    private string m_showTriggerName = "Show";

    [SerializeField]
    private string m_hideTriggerName = "Hide";

    private Spikes m_spikes;
    private Animator m_animator;

    private SpikesTemplate SpikesTemplate => m_spikes.Template;

    protected override void Awake()
    {
        base.Awake();

        m_spikes = GetComponent<Spikes>();
        m_animator = GetComponent<Animator>();
    }

    private void Start()
    {
        StartCoroutine(SpikesCoroutine());
    }

    public void Show()
    {
        if (m_spikes.AreShown)
            return;

        m_spikes.Show();

        m_animator.SetTrigger(m_showTriggerName);
        TryPlayInteractionSound(SpikesTemplate.ShowSound);
    }

    public void Hide()
    {
        if (!m_spikes.AreShown)
            return;

        m_spikes.Hide();

        m_animator.SetTrigger(m_hideTriggerName);
        TryPlayInteractionSound(SpikesTemplate.HideSound);
    }

    private IEnumerator SpikesCoroutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(SpikesTemplate.TimeWhenShownInSeconds);
            Hide();
            yield return new WaitForSeconds(SpikesTemplate.TimeWhenHiddenInSeconds);
            Show();
        }
    }
}