/* Filename: SceneLoader.cs
 * Author: Caleb
 */
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

/* SceneLoader Class
 * 
 * Allows for you to open a new loading screen with a targeted scene to load.
 */
public class SceneLoader : MonoBehaviour
{
    private const int _LOADING_SCREEN = 1;

    /* Function: LoadScene
     * 
     * Args:
     *  int sceneIndex: the index of the scene to load.
     *  
     * Returns: Nothing 
     * 
     * Creates a loading screen to load the target scene.
     */
    public void LoadScene(int sceneIndex)
    {
        //Tell the loading screen which scene to load.
        LoadingScene.SceneIndex = sceneIndex;

        SceneManager.LoadScene(_LOADING_SCREEN);
    }

    /* Function: Quit
     * 
     * Returns: Nothing
     * 
     * Quits the game.
     */
    public void Quit()
    {
        Application.Quit();
    }
}
