using UnityEngine;

public abstract class EquipmentControllerBase : EquipmentController
{
    public Equipment Equipment { get; private set; }
    public EquipmentTemplate EquipmentTemplate => Equipment.Template;

    public Transform OriginalEquipmentParentTransform { get; private set; }

    [SerializeField]
    private float m_dropThrowForce = 8.0f;

    private AudioSource m_audioSource = null;

    protected virtual void Awake()
    {
        m_audioSource = GetComponent<AudioSource>();
    }

    public override void Initialize(Equipment equipment)
    {
        Equipment = equipment;
        OriginalEquipmentParentTransform = Equipment.transform.parent.transform;
    }

    public sealed override void OnPickedUp(Inventory inventory)
    {
        Equipment.transform.SetParent(inventory.transform, false);
        Equipment.transform.localPosition = Vector3.zero;

        Equipment.State = Equipment.EquipmentState.Stored;
        NotifyStateChanged();
    }

    public sealed override void OnDrop()
    {
        TryPlayInteractionSound(EquipmentTemplate.DropSound);

        var inventoryTransform = transform.parent.transform;
        var forwardDirection = transform.parent.transform.TransformDirection(Vector3.forward);
        var dropPosition = inventoryTransform.position + forwardDirection;

        Equipment.transform.SetParent(OriginalEquipmentParentTransform.transform, false);

        Equipment.transform.localPosition = Vector3.zero;
        Equipment.transform.position = dropPosition;
        Equipment.State = Equipment.EquipmentState.Idle;
        NotifyStateChanged();

        var rigidbody = Equipment.InteractionRoot.GetComponent<Rigidbody>();
        if (!rigidbody)
            return;

        rigidbody.velocity = Vector3.zero;
        rigidbody.rotation = Quaternion.identity;
        rigidbody.position = dropPosition;
        rigidbody.AddRelativeForce(forwardDirection * m_dropThrowForce, ForceMode.Impulse);
    }

    public sealed override void OnEquipped()
    {
        Equipment.State = Equipment.EquipmentState.Equipped;
        NotifyStateChanged();
    }

    public sealed override void OnStored()
    {
        Equipment.State = Equipment.EquipmentState.Stored;
        NotifyStateChanged();
    }

    private void NotifyStateChanged()
    {
        OnStateChanged(Equipment.State);
    }

    protected virtual void OnStateChanged(Equipment.EquipmentState state)
    {
        //to override
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