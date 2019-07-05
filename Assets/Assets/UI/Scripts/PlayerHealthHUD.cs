using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerHealthHUD : MonoBehaviour
{
                            
    public Slider healthSlider;
    public Image fillSliderImage;

    private Health health;
    private Color minColor = new Color(142f / 255f, 40f / 255f, 0f / 255f);
    private Color maxColor = new Color(70f / 255f, 137f / 255f, 102f / 255f);


    private void OnEnable()
    {
        health = PlayerContext.MainPlayer.Health;
        healthSlider.value = health.MaximumHealth;
        fillSliderImage.color = maxColor;
        health.OnHealthChanged += HealthChange;
    }

    private void OnDisable()
    {
        health.OnHealthChanged -= HealthChange;
    }

    private void HealthChange()
    {
        healthSlider.value = health.CurrentHealth;
        fillSliderImage.color = Color.Lerp(minColor, maxColor, healthSlider.value / health.MaximumHealth);

        if (health.CurrentHealth <= 0)
            Death();
    }


    void Death()
    {
        //SceneManager.LoadScene(2);
    }
}