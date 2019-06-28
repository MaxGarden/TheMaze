using UnityEngine;

[CreateAssetMenu(fileName = "FlashlightTemplate", menuName = "Templates/Flashlight Template")]
public sealed class FlashlightTemplate : UtilityEquipmentTemplate
{
    [Header("Flashlight")]

    [SerializeField]
    private AnimationCurve m_dimmingCurve = null;
    public AnimationCurve DimmingCurve => m_dimmingCurve;

    [SerializeField]
    private Color m_color = Color.white;
    public Color Color => m_color;

    [SerializeField]
    private Texture2D m_cookie = null;
    public Texture2D Cookie => m_cookie;

    [SerializeField]
    private float m_cookieSize = 1.0f;
    public float CookieSize => m_cookieSize;

    [SerializeField]
    private AudioClip m_turningOnOffSound = null;
    public AudioClip TurningOnOffSound => m_turningOnOffSound;
}