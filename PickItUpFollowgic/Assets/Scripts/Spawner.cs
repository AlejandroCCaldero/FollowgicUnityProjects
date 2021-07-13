using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float minX;
    public float maxX;
    public float y;

    private float timer;
    private float timer2;

    public GameObject card;
    public GameObject rareCard;

    private void Start() 
    {
        timer = 2f;
        timer2 = 10f;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        timer2 -= Time.deltaTime;

        if(timer <= 0)
        {
            if(timer2 <= 0)
            {
                Instantiate(rareCard, new Vector2(Random.Range(minX, maxX), y), Quaternion.identity);
                timer2 = 10f;
                timer = 2f;
            }
            else
            {
                Instantiate(card, new Vector2(Random.Range(minX, maxX), y), Quaternion.identity);
                timer = 2f;   
            }
        }
    }
}
