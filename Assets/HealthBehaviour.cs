using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBehaviour : MonoBehaviour
{
    public Slider healthBarSlider;
    public int maxHealth;
    public Text healthText;
    bool isDead;
    void Start()
    {
        PlayerMovement.Instance.currentHealth = maxHealth;
    }

    
    void Update()
    {
        healthBarSlider.maxValue = maxHealth;
        healthBarSlider.value = PlayerMovement.Instance.currentHealth;
        healthText.text = PlayerMovement.Instance.currentHealth.ToString() + "/" + maxHealth.ToString();

        //if(PlayerMovement.Instance.healthBarDrop == true)
        //{

        //}
    }
}
