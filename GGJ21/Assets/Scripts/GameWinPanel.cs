using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWinPanel : MonoBehaviour
{
    public void PlayAgain() {
        SceneManager.LoadScene(1);
    }
}
