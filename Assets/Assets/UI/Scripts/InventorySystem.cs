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
        
        for (int i = 0; i < items.Length; i++)
        {   
            if(items[i] == inventory.SelectedEquipment)           
                return;
            

            if (items[i] == null)
            {
                items[i] = inventory?.SelectedEquipment;
                itemImages[i].sprite = inventory?.SelectedEquipment.Template.Icon;
                itemImages[i].enabled = true;
                return;
            }
        }
        
    }
    
}
