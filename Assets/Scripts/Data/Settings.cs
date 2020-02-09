using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings: MonoBehaviour
{
    public Dropdown GraphicsDropdown;
    public Toggle FullscreenToggle;

    public void Start()
    {
        GraphicsDropdown.value = QualitySettings.GetQualityLevel();
        FullscreenToggle.isOn = Screen.fullScreen;
    }

    public void SetQuality(int quality)
    {
        QualitySettings.SetQualityLevel(quality);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
