using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class energybar : MonoBehaviour
{
    public Slider slider;
    public void maxenergy(float energy)
    {
        slider.maxValue = energy;
        slider.value = energy;
    }
    public void setenergy(float energy)
    {
        slider.value = energy;
    }
}


