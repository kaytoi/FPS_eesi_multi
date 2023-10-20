using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private float health;
    public float maxHealth;
    public Slider healthSlider;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthSlider.value = health;
    }

    public void GetDamages(float amount)
    {
        health -= amount;
        healthSlider.value = health;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("ded");
    }
}
