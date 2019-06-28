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

    public PlayerContext PlayerContext { get; private set; }
    public float CurrentHealth { get; private set; }

    private AudioSource m_audioSource;

    public event Action OnHealthChanged;

    private void Awake()
    {
        m_audioSource = GetComponent<AudioSource>();
    }

    public void Damage(float damage)
    {
        CurrentHealth -= damage;

        m_audioSource.clip = m_damageSound;
        m_audioSource.Play();

        OnHealthChanged?.Invoke();
    }

    void IPlayerComponent.OnPlayerContextInitialized(PlayerContext context)
    {
        PlayerContext = context;
        CurrentHealth = MaximumHealth;
    }
}