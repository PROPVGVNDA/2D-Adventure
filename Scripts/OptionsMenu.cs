using UnityEngine;
using TMPro;
using UnityEngine.Audio;
using System.Collections.Generic;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] TMP_Dropdown resolutionDropdown;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject optionsMenu;
    private Resolution[] availableResolutions;

    private void Start()
    {
        availableResolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> availableResolutionsStrings = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < availableResolutions.Length; i++)
        {
            string stringResolution = $"{availableResolutions[i].width}x{availableResolutions[i].height}";
            availableResolutionsStrings.Add(stringResolution);
            
            if (availableResolutions[i].width == Screen.currentResolution.width &&
                availableResolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i; 
            }
        }

        resolutionDropdown.AddOptions(availableResolutionsStrings);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void SetQuailty(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreenMode(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen; 
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = availableResolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void GoBackButton()
    {
        optionsMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
