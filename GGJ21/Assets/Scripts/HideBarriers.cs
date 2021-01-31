using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HideBarriers : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Tiles
        if (GetComponent<TilemapRenderer>()){
            GetComponent<TilemapRenderer>().enabled = false;
        }
        // Sprites
        else if(GetComponent<SpriteRenderer>()) {
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
