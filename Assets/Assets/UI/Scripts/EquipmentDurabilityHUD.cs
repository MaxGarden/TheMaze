using UnityEngine;
using UnityEngine.UI;

public class EquipmentDurabilityHUD : MonoBehaviour
{
    public Slider durabilitySlider;
    private Inventory inventory;
    private Equipment selectedEquipment;
    private UtilityEquipment utilityEquipment;

    private void OnEnable()
    {
        inventory = PlayerContext.MainPlayer.Inventory;
        inventory.OnEquipmentChanged += EquipmentChange;
        durabilitySlider.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
       inventory.OnEquipmentChanged -= EquipmentChange;
    }

    void EquipmentChange()
    {


       if(inventory.SelectedEquipment is UtilityEquipment)
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


    void Update()
    {
        if (durabilitySlider.gameObject.activeSelf)
            durabilitySlider.value = utilityEquipment.Durability;
    }
}
