/*
 *
 * File: SpriteManager.cs
 * Author: Samuel
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * SpriteManager Class
 * 
 * Loads in sprites from resources folder, and serves them as needed.
 * Note: This is not a monobehavior, so it does not go on an object.
 * 
 */
public class SpriteManager {

    private static Dictionary<string, Sprite> _sprites = new Dictionary<string, Sprite>(); //A dictionary of all textures

    static SpriteManager() {
        Sprite[] tmp = Resources.LoadAll<Sprite>("Art/Sprites");
        foreach(Sprite s in tmp) {
            _sprites.Add(s.name, s);
        }
    }

    /*
     *
     * Function: GetTexture
     * Params: 
     *   textureName: the name of the texture to retrieve
     * Returns: the retrieved texture
     * 
     * retrieves a previously loaded texture from the Resources/Art/Textures folder
     * 
     */
    public static Sprite GetSprite(string spriteName) {
        return _sprites[spriteName];
    }

}
