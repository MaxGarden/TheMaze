using UnityEngine;

[RequireComponent(typeof(Door))]
[RequireComponent(typeof(Animator))]
public sealed class DoorController : ControllerBase
{
    [SerializeField]
    private string m_openTriggerName = "Open";

    [SerializeField]
    private string m_closeTriggerName = "Close";

    private Animator m_doorAnimator = null;

    private Door m_door;
    public DoorTemplate DoorTemplate => m_door.Template;
    public CollectibleTemplate RequiredCollectibleToOpen => DoorTemplate.RequiredCollectibleToOpen;
    public bool IsLocked => m_door.IsLocked;
    public bool IsOpened => m_door.IsOpened;

    protected override void Awake()
    {
        base.Awake();

        m_door = GetComponent<Door>();
        m_doorAnimator = GetComponent<Animator>();
    }

    public void Push(Inventory inventory)
    {
        if (m_door.IsLocked)
        {
            if (!HasRequiredCollectibleToOpen(inventory))
            {
                TryPlayInteractionSound(DoorTemplate.LockedSound);
                return;
            }

            m_door.Unlock();
        }

        if (m_door.IsOpened)
        {
            m_door.Close();
            m_doorAnimator.SetTrigger(m_closeTriggerName);
            TryPlayInteractionSound(DoorTemplate.CloseSound);
        }
        else
        {
            m_door.Open();
            m_doorAnimator.SetTrigger(m_openTriggerName);
            TryPlayInteractionSound(DoorTemplate.OpenSound);
        }
    }

    public bool HasRequiredCollectibleToOpen(Inventory inventory)
    {
        var requiredCollectibleToOpen = RequiredCollectibleToOpen;
        if (!requiredCollectibleToOpen)
            return true;

        if (!inventory.Collectibles.TryGetValue(requiredCollectibleToOpen, out var collectiblesCount))
            return false;

        return collectiblesCount > 0;
    }
}