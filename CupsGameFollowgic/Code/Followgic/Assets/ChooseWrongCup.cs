using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseWrongCup : MonoBehaviour
{
    public CupsMovement game;

    void OnMouseDown()
    {
        Debug.Log("You failed!!");
        game.score = 0;

        FindObjectOfType<Manager>().GameOver();
    }
}
