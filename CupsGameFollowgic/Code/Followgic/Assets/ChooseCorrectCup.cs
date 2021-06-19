using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCorrectCup : MonoBehaviour
{
    public CupsMovement game;

    void OnMouseDown() 
    {
        game.score = game.score + 1;

        FindObjectOfType<Manager>().LevelUp();
    }
}
