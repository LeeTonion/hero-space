using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energybar : Bar
{
    public static Energybar Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    public void UseEnergy(float value)
    {
        if (Slider.value >= value)
        {
            Slider.value -= value;
        }
    }
    public void Recharge(float value)
    {
        Slider.value= Mathf.Min( Slider.value + value, MaxBar);
    }
}