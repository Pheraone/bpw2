using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBehaviour : MonoBehaviour
{
    public Slider healthBarSlider;
    public int maxHealth;
    public Text healthText;

    void Start()
    {
        //healthbar is full
        PlayerMovement.Instance.currentHealth = maxHealth;
    }

    
    void Update()
    {
        //health is checked and displayed
        healthBarSlider.maxValue = maxHealth;
        healthBarSlider.value = PlayerMovement.Instance.currentHealth;
        healthText.text = PlayerMovement.Instance.currentHealth.ToString() + "/" + maxHealth.ToString();
    }
}
