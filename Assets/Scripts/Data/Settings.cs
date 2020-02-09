/* Filename: Settings.cs
 * Author: Caleb
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Settings Class.
 * 
 * Used by the options menu to change settings.
 */
public class Settings: MonoBehaviour
{
    public Dropdown GraphicsDropdown; //Dropdown menu for graphics.
    public Dropdown ResolutionsDropdown; //Dropdown menu for resolutions.

    public Toggle FullscreenToggle; //Fullscreen button.

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

    /* Function: SetQuality
     * 
     * Args:
     *  int quality: the quality level to set to.
     *  
     * Returns: Nothing
     * 
     * Changes the graphics quality.
     */
    public void SetQuality(int quality)
    {
        QualitySettings.SetQualityLevel(quality);
    }

    /* Function: LoadMenu
     * 
     * Args:
     *  bool isFullscreen: whether to set it to fullscreen or windowed.
     *  
     * Returns: Nothing 
     * 
     * Toggles fullscreen.
     */
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    /* Function: SetResolution
     * 
     * Args:
     *  int index: the index of the resolution in the _resolutions list.
     *  
     * Returns: Nothing 
     * 
     * Changes the resolution.
     */
    public void SetResolution(int index)
    {
        Resolution resolution = _resolutions[index];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
