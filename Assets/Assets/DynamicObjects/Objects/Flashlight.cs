using System;
using UnityEngine;

public sealed class Flashlight : UtilityEquipment
{
    public new FlashlightTemplate Template { get; private set; }

    public event Action OnTurnStateChanged;

    private bool m_isTurnedOn = false;
    public bool IsTurnedOn
    {
        get { return m_isTurnedOn; }
        private set
        {
            if (m_isTurnedOn == value)
                return;

            m_isTurnedOn = value;
            OnTurnStateChanged?.Invoke();
        }
    }

    protected override void OnInitialize(EquipmentTemplate template)
    {
        base.OnInitialize(template);

        Template = (FlashlightTemplate)template;
    }

    public bool TryTurnOn()
    {
        if (Durability <= 0.0f)
            return false;

        return (IsTurnedOn = true);
    }

    public void TurnOff()
    {
        IsTurnedOn = false;
    }

    private void Update()
    {
        if(IsTurnedOn)
        {
            Durability -= Template.UseCost * Time.deltaTime;
            IsTurnedOn = Durability > 0.0f;
        }
    }
}