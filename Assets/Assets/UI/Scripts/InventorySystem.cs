using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    public const int numberItemSlots = 4;
    public Equipment[] items = new Equipment[numberItemSlots];
    public Image[] itemImages = new Image[numberItemSlots];
    private Inventory inventory;

    private void OnEnable()
    {
        inventory = PlayerContext.MainPlayer.Inventory;
        inventory.OnEquipmentChanged += EquipmentChange;

    }

    private void OnDisable()
    {
        inventory.OnEquipmentChanged -= EquipmentChange;
    }

    void EquipmentChange()
    {
        foreach(var entry in inventory.Equipment)
        {
            var equipment = entry.Value;
            var index = (int)entry.Key;

            itemImages[index].sprite = equipment ? equipment.Template.Icon : null;
            itemImages[index].enabled = !!equipment;
        }
    }
}