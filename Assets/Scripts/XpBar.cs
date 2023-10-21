using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XpBar : MonoBehaviour
{
    public Slider slider;

    public void SetMinXP(int xp)
    {
        slider.minValue = xp;
        slider.value = xp;
    }

    public void SetXP(int xp)
    {
        slider.value = xp;
    }
}
