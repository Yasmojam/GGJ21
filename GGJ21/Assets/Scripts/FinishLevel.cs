using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    public string sceneToLoad;
    public AudioSource audio;

    public GameObject canvas;

    public GameObject travelingDialogue;
    private GameObject travelingDialogueInstance;

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            travelingDialogueInstance = Instantiate(travelingDialogue, canvas.transform, false);
            if (audio) {
                audio.Play();
                StartCoroutine(LoadSceneAfterDelay());
            } else {
                SceneManager.LoadScene(sceneToLoad);
            }
        }

    }


    IEnumerator LoadSceneAfterDelay() {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(3.5f);
        SceneManager.LoadScene(sceneToLoad);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}
