using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Linq;


public class SettingsMenu : MonoBehaviour
{
    [Header("Audio")]
    public AudioMixer audioMixer;
    [SerializeField] private TMPro.TextMeshProUGUI volumeText = null;
    [Header("Display")]
    public TMPro.TMP_Dropdown resolutionDropDown;
    Resolution[] resolutions;

     void Start () {
        resolutions = Screen.resolutions.Where(resolutions => resolutions.refreshRate == 60).ToArray();
       
        resolutionDropDown.ClearOptions();

        int currentResolutionIndex = 0;
        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length; i++) {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && 
            resolutions[i].height == Screen.currentResolution.height) {
                currentResolutionIndex = i;
            }
        }
        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = currentResolutionIndex;
        resolutionDropDown.RefreshShownValue();
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume" , volume);
        volumeText.text = volume.ToString("0,0");

    }
    public void GraphicSettings (int qualityIndex) {
       QualitySettings.SetQualityLevel(qualityIndex);
   }
    public void FullScreen (bool isFullScreen) {
       Screen.fullScreen = isFullScreen;
   }
}
