using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    public void LoadNextLevel() {
        Game_Manager.instance.LoadNextLevel();
    }
}