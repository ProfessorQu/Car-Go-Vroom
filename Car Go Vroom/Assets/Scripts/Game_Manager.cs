using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Game_Manager : MonoBehaviour
{
    [HideInInspector] public static Game_Manager instance;

    public GameObject completeLevelUI;

    public float restartDelay = 1f;
    bool isRestarting = false;

    private void Awake() {
        if (instance != null && instance != this) {
            Destroy(this);
        }
        else {
            instance = this;
        }
    }

    public void CompleteLevel() {
        if (!isRestarting) {
            Debug.Log("Level Complete!");
            completeLevelUI.SetActive(true);

            ScoreText score = GetComponent<ScoreText>();
            PlayerMovement movement = score.GetPlayerMovement();

            movement.enabled = false;
            score.enabled = false;
        }
    }

    public void EndGame() {
        Debug.Log("Ending game...");
        isRestarting = true;

        ScoreText score = GetComponent<ScoreText>();
        score.enabled = false;

        Invoke("Restart", restartDelay);
    }

    public void LoadNextLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        isRestarting = false;
    }
}
