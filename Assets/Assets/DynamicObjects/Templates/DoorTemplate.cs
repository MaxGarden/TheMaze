using UnityEngine;

[CreateAssetMenu(fileName = "DoorTemplate", menuName = "Templates/Door Template")]
public sealed class DoorTemplate : InteractiveObjectTemplate
{
    [Header("Door")]

    [SerializeField]
    private AudioClip m_openSound = null;
    public AudioClip OpenSound => m_openSound;

    [SerializeField]
    private AudioClip m_closeSound = null;
    public AudioClip CloseSound => m_closeSound;

    [SerializeField]
    private AudioClip m_lockedSound = null;
    public AudioClip LockedSound => m_lockedSound;

    [SerializeField]
    private CollectibleTemplate m_requiredCollectibleToOpen = null;
    public CollectibleTemplate RequiredCollectibleToOpen => m_requiredCollectibleToOpen;
}