using UnityEngine;

[RequireComponent(typeof(Light))]
public sealed class FlashlightController : UtilityEquipmentController
{
    public new Flashlight Equipment { get; private set; }
    public new FlashlightTemplate EquipmentTemplate => Equipment.Template;

    private Light m_light = null;

    protected override void Awake()
    {
        base.Awake();

        m_light = GetComponent<Light>();
    }

    public override void Initialize(Equipment equipment)
    {
        base.Initialize(equipment);

        Equipment = (Flashlight)equipment;
        Equipment.OnTurnStateChanged += OnTurnStateChanged;

        InitializeLight();
    }

    private void OnDestroy()
    {
        Equipment.OnTurnStateChanged -= OnTurnStateChanged;
    }

    public override void OnUse()
    {
        if (Equipment.IsTurnedOn)
            Equipment.TurnOff();
        else
            Equipment.TryTurnOn();

        TryPlayInteractionSound(EquipmentTemplate.TurningOnOffSound);
    }

    protected override void OnStateChanged(Equipment.EquipmentState state)
    {
        base.OnStateChanged(state);

        if (state != global::Equipment.EquipmentState.Equipped)
            Equipment.TurnOff();
    }

    private void InitializeLight()
    {
        m_light.color = EquipmentTemplate.Color;
        m_light.cookie = EquipmentTemplate.Cookie;
        m_light.cookieSize = EquipmentTemplate.CookieSize;
        OnTurnStateChanged();
    }

    private void OnTurnStateChanged()
    {
        m_light.enabled = Equipment.IsTurnedOn;
    }

    private void Update()
    {
        if (m_light.enabled)
        {
            var normalizedDurability = Equipment.Durability / EquipmentTemplate.Durability;
            m_light.intensity = EquipmentTemplate.DimmingCurve.Evaluate(1.0f - normalizedDurability);
        }
    }
}