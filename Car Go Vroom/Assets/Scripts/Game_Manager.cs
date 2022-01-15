using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Game_Manager : MonoBehaviour
{
    [HideInInspector] public static Game_Manager instance;

    public GameObject completeLevelUI;
    public GameObject gameOverUI;
    public GameObject pausedUI;

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

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (!completeLevelUI.activeInHierarchy && !gameOverUI.activeInHierarchy) {
                if (pausedUI.activeInHierarchy) {
                    pausedUI.SetActive(false);
                    Time.timeScale = 1f;
                }
                else {
                    pausedUI.SetActive(true);
                    Time.timeScale = 0.00001f;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            Restart();
        }
    }

    public void CompleteLevel() {
        Time.timeScale = 1f;

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
        Time.timeScale = 1f;

        Debug.Log("Ending game...");
        isRestarting = true;

        ScoreText score = GetComponent<ScoreText>();
        score.enabled = false;
        
        gameOverUI.SetActive(true);
    }

    public void LoadNextLevel() {
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Restart() {
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        isRestarting = false;
    }

    public void Menu() {
        Time.timeScale = 1f;

        SceneManager.LoadScene(0);
    }
}
