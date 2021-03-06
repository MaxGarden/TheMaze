﻿using UnityEngine;

[CreateAssetMenu(fileName = "MedkitTemplate", menuName = "Templates/Medkit Template")]
public sealed class MedkitTemplate : UtilityEquipmentTemplate
{
    [Header("Medkit")]

    [SerializeField]
    private AudioClip m_regenerationSound = null;
    public AudioClip RegenerationSound => m_regenerationSound;
}