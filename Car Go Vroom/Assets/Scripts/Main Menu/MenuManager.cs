using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenuUI;
    public GameObject levelSelectUI;

    public void LoadLevel(int index) {
        SceneManager.LoadScene(index);
    }

    public void ActivateMainMenu() {
        mainMenuUI.SetActive(true);
        levelSelectUI.SetActive(false);
    }

    public void ActivateLevelSelect() {
        mainMenuUI.SetActive(false);
        levelSelectUI.SetActive(true);
    }

    public void Quit() {
        Debug.Log("Quitting...");
        Application.Quit();
    }
}
