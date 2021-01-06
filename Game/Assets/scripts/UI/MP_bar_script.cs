using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MP_bar_script : MonoBehaviour
{
   public Slider slider;
  
  public void setMaxMP(float MP){
      slider.maxValue=MP;
      slider.value=MP;

  }
  public void setMP(float MP){
      slider.value = MP;
  }
}
