using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ArgueDialogue : MonoBehaviour
{
    private bool hasHeardDialogue = false;
    private bool dialogueVisible = false;
    public GameObject dialogueBox;
    private GameObject dialogueBoxInstance;
    public GameObject canvas;
    public GameObject invisibleWall;

    private List<string> dialogue = new List<string> {
        "Rhombus: NO! The best way to build boats is with palm trees!",
        "Triangle: Are you mad?! Palm trees are not strong enough to survive the open sea! We need Pine!",
        "Rhombus: But there is no PINE! Only Palm!",
        "Triangle: We'll find some then!",
        "Rhombus: Where?! We're stuck on this island!!",
        "Square: Guys? Where did rectangle NPC go? ",
        "Rhombus and Triangle: NOT NOW!"
    };
    private int dialogueIndex = 0;
    public AudioSource Square_MyAudioSource;
    public AudioSource Triangle_MyAudioSource;
    public AudioSource Rhobus_MyAudioSource;


    private void Update() {
        if ( Input.GetKeyDown(KeyCode.Space) ) {
            if ( dialogueVisible ) {
                DisplayNextDialogue();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if ( collision.CompareTag("Player") && !hasHeardDialogue) {
            dialogueBoxInstance = Instantiate(dialogueBox, canvas.transform, false);
            dialogueVisible = true;
            hasHeardDialogue = true;
            DisplayNextDialogue();
        }
    }

    void DisplayNextDialogue() {
        if (dialogueIndex < dialogue.Count) {
            dialogueBoxInstance.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = dialogue[dialogueIndex];
            if (dialogue[dialogueIndex].StartsWith("Rhombus")) {
                Rhobus_MyAudioSource.Play();
            } else if ( dialogue[dialogueIndex].StartsWith("Triangle") ) {
                Triangle_MyAudioSource.Play();
            } else if ( dialogue[dialogueIndex].StartsWith("Square") ) {
                Square_MyAudioSource.Play();
            } else if ( dialogue[dialogueIndex].StartsWith("Rhombus and Triangle") ) {
                Rhobus_MyAudioSource.Play();
                Triangle_MyAudioSource.Play();
            }
        } else {
            // Turn off invisible wall?
            invisibleWall.gameObject.GetComponent<Collider2D>().enabled = false; 
            Destroy(dialogueBoxInstance);
        }
        dialogueIndex++;
    }

}
