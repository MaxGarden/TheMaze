using UnityEngine;

public abstract class EquipmentControllerBase : EquipmentController
{
    public Equipment Equipment { get; private set; }
    public EquipmentTemplate EquipmentTemplate => Equipment.Template;

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
    }

    public override void OnDrop(Inventory inventory)
    {
        TryPlayInteractionSound(EquipmentTemplate.DropSound);

        var inventoryTransform = inventory.transform;
        var dropPosition = inventoryTransform.position + inventoryTransform.forward * 3.0f;

        Equipment.transform.position = dropPosition;
        Equipment.State = Equipment.EquipmentState.Idle;

        var rigidbody = Equipment.InteractionRoot.GetComponent<Rigidbody>();
        if (!rigidbody)
            return;

        rigidbody.velocity = Vector3.zero;
        rigidbody.rotation = Quaternion.identity;
        rigidbody.position = dropPosition;
        rigidbody.AddRelativeForce(inventoryTransform.forward * m_dropThrowForce, ForceMode.Impulse);
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