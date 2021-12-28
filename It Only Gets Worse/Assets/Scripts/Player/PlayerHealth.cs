using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Slider healthSlider;

    public void TakeDamage(int amount)
    {
        healthSlider.value -= amount;
        //Debug.Log("player took damage");
    }
}