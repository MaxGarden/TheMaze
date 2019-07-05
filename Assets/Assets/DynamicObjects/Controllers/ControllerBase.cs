using UnityEngine;

public abstract class ControllerBase : MonoBehaviour
{
    private AudioSource m_audioSource = null;

    protected virtual void Awake()
    {
        m_audioSource = GetComponent<AudioSource>();
    }

    protected void TryPlayInteractionSound(AudioClip clip)
    {
        if (!clip)
            return;

        if (!m_audioSource)
        {
            AudioSource.PlayClipAtPoint(clip, transform.position);
            return;
        }

        m_audioSource.clip = clip;
        m_audioSource.Play();
    }
}