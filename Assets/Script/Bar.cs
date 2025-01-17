using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    
    protected Slider Slider;
    [SerializeField] public float MaxBar;
    private void Start()
    {
        Slider = GetComponent<Slider>();
    }
    public void setmaxBar(float value)
    {
        Slider.maxValue = value;
        MaxBar = value;
        Slider.value = value;
    }
   public void setBar (float value)
    {
        Slider.value = value;
    }
    public float getBar()
    {
        return Slider.value;
    }
    
}
