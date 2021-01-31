using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class RectangleDialogue : MonoBehaviour {
    private bool hasHeardDialogue = false;
    private bool dialogueVisible = false;
    public GameObject dialogueBox;
    private GameObject dialogueBoxInstance;
    public GameObject canvas;
    private List<string> dialogue = new List<string> {
        "Rectangle: Hey, you. You're finally awake. You were trying to cross the border, right? Our plane went down...",
        "Rectangle: Are they still arguing back there?",
        "Rectangle: I can see some dark wood over there on the farthest islands...",
        "Rectangle: I would go out and get them myself but my rectangular body is failing me...",
        "Rectangle: I did make some mattocks for you to collect materials and left them on each island...",
        "Rectangle: don't ask me how I got there...",
        "Rectangle: If you complete each puzzle you get a mattock! You can use the wood and stones you pick up to navigate between islands.",
        "Rectangle: Rafts to get between sets of islands require 5 dark wood planks, bridges between islands require 2 planks and 2 stones. And the big boat needs 15 dark wood planks and 10 stones",

    };
    private int dialogueIndex = 0;
    public AudioSource m_MyAudioSource; 

    private void Update() {
        if ( Input.GetKeyDown(KeyCode.Space) ) {
            if ( dialogueVisible ) {
                DisplayNextDialogue();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if ( collision.CompareTag("Player") && !hasHeardDialogue ) {
            dialogueBoxInstance = Instantiate(dialogueBox, canvas.transform, false);
            dialogueVisible = true;
            hasHeardDialogue = true;
            DisplayNextDialogue();
        }
    }

    void DisplayNextDialogue() {
        if ( dialogueIndex < dialogue.Count ) {
            m_MyAudioSource.Play();
            dialogueBoxInstance.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = dialogue[dialogueIndex];
        } else {
            Destroy(dialogueBoxInstance);
        }
        dialogueIndex++;
    }
}
