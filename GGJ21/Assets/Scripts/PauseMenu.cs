using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public AudioMixer audioMixer;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (GameIsPaused) {
                Resume();
            } else {
                Pause();
            }
        }
        
    }

    public void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
    }

    public void SetScreamVolume(float volume) {
        audioMixer.SetFloat("scream", volume);
    }
    public void SetSadSoundVolume(float volume) {
        audioMixer.SetFloat("sad_sound", volume);
    }
    public void SetItemPickupVolume(float volume) {
        audioMixer.SetFloat("pickup", volume);
    }
    public void SetStepsVolume(float volume) {
        audioMixer.SetFloat("steps", volume);
    }
    public void SetMusicVolume(float volume) {
        audioMixer.SetFloat("music", volume);
    }
}
