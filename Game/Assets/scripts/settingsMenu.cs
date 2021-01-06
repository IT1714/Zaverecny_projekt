using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class settingsMenu : MonoBehaviour
{
    Resolution[] resolutions;
    public TMP_Dropdown ResolutionDropdown;
    public Toggle toggle;
    private void Start() {
        if(Screen.fullScreen==true){
            toggle.GetComponent<Toggle>().isOn=true;
        }if(Screen.fullScreen==false){
            toggle.GetComponent<Toggle>().isOn=false;
        }
        Debug.Log("x");
        resolutions = Screen.resolutions;
        ResolutionDropdown.ClearOptions();
        int currentResolutionIndex = 0;
        List<string> options = new List<string>();
        for(int i = 0; i< resolutions.Length;i++){
            string option = resolutions[i].width+"x"+resolutions[i].height;
            Debug.Log(resolutions);
            options.Add(option);
            if(resolutions[i].width== Screen.currentResolution.width&&resolutions[i].height== Screen.currentResolution.height){
                currentResolutionIndex = i;
            }
        }
        ResolutionDropdown.AddOptions(options);  
        ResolutionDropdown.value= currentResolutionIndex;
        ResolutionDropdown.RefreshShownValue(); 
    }
    public void setQuality(int qualityInt){
        QualitySettings.SetQualityLevel(qualityInt);
        Debug.Log("x");
    }

    public void fullScrean(bool isFullScrean){
        Screen.fullScreen =isFullScrean;    
    }

    public void setResolution(int ResolutionIndex){
        Resolution resolution=resolutions[ResolutionIndex];
        Screen.SetResolution(resolution.width,resolution.height, Screen.fullScreen);
    }

}
