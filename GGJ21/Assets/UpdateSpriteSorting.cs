using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSpriteSorting : MonoBehaviour
{

    public Grid worldGrid;

    // Update is called once per frame
    void Update() {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, 0);
        Vector3Int tilepos = worldGrid.WorldToCell(pos);
        Vector3 tileworldpos = worldGrid.CellToWorld(tilepos);
        Vector3 relativePos = pos - tileworldpos;
        Debug.Log(relativePos.y);
        if (relativePos.y < 0.25)
            transform.position = new Vector3(transform.position.x, transform.position.y, .5f);
        else
            transform.position = new Vector3(transform.position.x, transform.position.y, 1f);
    }
}
