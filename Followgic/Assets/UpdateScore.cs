using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScore : MonoBehaviour
{
    public CupsMovement game;
    public Text scoreText;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "SCORE: " + game.score.ToString();
    }
}
