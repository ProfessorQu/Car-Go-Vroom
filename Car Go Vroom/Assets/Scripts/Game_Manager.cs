using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    [HideInInspector] public static Game_Manager instance;

    public float restartDelay = 1f;

    private void Awake() {
        if (instance != null && instance != this) {
            Destroy(this);
        }
        else {
            instance = this;
        }
    }

    public void CompleteLevel() {
        Debug.Log("You win!");
    }

    public void EndGame() {
        Debug.Log("Ending game...");
        Invoke("Restart", restartDelay);
    }

    void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
