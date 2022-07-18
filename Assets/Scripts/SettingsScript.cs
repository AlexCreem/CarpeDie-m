using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Dropdown resultionDropdown;
    Resolution[] resolutions;
    void Start (){
        resolutions = Screen.resolutions;
        resultionDropdown.ClearOptions();
        List <string> options = new List<string>();
        for (int i = 0; i<resolutions.Length; i++){
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
        }
        resultionDropdown.AddOptions(options);
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
    }

    public void SetVolume (float volume){
        audioMixer.SetFloat("Volume", volume);
    }

    public void SetQuality (int qualityIndex){
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen (bool isFullscreen){
        Screen.fullScreen = isFullscreen;
    }
}
