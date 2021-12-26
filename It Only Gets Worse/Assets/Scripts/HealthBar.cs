using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider slider;

    private Image fill;

    [SerializeField]
    private Gradient gradient;

    private void Awake()
    {
        slider = GetComponent<Slider>(); //make sure slide is in the same place you put this one
        fill = GetComponentInChildren<Image>(); //make sure fill its the first child
    }

    public void setHealth(int health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }
}