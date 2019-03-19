using UnityEngine;

public abstract class InteractionHandler : MonoBehaviour
{
    public abstract string InteractionDescription { get; }

    public abstract void Interact(InteractionContext context);

    private AudioSource m_audioSource = null;

    protected virtual void Awake()
    {
        m_audioSource = GetComponent<AudioSource>();
    }

    protected void PlayInteractionSound(AudioClip clip)
    {
        if (!m_audioSource)
        {
            Debug.LogWarning("Tried to play interaction sound, but audio source is null!");
            return;
        }

        m_audioSource.clip = clip;
        m_audioSource.Play();
    }
}