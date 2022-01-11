using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    public Transform player;
    public TMP_Text scoreText;

    private void Update() {
        scoreText.text = (player.position.z / 10).ToString("0");
    }
}
