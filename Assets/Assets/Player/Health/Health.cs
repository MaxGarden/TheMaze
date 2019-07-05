using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public sealed class Health : MonoBehaviour, IPlayerComponent
{
    [SerializeField]
    private float m_maximumHealth = 100.0f;
    public float MaximumHealth => m_maximumHealth;

    [SerializeField]
    private AudioClip m_damageSound = null;

    [SerializeField]
    private AudioClip m_healingSound = null;

    public PlayerContext PlayerContext { get; private set; }

    private float m_currentHealth;
    public float CurrentHealth
    {
        get { return m_currentHealth; }
        private set
        {
            m_currentHealth = value;
            m_currentHealth = Math.Min(Math.Max(0.0f, m_currentHealth), MaximumHealth);

            OnHealthChanged?.Invoke();
        }
    }

    private AudioSource m_audioSource;

    public event Action OnHealthChanged;

    private void Awake()
    {
        m_audioSource = GetComponent<AudioSource>();
    }


    public void Heal(float heal)
    {
        if (heal <= 0.0f)
            throw new ArgumentException("Heal cannot be less than zero.");

        CurrentHealth += heal;
        PlaySound(m_healingSound);
    }

    public void Damage(float damage)
    {
        if (damage <= 0.0f)
            throw new ArgumentException("Damage cannot be less than zero.");

        CurrentHealth -= damage;
        PlaySound(m_damageSound);
    }

    private void PlaySound(AudioClip sound)
    {
        if (!sound)
            return;

        m_audioSource.clip = sound;
        m_audioSource.Play();
    }

    void IPlayerComponent.OnPlayerContextInitialized(PlayerContext context)
    {
        PlayerContext = context;
        CurrentHealth = MaximumHealth;
    }
}