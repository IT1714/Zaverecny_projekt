using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HP_bar_script : MonoBehaviour
{
  public Slider slider;
  
  public void setMaxHP(float HP){
      slider.maxValue=HP;
      slider.value=HP;

  }
  public void setHP(float HP){
      slider.value = HP;
  }
}
