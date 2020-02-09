/* Filename: LoadingScene.cs
 * Author: Caleb
 */
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/* LoadingScene Class
 * 
 * Handles display data of loading bar and loads the next level.
 */
public class LoadingScene : MonoBehaviour
{
    public Slider ProgressSlider; //The slider to display progress on.
    public Text ProgressText; //The text to display percent on.
    [HideInInspector]
    public static int SceneIndex; //Index of the scene to be loaded. The index refers to its place in the build settings scene list.

    void Start()
    {
        //Start a routine without freezing the scene.
        StartCoroutine(loadAsynchronously());
        
    }

    IEnumerator loadAsynchronously()
    {
        //Load the scene Asynchronously, allowing us to display data while it loads.
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneIndex);

        //Update the slider's progress until loading is complete.
        while (!operation.isDone)
        {
            ProgressSlider.value = operation.progress / 0.9f;
            ProgressText.text = Mathf.Clamp01(operation.progress / 0.9f) * 100f + "%";

            yield return null;
        }
    }
}
