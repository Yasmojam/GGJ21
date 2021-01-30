using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprites : MonoBehaviour
{
    public Grid worldGrid;
    public float groundLevel = 1f;

    float topHalfZBoost = .75f;
    float bottomHalfZBoost = 0f;

    Animator anim;


    void Start() {
        anim = GetComponent<Animator>();    
    }

    void Update() {

        float yInput = Input.GetAxis("Vertical");
        float xInput = Input.GetAxis("Horizontal");

        anim.SetFloat("yInput", yInput);
        if (yInput != 0f) {
            anim.SetFloat("xInput", 0);
        } else {
            anim.SetFloat("xInput", xInput);
        }

        if (xInput == 0 && yInput == 0) {
            anim.SetTrigger("Stop");
        }

        UpdateZPosition();
    }

    void UpdateZPosition() {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, groundLevel);
        Vector3Int tilepos = worldGrid.WorldToCell(pos);
        Vector3 tileworldpos = worldGrid.CellToWorld(tilepos);
        Vector3 relativePos = pos - tileworldpos;

        if (relativePos.y < 0.25)
            transform.position = new Vector3(transform.position.x, transform.position.y, groundLevel + bottomHalfZBoost);
        else
            transform.position = new Vector3(transform.position.x, transform.position.y, groundLevel + topHalfZBoost);
    }
}
