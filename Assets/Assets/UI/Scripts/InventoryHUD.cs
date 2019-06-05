using UnityEngine;
using UnityEngine.UI;

public class InventoryHUD : MonoBehaviour
{
    public const int numberItemSlots = 4;
    public Equipment[] items = new Equipment[numberItemSlots];
    public Image[] itemImages = new Image[numberItemSlots];
    public Image[] selectedImages = new Image[numberItemSlots];
    private Inventory inventory;


    // -----------------
    public Slider durabilitySlider;
    private UtilityEquipment utilityEquipment;

    private void OnEnable()
    {
        inventory = PlayerContext.MainPlayer.Inventory;
        inventory.OnEquipmentChanged += EquipmentChange;

        // ------------------------------------
        durabilitySlider.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        inventory.OnEquipmentChanged -= EquipmentChange;

        // ------------------------------------
        durabilitySlider.gameObject.SetActive(false);
    }

    void EquipmentChange()
    {
        foreach(var entry in inventory.Equipment)
        {
            var equipment = entry.Value;
            var index = (int)entry.Key;

            itemImages[index].sprite = equipment ? equipment.Template.Icon : null;
            itemImages[index].enabled = !!equipment;
            items[index] = equipment;

             if(inventory.SelectedEquipment == entry.Value)
             {
                 selectedImages[index].enabled = true;
             } else
             {
                 selectedImages[index].enabled = false;
             }

            if(selectedImages[index].enabled && !items[index])
                selectedImages[index].enabled = false;
        }

        // --------------------------------------
        if (inventory.SelectedEquipment is UtilityEquipment)
        {
            utilityEquipment = (UtilityEquipment)inventory.SelectedEquipment;
            durabilitySlider.value = utilityEquipment.Template.Durability;
            durabilitySlider.gameObject.SetActive(true);
        }
        else
        {
            durabilitySlider.gameObject.SetActive(false);
        }
    }

    // ------------------------------------
    void Update()
    {
        if (durabilitySlider.gameObject.activeSelf)
            durabilitySlider.value = utilityEquipment.Durability;
    }
}