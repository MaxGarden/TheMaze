using UnityEngine;

public sealed class TestEquipmentController : UtilityEquipmentController
{
    public override void OnUse()
    {
        Equipment.Durability -= Equipment.Template.UseCost;

        if(Equipment.Durability < 0.0f)
        {
            Equipment.Durability = 0.0f;
            Debug.Log("Nope");
        }
        else
            Debug.Log($"Use: {Equipment.Durability} / {Equipment.Template.Durability} ");
    }
}