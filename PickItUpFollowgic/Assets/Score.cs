using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public PlayerController player;
    private Text points;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        points = GetComponent<Text>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        score = player.getCardsTaken();
        
        points.text = "SCORE: " + score.ToString();
    }
}
