using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings: MonoBehaviour
{
    public Dropdown GraphicsDropdown;
    public Dropdown ResolutionsDropdown;

    public Toggle FullscreenToggle;

    private Resolution[] _resolutions;

    public void Start()
    {
        //Set the default values for each UI item.
        GraphicsDropdown.value = QualitySettings.GetQualityLevel();
        FullscreenToggle.isOn = Screen.fullScreen;

        _resolutions = Screen.resolutions;

        List<string> resolutions = new List<string>();

        int currentResolution = 0;

        //Go through each resolution and convert it to a string for the Dropdown Menu.
        for(int i=0; i<_resolutions.Length; i++)
        {
            string resolution = _resolutions[i].width + " * " + _resolutions[i].height;
            resolutions.Add(resolution);

            if (_resolutions[i].width == Screen.width && _resolutions[i].height == Screen.height) currentResolution = i;
        }

        ResolutionsDropdown.ClearOptions();
        ResolutionsDropdown.AddOptions(resolutions);
        ResolutionsDropdown.value = currentResolution;
    }

    public void SetQuality(int quality)
    {
        QualitySettings.SetQualityLevel(quality);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution(int index)
    {
        Resolution resolution = _resolutions[index];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
