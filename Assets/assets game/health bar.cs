using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{
    
    public Slider Slider;
    public void setmaxheath(float heath)
    {
        Slider.maxValue = heath;
        Slider.value = heath;
    }
   public void sethealth (float heath)
    {
        Slider.value = heath;
    }
    
}
