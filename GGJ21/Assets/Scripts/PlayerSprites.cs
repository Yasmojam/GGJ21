using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprites : MonoBehaviour
{
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
    }
}
