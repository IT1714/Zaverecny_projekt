using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AP_bar_script : MonoBehaviour
{
   public Slider slider;
  
  public void setMaxAP(float AP){
      slider.maxValue=AP;
      slider.value=AP;

  }
  public void setAP(float AP){
      slider.value = AP;
  }
}

