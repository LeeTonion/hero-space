using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Healthbar : Bar
{
    public static Healthbar Instance {  get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    public void TakeDamage(float damage)
    {
        Slider.value -= damage;
    }
    public bool IsAlive()
    {
        return Slider.value > 0;
    }
}
