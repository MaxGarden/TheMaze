using UnityEngine;

public class InventoryObjectTemplate : InteractiveObjectTemplate
{
    [SerializeField]
    private Sprite m_icon = null;
    public Sprite Icon => m_icon;

    [SerializeField]
    private AudioClip m_pickUpSound = null;
    public AudioClip PickUpSound => m_pickUpSound;
}