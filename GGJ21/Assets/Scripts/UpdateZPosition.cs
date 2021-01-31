using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateZPosition : MonoBehaviour
{
    public Grid worldGrid;
    public float groundLevel = 1f;

    public float topHalfZBoost = .75f;
    public float bottomHalfZBoost = 0f;

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, groundLevel + CalculateZBoost());
    }


    public float CalculateZBoost() {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, groundLevel);
        Vector3Int tilepos = worldGrid.WorldToCell(pos);
        Vector3 tileworldpos = worldGrid.CellToWorld(tilepos);
        Vector3 relativePos = pos - tileworldpos;
        //return relativePos.y + .25f;
        return relativePos.y < 0.25 ? bottomHalfZBoost : topHalfZBoost;
    }
}
