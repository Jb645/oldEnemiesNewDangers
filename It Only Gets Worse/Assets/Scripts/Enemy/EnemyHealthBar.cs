using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] public Slider healthSlider;
    [SerializeField] private Image fillImg;
    [SerializeField] private Entity entity;

    void Start()
    {
        healthSlider.maxValue = entity.maxHealth;
        healthSlider.minValue = 0f;

        fillImg.color = Color.green;
        healthSlider.value = entity.maxHealth;
    }

    void Update()
    {
        if(healthSlider.value <= 60f && healthSlider.value >= 30f)
        {
            fillImg.color = Color.yellow;
        }
        else if(healthSlider.value < 30f)
        {
            fillImg.color = Color.red;
        }
    }
}
