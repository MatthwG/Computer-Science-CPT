using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{

    public Slider slider;
    public void SetMaxHealth(int mana)
    {
        slider.maxValue = mana;
        slider.value = mana;
    }
    public void SetHealth(int mana)
    {
        slider.value = mana;
    }
}